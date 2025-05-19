namespace APITaller1.src.Dtos.User
{
    public class UserDto
    {
        public string FullName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string RoleName { get; set; } = string.Empty;

        public List<AddressDto>? Addresses { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }


    }
}