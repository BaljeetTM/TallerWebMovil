using System.ComponentModel.DataAnnotations;

namespace APITaller1.src.Dtos.User
{
    public class CreateUserDto
    {
        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public int RoleId { get; set; }

        public List<AddressDto>? Addresses { get; set; }
    }

}