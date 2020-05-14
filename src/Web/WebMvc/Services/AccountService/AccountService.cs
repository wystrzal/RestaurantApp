using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infractructure;
using WebMvc.Models;

namespace WebMvc.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly string baseUrl;
        private readonly IHttpClient httpClient;
        private readonly IHttpContextAccessor httpContext;

        public AccountService(IHttpClient httpClient, IHttpContextAccessor httpContext)
        {
            this.httpClient = httpClient;
            this.httpContext = httpContext;
            baseUrl = "http://localhost:5000/api/account/";
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            var getUsersUri = ApiPaths.Account.GetUsers(baseUrl);

            var dataString = await httpClient.GetStringAsync(getUsersUri);

            var respone = JsonConvert.DeserializeObject<IEnumerable<User>>(dataString);

            return respone;
        }
    }
}
