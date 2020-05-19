using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Infractructure;

namespace WebMvc.Services.RestaurantService
{
    public class RestaurantService : IRestaurantService
    {
        private readonly string baseUri;
        private readonly IHttpClient httpClient;
        private readonly IHttpContextAccessor httpContext;

        public RestaurantService(IHttpClient httpClient, IHttpContextAccessor httpContext)
        {
            this.httpClient = httpClient;
            this.httpContext = httpContext;
            this.baseUri = "http://host.docker.internal:5400/api/restaurant/";
        }
        public async Task OrderReady(int orderId)
        {
            var orderReadyUri = ApiPaths.Restaurant.OrderReady(baseUri, orderId);

            var accessToken = httpContext.HttpContext.User.Claims.Where(x => x.Type == "AcessToken")
                .Select(x => x.Value).FirstOrDefault();

            await httpClient.PostAsync(orderReadyUri, orderId, accessToken);
        }

        public async Task OrderDelivered(int orderId)
        {
            var orderDeliveredUri = ApiPaths.Restaurant.OrderDelivered(baseUri, orderId);

            var accessToken = httpContext.HttpContext.User.Claims.Where(x => x.Type == "AcessToken")
                .Select(x => x.Value).FirstOrDefault();

            await httpClient.PostAsync(orderDeliveredUri, orderId, accessToken);
        }
    }
}
