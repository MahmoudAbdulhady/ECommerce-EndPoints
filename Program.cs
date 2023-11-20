using EcommerceApp.Model;
using EcommerceApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);


if (builder.Environment.IsDevelopment())
{
    IdentityModelEventSource.ShowPII = true; // To display detail of error and see the problem
}

// Add services to the container.

//Angular enable CROS
builder.Services.AddCors(options =>
{
    options.AddPolicy("EcommerceApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Replace with your Angular app's URL
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<UserDatabaseContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository , ProductRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<UserDatabaseContext>();
    context.Database.Migrate(); // Apply pending migrations.

    // Check if there are any products already.
    if (!context.Products.Any())
    {
        // If not, seed data.
        context.Products.AddRange(
            new Products { ProductName = "Product 1", ProductCategory ="Mobile"  ,  Price = 100 , ProductCode = 330 , MinQuantity=2  },
            new Products { ProductName = "Product 2", ProductCategory = "Table", Price = 100, ProductCode = 110, MinQuantity = 2 },
            new Products { ProductName = "Product 3", ProductCategory = "Chair", Price = 100, ProductCode = 220, MinQuantity = 2 }
            // ... other products ...
        );
        context.SaveChanges(); // Save changes to the database.
    }
}




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;


app.UseCors("EcommerceApp");




app.MapControllers();

app.Run();
