namespace APITaller1.src.Dtos.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string CategoryName { get; set; } // Representa el nombre de la categoría relacionada
    }
}