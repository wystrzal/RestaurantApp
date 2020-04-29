using Menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Menu.Data
{
    public static class DataSeed
    {
        public static void AddDataToDb(DataContext dataContext)
        {
            if (!dataContext.MenuTypes.Any())
            {
                List<MenuType> menuTypes = new List<MenuType>()
                {
                    new MenuType {Type = "Burgers"},
                    new MenuType {Type = "Non alcoholic drinks"}
                };

                dataContext.MenuTypes.AddRange(menuTypes);
                dataContext.SaveChanges();
            }

            if (!dataContext.MenuItems.Any())
            {
                List<MenuItem> menuItems = new List<MenuItem>()
                {
                    new MenuItem {Description = "Tasty Burger", MenuTypeId = 1, Name = "Burger", Price = 12M,
                     PictureUrl = "https://images.unsplash.com/photo-1551782450-17144efb9c50?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1500&q=80"
                     },
                    new MenuItem {Description = "Water with ice and lemon.", MenuTypeId = 2, Name = "Water", Price = 2M,
                     PictureUrl = "https://images.unsplash.com/photo-1513558161293-cdaf765ed2fd?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1534&q=80"
                     }
                };

                dataContext.MenuItems.AddRange(menuItems);
                dataContext.SaveChanges();
            }
        }
    }
}
