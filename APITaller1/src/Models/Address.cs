using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITaller1.src.Models
{
    public class Address
    {
        public int Id { get; set; }
        public required string Street { get; set; }
        public required string Number { get; set; }
        public required string Commune { get; set; }
        public required string Region { get; set; }
        public required string PostalCode { get; set; }
        public bool IsDefault { get; set; } = true;

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}