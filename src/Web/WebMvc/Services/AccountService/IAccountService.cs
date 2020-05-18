using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebMvc.Models;
using WebMvc.Models.AccountModels;
using WebMvc.ViewModels;

namespace WebMvc.Services.AccountService
{
    public interface IAccountService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<HttpResponseMessage> CreateUser(User user);
        Task<HttpResponseMessage> Login(LoginViewModel login);
    }
}
