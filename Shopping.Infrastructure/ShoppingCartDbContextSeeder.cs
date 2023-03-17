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
                new ShoppingItem { Id = Guid.NewGuid(), Name = "Item 1", Description = "Description 1", Price = 10 },
                new ShoppingItem { Id = Guid.NewGuid(), Name = "Item 2", Description = "Description 2", Price = 20 },
                new ShoppingItem { Id = Guid.NewGuid(), Name = "Item 3", Description = "Description 3", Price = 30 }
            );
            context.SaveChanges();
        }
    }
}
