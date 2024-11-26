using Microsoft.AspNetCore.Mvc;
using pruebaAPI_BD.Datos;
using pruebaAPI_BD.Models;

namespace pruebaAPI_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {

        //este esta hecho para obtener todos los libros
        [HttpGet]
        [Route("TotalLibros")]
        public List<Libro> TotaldeLibros()
        {
            return new Db().ObtenerLibros();
        }

        //esto esta hecho para obtener un libro mediante el id
        [HttpGet]
        [Route("Search/{_idlibro}")]
        public List<Libro> ObtenerLibrito(string _idlibro)
        {
            return new Db().DameUnLibro(_idlibro);
        }


    }
}
