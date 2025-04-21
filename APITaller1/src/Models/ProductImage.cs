using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITaller1.src.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public required string Url { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}