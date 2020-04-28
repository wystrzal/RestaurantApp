using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Models;
using IdentityServer4.Events;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IIdentityServerInteractionService interaction;
        private readonly IAuthenticationSchemeProvider schemeProvider;
        private readonly IClientStore clientStore;
        private readonly IEventService events;

        public IdentityController(SignInManager<User> signInManager, UserManager<User> userManager,
            IIdentityServerInteractionService interaction, IAuthenticationSchemeProvider schemeProvider,
            IClientStore clientStore, IEventService events)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.interaction = interaction;
            this.schemeProvider = schemeProvider;
            this.clientStore = clientStore;
            this.events = events;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)            {

                // validate username/password
                var user = await userManager.FindByNameAsync(model.Username);
                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    await events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.Name));

                    AuthenticationProperties props = null;

                    await HttpContext.SignInAsync(user.Id, user.UserName, props);
                    return Redirect(model.ReturnUrl);
                }

                return Unauthorized("Username or password is not correct.");
            }

            return Unauthorized("Username or password is not valid.");
        }

        [HttpPost("help")]
        public IActionResult Test()
        {
            return Ok("TEST");
        }

        [HttpGet]
        public IActionResult ViewLogin()
        {
            var login = new LoginDto { Password = "test", Username = "test" };
            return Ok(login);
        }
    }
}