using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebMvc.Infractructure;
using WebMvc.Models;
using WebMvc.Models.AccountModels;
using WebMvc.ViewModels;

namespace WebMvc.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly string baseUrl;
        private readonly IHttpClient httpClient;

        public AccountService(IHttpClient httpClient, IHttpContextAccessor httpContext)
        {
            this.httpClient = httpClient;
            baseUrl = "http://host.docker.internal:5000/api/account/";
        }

        public async Task<HttpResponseMessage> CreateUser(User user)
        {
            var createUserUri = ApiPaths.Account.CreateUser(baseUrl);

            var response = await httpClient.PostAsync(createUserUri, user);

            return response;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var getUsersUri = ApiPaths.Account.GetUsers(baseUrl);

            var dataString = await httpClient.GetStringAsync(getUsersUri);

            var respone = JsonConvert.DeserializeObject<IEnumerable<User>>(dataString);

            return respone;
        }

        public async Task<HttpResponseMessage> Login(LoginViewModel login)
        {
            var loginUri = ApiPaths.Account.Login(baseUrl);

            var response = await httpClient.PostAsync(loginUri, login);

            return response;
        }
    }
}
