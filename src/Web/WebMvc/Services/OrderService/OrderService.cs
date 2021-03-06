﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infractructure;
using WebMvc.Models;

namespace WebMvc.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly string baseUrl;
        private readonly IHttpClient httpClient;
        private readonly IHttpContextAccessor httpContext;

        public OrderService(IHttpClient httpClient, IHttpContextAccessor httpContext)
        {
            this.httpClient = httpClient;
            this.httpContext = httpContext;
            baseUrl = "http://host.docker.internal:5300/api/order/";
        }

        public async Task<IEnumerable<Orders>> GetOrders()
        {
            var getOrdersUri = ApiPaths.Order.GetOrders(baseUrl);

            var accessToken = httpContext.HttpContext.User.Claims.Where(x => x.Type == "AcessToken")
                .Select(x => x.Value).FirstOrDefault();

            var dataString = await httpClient.GetStringAsync(getOrdersUri, accessToken);

            var response = JsonConvert.DeserializeObject<IEnumerable<Orders>>(dataString);

            return response;
        }
    }
}
