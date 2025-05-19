namespace APITaller1.src.Dtos
{
    public class AddressDto
    {
        public required string Street { get; set; } = default!;
        public required string Number { get; set; } = default!;
        public required string Commune { get; set; } = default!;
        public required string Region { get; set; } = default!;
        public required string PostalCode { get; set; } = default!;
    }
}