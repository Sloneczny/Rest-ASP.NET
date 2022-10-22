using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using webAPIrest;
using webAPIrest.Entieties;
using AutoMapper;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    { 
        
        
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
         
        builder.Services.AddControllers();
        builder.Services.AddDbContext<RestaurantDbContext>();
        builder.Services.AddScoped<RestaurantSeeder>();
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //builder.Services.AddDbContext<RestaurantDbContext>
      //(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
       

        var app = builder.Build();
        var scope = app.Services.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<RestaurantSeeder>();


        // Configure the HTTP request pipeline.

        seeder.Seed();
        
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
        

    }
   
}