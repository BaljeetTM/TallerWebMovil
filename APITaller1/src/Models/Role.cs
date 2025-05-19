using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITaller1.src.Models
{
    public class Role
    {
        public int Id { get; set; }

        public required string Name { get; set; } // Ej: "Cliente", "Admin", "No autenticado"

        public List<User>? Users { get; set; } // Un rol puede tener muchos usuarios
    }
}