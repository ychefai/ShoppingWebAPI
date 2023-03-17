using Microsoft.AspNetCore.Mvc;
using Shopping.Infrastructure;

namespace ShoppingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : Controller
    {

      const  string connectionString = "Data Source=.;Initial Catalog=ShoppingCartDb;User ID=sa;Password=SqlServer@PcYC2023;TrustServerCertificate=True;";
        ShoppingCartDbContext dbContext = new ShoppingCartDbContext(connectionString);

        ShoppingCartRepository shoppingCartService;

        public ShoppingCartController()
        {
            shoppingCartService = new ShoppingCartRepository(dbContext);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = shoppingCartService.GetAllItems();
            return Ok(items);
        }

       
    }
}
