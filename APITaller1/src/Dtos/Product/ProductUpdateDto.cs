namespace APITaller1.src.Dtos.Product
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public string? Category { get; set; }

        public int? Stock { get; set; }

        public string? Brand { get; set; }

        public string? State { get; set; }

        public bool? Visible { get; set; }

        public List<IFormFile>? Images { get; set; }
    }
}
