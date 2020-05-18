using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Dto;
using Account.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration config;
        private readonly IMapper mapper;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            IConfiguration config, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.config = config;
            this.mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await userManager.FindByNameAsync(loginDto.Username);

            if (user == null)
            {
                return Unauthorized();
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (result.Succeeded)
            {
                var token = await TokenGenerator.GenerateJwtToken(user, config, userManager);
                
                return Ok(token);
            }

            return Unauthorized();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = mapper.Map<User>(registerDto);

            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (result.Succeeded)
            {
                if (registerDto.Role == "kitchen")
                {
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", Roles.Kitchen));
                }
                else
                {
                    await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("role", Roles.Restaurant));
                }

                return Ok();
            }

            return BadRequest("User with this login already exists.");
        }
    }
}