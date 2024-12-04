using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSemestral.Models
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;
        public string pass { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;

        public List<Libros> libros { get; set; }
    }
}
