using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITaller1.src.Models
{
    public class Client
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string lastName { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }
        public required string address { get; set; }
        public required string phoneNumber { get; set; }
    }
}