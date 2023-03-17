using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure
{
    public class ShoppingCartService : IShoppingCartRepository
    {
        private readonly IShoppingCartRepository _repository;

        public ShoppingCartService(IShoppingCartRepository repository)
        {
            _repository = repository;
        }

        public ShoppingItem Add(ShoppingItem newItem)
        {
            return _repository.Add(newItem);
        }

        public IEnumerable<ShoppingItem> GetAllItems()
        {
            return _repository.GetAllItems();
        }

        public ShoppingItem GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
