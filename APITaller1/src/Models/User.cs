using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITaller1.src.Models
{
    public class User
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public required string FullName { get; set; }
        public required string lastName { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }
        public required string address { get; set; }
        public required string phoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public List<Address>? Addresses { get; set; }
        public ShoppingCart? Cart { get; set; }
        public List<Order>? Orders { get; set; }
        public required string PasswordHash { get; set; }
        public string[]? Urls { get; set; }
    }
}