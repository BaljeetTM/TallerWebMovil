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
        public required DbSet<Client> Clients { get; set; }
        public required DbSet<ShoppingCart> ShoppingCarts { get; set; }

    }

}