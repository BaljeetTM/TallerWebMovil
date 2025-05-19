namespace APITaller1.src.Dtos.Product
{
    public class ProductResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string Category { get; set; } = null!;

        public int Stock { get; set; }

        public string Brand { get; set; } = null!;

        public string State { get; set; } = null!;

        public bool Visible { get; set; }

        public List<string>? ImageUrls { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}