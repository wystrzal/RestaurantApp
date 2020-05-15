using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Identity.Dto;
using Identity.Extensions;
using Identity.Helpers;
using Identity.Models;
using Identity.Models.ViewModels;
using IdentityServer4.Events;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IIdentityServerInteractionService interaction;
        private readonly IClientStore clientStore;
        private readonly IEventService events;
        private readonly IMapper mapper;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager,
            IIdentityServerInteractionService interaction, IClientStore clientStore, IEventService events,
            IMapper mapper)
        {
            this.userManager = userManager;
            this.interaction = interaction;
            this.clientStore = clientStore;
            this.events = events;
            this.mapper = mapper;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var vm = await BuildLoginViewModelAsync(returnUrl);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var context = await interaction.GetAuthorizationContextAsync(model.ReturnUrl);

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Username);

                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    await events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName));

                    AuthenticationProperties props = null;

                    // Issue authentication cookie with subject ID and username
                    await HttpContext.SignInAsync(user.Id, user.UserName, props);

                    if (context != null)
                    {
                        return Redirect(model.ReturnUrl);
                    }

                    // request for a local page
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else if (string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect("~/");
                    }
                    else
                    {
                        throw new Exception("invalid return URL");
                    }
                }

                await events.RaiseAsync(new UserLoginFailureEvent(model.Username, "invalid credentials"));
                ModelState.AddModelError(string.Empty, "Invalid username or password");
            }
        
            // Something went wrong, show form with error.
            var vm = await BuildLoginViewModelAsync(model);
            return View(vm);
        }


        [Route("api/[controller]")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var user = new User { UserName = model.UserName, FirstName = model.FirstName, LastName = model.LastName };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return BadRequest(result.Errors.FirstOrDefault().Description);

            if (model.Role == "kitchen")
            {
                await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", Roles.Kitchen));
            } 
            else
            {
                await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", Roles.Restaurant));
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await signInManager.SignOutAsync();
            var context = await interaction.GetLogoutContextAsync(logoutId);
            return Redirect(context.PostLogoutRedirectUri);
        }

        [Route("api/[controller]")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await userManager.Users.ToListAsync();

            var usersForReturn = mapper.Map<IEnumerable<UserForReturn>>(users);

            return Ok(usersForReturn);
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync(string returnUrl)
        {
            var context = await interaction.GetAuthorizationContextAsync(returnUrl);
   
            var allowLocal = true;
            if (context?.ClientId != null)
            {
                var client = await clientStore.FindEnabledClientByIdAsync(context.ClientId);
                if (client != null)
                {
                    allowLocal = client.EnableLocalLogin;
                }
            }

            return new LoginViewModel
            {
                EnableLocalLogin = allowLocal,
                ReturnUrl = returnUrl,
                Username = context?.LoginHint
            };
        }

        private async Task<LoginViewModel> BuildLoginViewModelAsync(LoginDto model)
        {
            var vm = await BuildLoginViewModelAsync(model.ReturnUrl);
            vm.Username = model.Username;
            return vm;
        }
    }
}