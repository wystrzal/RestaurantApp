using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using WebMvc.Extensions;
using WebMvc.Models;
using WebMvc.Models.AccountModels;
using WebMvc.Services.AccountService;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult Login()
        {
            
            if (User?.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var tryLogin = await accountService.Login(login);

                if (tryLogin.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var token = 
                        JsonConvert.DeserializeObject<TokenModel>(await tryLogin.Content.ReadAsStringAsync());

                    AuthenticationProperties options = new AuthenticationProperties();

                    options.AllowRefresh = true;
                    options.IsPersistent = true;
                    options.ExpiresUtc = DateTime.Now.AddDays(1);

                    var claims = new List<Claim>
                    {
                       new Claim("AcessToken", token.Token)
                    };

                    foreach (var claim in token.RoleClaims)
                    {
                       claims.Add(new Claim(ClaimTypes.Role, claim));
                    }

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(identity),
                        options);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Unauthorized.");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Index()
        {
            var vm = await accountService.GetUsers();

            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(user.UserName))
                {
                    ModelState.AddModelError("", "The Password field is required.");
                    return View();
                }

                if (!user.Password.ContainsUpper())
                {
                    ModelState.AddModelError("", "The Password field must have uppercase letters.");
                    return View();
                }

                if (!user.Password.ContainsDigit())
                {
                    ModelState.AddModelError("", "The Password field must have digits.");
                    return View();
                }

                var response = await accountService.CreateUser(user);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
                }
            }

            return View();
        }
    }
}