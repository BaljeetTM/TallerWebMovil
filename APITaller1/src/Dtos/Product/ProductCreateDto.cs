using System.ComponentModel.DataAnnotations;

namespace APITaller1.src.Dtos.Product
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string Category { get; set; } = null!;

        public int Stock { get; set; }

        [Required]
        public string Brand { get; set; } = null!;

        public string State { get; set; } = "Nuevo";

        public List<IFormFile>? Images { get; set; }
    }
}
