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
            if (!dataContext.MenuIngredients.Any())
            {
                List<MenuIngredient> menuIngredients = new List<MenuIngredient>()
                {
                    new MenuIngredient {Name = "Tomato"},
                    new MenuIngredient {Name = "Beef"},
                    new MenuIngredient {Name = "Chicken"},
                    new MenuIngredient {Name = "Salad"},
                    new MenuIngredient {Name = "Cheese"},
                    new MenuIngredient {Name = "Water"},
                    new MenuIngredient {Name = "Lemon"},
                    new MenuIngredient {Name = "Orange"},
                    new MenuIngredient {Name = "Apple"},
                };

                dataContext.AddRange(menuIngredients);
                dataContext.SaveChanges();
            }

            if (!dataContext.MenuTypes.Any())
            {
                List<MenuType> menuTypes = new List<MenuType>()
                {
                    new MenuType {Type = "Non alcoholic drinks"},
                    new MenuType {Type = "Burgers"},
                };

                dataContext.MenuTypes.AddRange(menuTypes);
                dataContext.SaveChanges();
            }

            if (!dataContext.MenuItems.Any())
            {
                List<MenuItem> menuItems = new List<MenuItem>()
                {
                     new MenuItem {Description = "Refreshing apple juice, best on hot days",
                        MenuTypeId = 2, Name = "Apple Juice", Price = 5.5M
                     },
                     new MenuItem {Description = "Refreshing orange juice, best on hot days",
                        MenuTypeId = 2, Name = "Orange Juice", Price = 6M
                     },
                     new MenuItem {Description = "Refreshing water with lemon, best on hot days",
                        MenuTypeId = 2, Name = "Water", Price = 2.5M
                     },
                     new MenuItem {Description = "Very tasty burger with beaf, double cheese and tomato",
                        MenuTypeId = 1, Name = "CheeseBurger", Price = 16M
                     },
                     new MenuItem {Description = "Very tasty burger with chicken, salad and tomato",
                        MenuTypeId = 1, Name = "ChickenBurger", Price = 14M
                     },
                    new MenuItem {Description = "Very tasty burger with beef, salad and tomato",
                        MenuTypeId = 1, Name = "Burger", Price = 12M
                     },                   
                };

                dataContext.MenuItems.AddRange(menuItems);
                dataContext.SaveChanges();
            }

            if (!dataContext.MenuIngredientsItems.Any())
            {
                List<MenuIngredientsItems> menuIngredientsItems = new List<MenuIngredientsItems>()
                {
                    new MenuIngredientsItems { MenuIngredientId = 1, MenuItemId = 1, Quantity = 0.2M},
                    new MenuIngredientsItems { MenuIngredientId = 1, MenuItemId = 2, Quantity = 0.2M},
                    new MenuIngredientsItems { MenuIngredientId = 1, MenuItemId = 3, Quantity = 0.2M},
                    new MenuIngredientsItems { MenuIngredientId = 2, MenuItemId = 1, Quantity = 0.3M},
                    new MenuIngredientsItems { MenuIngredientId = 2, MenuItemId = 3, Quantity = 0.3M},
                    new MenuIngredientsItems { MenuIngredientId = 3, MenuItemId = 2, Quantity = 0.3M},
                    new MenuIngredientsItems { MenuIngredientId = 4, MenuItemId = 1, Quantity = 0.2M},
                    new MenuIngredientsItems { MenuIngredientId = 4, MenuItemId = 2, Quantity = 0.2M},
                    new MenuIngredientsItems { MenuIngredientId = 5, MenuItemId = 3, Quantity = 0.2M},
                    new MenuIngredientsItems { MenuIngredientId = 6, MenuItemId = 4, Quantity = 0.5M},
                    new MenuIngredientsItems { MenuIngredientId = 7, MenuItemId = 4, Quantity = 0.2M},
                    new MenuIngredientsItems { MenuIngredientId = 8, MenuItemId = 5, Quantity = 0.5M},
                    new MenuIngredientsItems { MenuIngredientId = 9, MenuItemId = 6, Quantity = 0.5M},
                };

                dataContext.AddRange(menuIngredientsItems);
                dataContext.SaveChanges();
            }
        }
    }
}
