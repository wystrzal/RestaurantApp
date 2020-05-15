using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.Services.AccountService
{
    public interface IAccountService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<HttpResponseMessage> CreateUser(User user);
    }
}
