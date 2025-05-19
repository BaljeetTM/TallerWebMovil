using System.ComponentModel.DataAnnotations;


namespace APITaller1.src.Dtos.User
{
    public class UpdateUserDto
    {
        [Required]
        public int Id { get; set; }

        public string? FullName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? IsActive { get; set; }
    }
}