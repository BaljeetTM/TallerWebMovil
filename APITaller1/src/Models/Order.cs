using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITaller1.src.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        public int AddressId { get; set; }
        public Address? Address { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Total { get; set; }
        public List<OrderItem>? Items { get; set; }
    }
}