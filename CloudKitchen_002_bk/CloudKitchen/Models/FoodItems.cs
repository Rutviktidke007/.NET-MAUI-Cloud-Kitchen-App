using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudKitchen.Models {
    internal class FoodItems {
        public FoodItems() { }

        public List<FoodItem> items {
            get {
                List<FoodItem> items = new List<FoodItem>();
                //Load some dummy items
                items.Add(new FoodItem { Id = 1, Title = "Cake", Description = "Cake for comfort", Price = 5.99 });
                items.Add(new FoodItem { Id = 2, Title = "Mango", Description = "Mango for comfort", Price = 10.45 });
                items.Add(new FoodItem { Id = 3, Title = "Apple", Description = "Apple for health", Price = 100.00 });
                items.Add(new FoodItem { Id = 4, Title = "Water", Description = "Water for comfort", Price = 10.45 });
                items.Add(new FoodItem { Id = 4, Title = "BBQ", Description = "Super yummy BBQ", Price = 45.98 });
                return items;
            }
        }
    }
}
