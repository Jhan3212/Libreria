using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaWithAPI.Models
{
    public class Cafe
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; } = string.Empty;

        public double precio { get; set; }

        public string marca { get; set; }

    }
}
