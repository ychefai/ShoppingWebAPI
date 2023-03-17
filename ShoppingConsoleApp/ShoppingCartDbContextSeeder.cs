using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure
{
    public static class ShoppingCartDbContextSeeder
    {
        public static void Seed(ShoppingCartDbContext context)
        {
            context.ShoppingItems.AddRange(
                new ShoppingItem { Id = Guid.NewGuid(), Name = "Item 1", Manufacturer = "Manufacturer1", Price = 10},
                new ShoppingItem { Id = Guid.NewGuid(), Name = "Item 2", Manufacturer = "Manufacturer2",  Price = 20 },
                new ShoppingItem { Id = Guid.NewGuid(), Name = "Item 3", Manufacturer = "Manufacturer3",  Price = 30 }
            );
            context.SaveChanges();
        }
    }
}
