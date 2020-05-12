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
            public static string DeleteMenuType(string baseUri, int typeId)
            {
                return $"{baseUri}delete/type/{typeId}";
            }
            
            public static string DeleteMenuItem(string baseUri, int itemId)
            {
                return $"{baseUri}delete/{itemId}";
            }

            public static string PostMenuItem(string baseUri)
            {
                return $"{baseUri}new/item";
            }

            public static string PostMenuType(string baseUri)
            {
                return $"{baseUri}new/type";
            }
                
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
                return $"{baseUri}";
            }
        }

        public static class Restaurant
        {
            public static string OrderReady(string baseUri, int orderId)
            {
                return $"{baseUri}{orderId}";
            }
        }
    }
}
