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
        public Role? Role { get; set; }
        public required string FullName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public List<Address>? Addresses { get; set; }
        public ShoppingCart? Cart { get; set; }
        public List<Order>? Orders { get; set; }

        public required string PasswordHash { get; set; }
        public bool IsActive { get; set; }
    }
}