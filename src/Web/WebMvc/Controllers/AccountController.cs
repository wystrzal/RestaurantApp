using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}