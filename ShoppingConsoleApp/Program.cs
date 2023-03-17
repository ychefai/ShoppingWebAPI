// See https://aka.ms/new-console-template for more information

using Shopping.Infrastructure;

//string connectionString = "Data Source=.;  User ID = sa;Password=SqlServer@PcYC2023;";
//"Server=(localdb)\\mssqllocaldb;Database=ShoppingCartDb;User Id=sa;Password=SqlServer@PcYC2023;";
string connectionString = "Data Source=.;Initial Catalog=ShoppingCartDb;User ID=sa;Password=SqlServer@PcYC2023;TrustServerCertificate=True;";

/*worked
using (var dbContext = new ShoppingCartDbContext(connectionString))
{
    dbContext.Database.EnsureCreated();
    ShoppingCartDbContextSeeder.Seed(dbContext);

    var items = dbContext.ShoppingItems.ToList();
    foreach (var item in items)
    {
        Console.WriteLine($"{item.Name}: {item.Price:C}");
    }
}*/


ShoppingCartDbContext dbContext = new ShoppingCartDbContext(connectionString);

ShoppingCartRepository shoppingCartService = new ShoppingCartRepository(dbContext);
ShoppingCartDbContextSeeder.Seed(dbContext);

// Add a new item
var newItem = new ShoppingItem { Name = "Test Item",Manufacturer= "Manufacturer", Price = 10.0m };
var addedItem = shoppingCartService.Add(newItem);
Console.WriteLine("Added item with ID: " + addedItem.Id);

// Get all items
var allItems = shoppingCartService.GetAllItems();
foreach (var item in allItems)
{
    Console.WriteLine("Item: " + item.Name + ", Price: " + item.Price);
}

// Get an item by ID
var itemId = addedItem.Id;
var itemById = shoppingCartService.GetById(itemId);
Console.WriteLine("Item with ID " + itemId + ": " + itemById.Name + ", Price: " + itemById.Price);

// Remove an item by ID
shoppingCartService.Remove(itemId);
Console.WriteLine("Removed item with ID: " + itemId);

Console.WriteLine("Hello, World!");
