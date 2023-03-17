using Microsoft.AspNetCore.Mvc;
using Shopping.Infrastructure;

namespace ShoppingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : Controller
    {

       
        private readonly  IShoppingCartRepository _shoppingCartService;
       
        public ShoppingCartController(IShoppingCartRepository shoppingCartService)
        {
            _shoppingCartService=shoppingCartService;
        }

        [HttpGet]
        public IActionResult Get()
        {           
            var items = _shoppingCartService.GetAllItems();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var item = _shoppingCartService.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ShoppingItem value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _shoppingCartService.Add(value);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var existingItem = _shoppingCartService.GetById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            _shoppingCartService.Remove(id);
            return NoContent();
        }

    }
}
