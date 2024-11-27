using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSemestral.Models 
{
    public class LogueoUsuarioAdmin
    {
        public string Id { get; set; }
        public string Password { get; set; }
    }

    public class RespuestaLogin
    {
        public string Status { get; set; }
        public string Role { get; set; } 
        public string Message { get; set; }
    }

}
