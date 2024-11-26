using Microsoft.AspNetCore.Mvc;
using pruebaAPI_BD.Datos;
using pruebaAPI_BD.Models;

namespace pruebaAPI_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        [HttpGet]
        [Route("TotalLibros")]
        public List<Libro> TotaldeLibros()
        {
            return new Db().ObtenerLibros();
        }
    }
}
