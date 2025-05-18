using System.ComponentModel.DataAnnotations;
namespace APITaller1.src.Dtos.User
{
    public class LoginDto
    {
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
    }
}