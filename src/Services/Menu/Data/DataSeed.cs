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
                    new MenuItem {Description = "Very tasty burger with beaf, double cheese and tomato",
                        MenuTypeId = 1, Name = "Burger", Price = 12M
                     },
                    new MenuItem {Description = "Refreshing water, best on hot days",
                        MenuTypeId = 2, Name = "Water", Price = 2.65M
                     }
                };

                dataContext.MenuItems.AddRange(menuItems);
                dataContext.SaveChanges();
            }
        }
    }
}
