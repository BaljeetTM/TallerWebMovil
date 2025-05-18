using System;
using System.Collections.Generic;
using System.Linq;
using APITaller1.src.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace APITaller1.src.Data
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<StoreContext>()
                ?? throw new InvalidOperationException("Could not get StoreContext");

            SeedData(context);
        }

        private static void SeedData(StoreContext context)
        {
            context.Database.Migrate();

            // Insertar Roles si no hay ninguno
            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { Name = "Admin" },
                    new Role { Name = "Cliente" },
                    new Role { Name = "Empleado" }
                };

                context.Set<Role>().AddRange(roles);
                context.SaveChanges();
            }

            // Insertar Usuarios si no hay ninguno
            if (!context.Users.Any())
            {
                var faker = new Faker("es");

                // Obtener el rol "Cliente" para asignarlo a los usuarios
                var clienteRole = context.Roles.First(r => r.Name == "Cliente");

                var users = new Faker<User>()
                    .RuleFor(u => u.FullName, f => f.Name.FirstName())
                    .RuleFor(u => u.LastName, f => f.Name.LastName())
                    .RuleFor(u => u.Email, f => f.Internet.Email())
                    .RuleFor(u => u.PasswordHash, "hashed_password_placeholder")
                    .RuleFor(u => u.Address, f => f.Address.FullAddress())
                    .RuleFor(u => u.PhoneNumber, f => f.Phone.PhoneNumber())
                    .RuleFor(u => u.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-18)))
                    .RuleFor(u => u.RegistrationDate, DateTime.Now)
                    .RuleFor(u => u.RoleId, clienteRole.Id)
                    .RuleFor(u => u.Role, clienteRole)
                    .Generate(10);

                context.Set<User>().AddRange(users);
                context.SaveChanges();
            }

            // Insertar Productos si no hay ninguno
            if (!context.Products.Any())
            {
                var faker = new Faker("es");

                var products = new Faker<Product>()
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.Category, f => f.Commerce.Department())
                    .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                    .RuleFor(p => p.Price, f => f.Random.Decimal(5000, 50000))
                    .RuleFor(p => p.Brand, f => f.Company.CompanyName())
                    .RuleFor(p => p.Stock, f => f.Random.Int(10, 200))
                    .RuleFor(p => p.State, f => f.PickRandom(new[] { "Disponible", "Agotado", "En tránsito" }))
                    .RuleFor(p => p.Urls, f => new[]
                    {
                        "https://res.cloudinary.com/demo/image/upload/sample1.jpg",
                        "https://res.cloudinary.com/demo/image/upload/sample2.jpg",
                        "https://res.cloudinary.com/demo/image/upload/sample3.jpg"
                    })
                    .Generate(10);

                context.Set<Product>().AddRange(products);
                context.SaveChanges();
            }
        }
    }
}

