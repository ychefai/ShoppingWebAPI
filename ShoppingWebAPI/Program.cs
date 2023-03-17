using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        // Add configuration
        builder.Configuration.AddJsonFile("appsettings.json");

        // Add services to the container.

        builder.Services.AddControllers();

        // Read the connection string from the configuration
        string connectionString = builder.Configuration.GetConnectionString("DbConnection");

        // Create the DbContext
        builder.Services.AddDbContext<ShoppingCartDbContext>(options => options.UseSqlServer(connectionString));

        // Seed the data
        using var scope = builder.Services.BuildServiceProvider().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ShoppingCartDbContext>();

        //migration
         context!.Database.MigrateAsync();
        ShoppingCartDbContextSeeder.Seed(context);
        

        // Register the repository with the DI container
        builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
