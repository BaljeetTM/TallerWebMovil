using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITaller1.src.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int CartId { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }
    }
}