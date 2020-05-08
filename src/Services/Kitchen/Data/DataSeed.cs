using Kitchen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Data
{
    public static class DataSeed
    {
        public static void AddDataToDb(DataContext dataContext)
        {
            if (!dataContext.Ingredients.Any())
            {
                List<Ingredients> ingredients = new List<Ingredients>()
                {
                    new Ingredients {Name = "Tomato", Quantity = 10M},
                    new Ingredients {Name = "Beef", Quantity = 10M},
                    new Ingredients {Name = "Chicken", Quantity = 10M},
                    new Ingredients {Name = "Salad", Quantity = 10M},
                    new Ingredients {Name = "Cheese", Quantity = 10M},
                    new Ingredients {Name = "Water", Quantity = 10M},
                    new Ingredients {Name = "Lemon", Quantity = 10M},
                    new Ingredients {Name = "Orange", Quantity = 10M},
                    new Ingredients {Name = "Apple", Quantity = 10M},
                };

                dataContext.AddRange(ingredients);
                dataContext.SaveChanges();
            }
        }
    }
}
