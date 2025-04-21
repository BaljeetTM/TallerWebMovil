using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using APITaller1.src.Models;

using Microsoft.EntityFrameworkCore;

namespace APITaller1.src.Data
{
    public class StoreContext(DbContextOptions options) : DbContext(options)
    {
        public required DbSet<Product> Products { get; set; }
        public required DbSet<User> Clients { get; set; }
        public required DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public required DbSet<Address> Addresses { get; set; }
        public required DbSet<DeactivationReason> DeactivationReasons { get; set; }
        public required DbSet<Order> Orders { get; set; }
        public required DbSet<OrderItem> OrderItems { get; set; }
        public required DbSet<Role> Roles { get; set; }
        public required DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public required DbSet<ProductImage> ProductImages { get; set; }

    }

}