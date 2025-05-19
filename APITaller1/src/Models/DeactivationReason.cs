using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITaller1.src.Models
{
    public class DeactivationReason
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public required string Reason { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}