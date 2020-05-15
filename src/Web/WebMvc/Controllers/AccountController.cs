using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebMvc.Extensions;
using WebMvc.Models;
using WebMvc.Services.AccountService;

namespace WebMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
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
                    var error = await response.Content.ReadAsStringAsync();
   
                    ModelState.AddModelError("", await response.Content.ReadAsStringAsync());
                }
            }

            return View();
        }
    }
}