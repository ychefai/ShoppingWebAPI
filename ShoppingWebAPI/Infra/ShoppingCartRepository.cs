using Microsoft.EntityFrameworkCore;


namespace Shopping.Infrastructure
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ShoppingCartDbContext _dbContext;

        public ShoppingCartRepository(ShoppingCartDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ShoppingItem Add(ShoppingItem newItem)
        {
            _dbContext.Set<ShoppingItem>().Add(newItem);
            _dbContext.SaveChanges();
            return newItem;
        }

        public IEnumerable<ShoppingItem> GetAllItems()
        {
            return _dbContext.Set<ShoppingItem>().ToList();
        }

        public ShoppingItem GetById(Guid id)
        {
            return _dbContext.Set<ShoppingItem>().Find(id);
        }

        public void Remove(Guid id)
        {
            var itemToRemove = _dbContext.Set<ShoppingItem>().Find(id);
            _dbContext.Set<ShoppingItem>().Remove(itemToRemove);
            _dbContext.SaveChanges();
        }
    }
}
