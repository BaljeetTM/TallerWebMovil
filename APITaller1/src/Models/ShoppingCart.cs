using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITaller1.src.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public List<ShoppingCartItem>? Items { get; set; }
    }
}