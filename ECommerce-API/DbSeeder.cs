using E_Commerce.DAL;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Order = E_Commerce.DAL.Models.Order;

namespace E_Commerce.API.Seed
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await context.Database.MigrateAsync();

            // ✅ Roles
            if (!await roleManager.Roles.AnyAsync())
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            // ✅ Admin User
            ApplicationUser? adminUser;
            if (!await userManager.Users.AnyAsync())
            {
                adminUser = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@store.com",
                    FirstName = "Admin",
                    LastName = "User",
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(adminUser, "Admin@123");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
            else
            {
                adminUser = await userManager.FindByNameAsync("admin");
            }

            // ✅ Customers
            var customers = new List<ApplicationUser>();
            string[] customerNames = { "Ahmed", "Omar", "Hossam", "Mostafa" };
            foreach (var name in customerNames)
            {
                var user = await userManager.FindByNameAsync(name.ToLower());
                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        UserName = name.ToLower(),
                        Email = $"{name.ToLower()}@mail.com",
                        FirstName = name,
                        LastName = "Customer",
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(user, "User@123");
                    await userManager.AddToRoleAsync(user, "Customer");
                }
                customers.Add(user);
            }

            // ✅ Shopping Carts for all users
            if (!await context.ShoppingCarts.AnyAsync())
            {
                var allUsers = customers.Append(adminUser);
                foreach (var user in allUsers)
                {
                    context.ShoppingCarts.Add(new ShoppingCart
                    {
                        UserId = user!.Id
                    });
                }
                await context.SaveChangesAsync();
            }

            // ✅ Categories
            if (!await context.Categories.AnyAsync())
            {
                var categories = new List<Category>
                {
                    new Category { Title = "Clothes", Prefix = "CL" },
                    new Category { Title = "Shoes", Prefix = "SH" },
                    new Category { Title = "Watches", Prefix = "WT" },
                    new Category { Title = "Accessories", Prefix = "AC" }
                };

                context.Categories.AddRange(categories);
                await context.SaveChangesAsync();

                // ✅ Products
                if (!await context.Products.AnyAsync())
                {
                    var clothes = categories.First(c => c.Title == "Clothes").CategoryId;
                    var shoes = categories.First(c => c.Title == "Shoes").CategoryId;
                    var watches = categories.First(c => c.Title == "Watches").CategoryId;
                    var accessories = categories.First(c => c.Title == "Accessories").CategoryId;

                    context.Products.AddRange(
                        new Product { Title = "Men Shirt", Description = "Cotton slim fit shirt", Price = 35, StockQuantity = 50, CategoryId = clothes, Image = new byte[0] },
                        new Product { Title = "Jeans Pants", Description = "Blue slim fit jeans", Price = 45, StockQuantity = 40, CategoryId = clothes, Image = new byte[0] },
                        new Product { Title = "Classic Shoes", Description = "Leather classic shoes", Price = 80, StockQuantity = 30, CategoryId = shoes, Image = new byte[0] },
                        new Product { Title = "Running Shoes", Description = "Lightweight running shoes", Price = 60, StockQuantity = 60, CategoryId = shoes, Image = new byte[0] },
                        new Product { Title = "Luxury Watch", Description = "Water resistant steel watch", Price = 150, StockQuantity = 20, CategoryId = watches, Image = new byte[0] },
                        new Product { Title = "Casual Watch", Description = "Leather casual watch", Price = 95, StockQuantity = 25, CategoryId = watches, Image = new byte[0] },
                        new Product { Title = "Sunglasses", Description = "UV protection sunglasses", Price = 30, StockQuantity = 70, CategoryId = accessories, Image = new byte[0] },
                        new Product { Title = "Leather Wallet", Description = "Genuine leather wallet", Price = 25, StockQuantity = 100, CategoryId = accessories, Image = new byte[0] }
                    );
                    await context.SaveChangesAsync();
                }
            }

            // ✅ Orders + OrderItems
            if (!await context.Orders.AnyAsync())
            {
                var customer1 = customers.First();
                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    TotalAmount = 135,
                    Status = "Completed",
                    UserId = customer1.Id
                };
                context.Orders.Add(order);
                await context.SaveChangesAsync();

                var shirt = await context.Products.FirstAsync(p => p.Title == "Men Shirt");
                var shoes = await context.Products.FirstAsync(p => p.Title == "Classic Shoes");
                var sunglasses = await context.Products.FirstAsync(p => p.Title == "Sunglasses");

                context.OrderItems.AddRange(
                    new OrderItem { OrderId = order.OrderId, ProductId = shirt.ProductId, Quantity = 1, UnitPrice = shirt.Price },
                    new OrderItem { OrderId = order.OrderId, ProductId = shoes.ProductId, Quantity = 1, UnitPrice = shoes.Price },
                    new OrderItem { OrderId = order.OrderId, ProductId = sunglasses.ProductId, Quantity = 1, UnitPrice = sunglasses.Price }
                );
                await context.SaveChangesAsync();
            }

            // ✅ Reviews
            if (!await context.Reviews.AnyAsync())
            {
                var customer2 = customers.Skip(1).First();
                var shirt = await context.Products.FirstAsync(p => p.Title == "Men Shirt");
                var shoes = await context.Products.FirstAsync(p => p.Title == "Classic Shoes");
                var watch = await context.Products.FirstAsync(p => p.Title == "Luxury Watch");

                context.Reviews.AddRange(
                    new Review { ProductId = shirt.ProductId, UserId = customer2.Id, Rating = 5, Comment = "Great quality shirt" },
                    new Review { ProductId = shoes.ProductId, UserId = customer2.Id, Rating = 4, Comment = "Comfortable shoes" },
                    new Review { ProductId = watch.ProductId, UserId = customer2.Id, Rating = 5, Comment = "Amazing luxury watch" }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
