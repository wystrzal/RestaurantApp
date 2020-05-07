using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infractructure
{
    public class ApiPaths
    {
        public static class Menu
        {
            public static string GetMenu(string baseUri, int typeId, int page)
            {
                return $"{baseUri}type/{typeId}?pageIndex={page}";
            }
            public static string GetTypes(string baseUri)
            {
                return $"{baseUri}types";
            }
        }
        public static class Order
        {
            public static string GetOrders(string baseUri)
            {
                return $"{baseUri}notpaid";
            }
        }
    }
}
