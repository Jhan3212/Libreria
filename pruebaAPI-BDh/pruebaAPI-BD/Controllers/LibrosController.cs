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
        [Route("all")]
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

        //este esta hecho para realizar una insercion de un libro a la base de datos
        [HttpPost]
        [Route("Save")]
        public object GuardarLibro(LibroRequest libro)
        {
            var guardado = new Db().InsertarLibro(libro);
            if (guardado > 0)
                return new
                {
                    titulo = "Libro guardado con exito",
                    Mensaje = "nada exploto :)",
                };
            return new
            {
                titulo = "Error al guardar un libro",
                Mensaje = "mano que hiciste?",
            };
        }

        [HttpPut]
        [Route("Update/{_id}")]
        public object ActualizarLibro(int _id, LibroRequest _libro)
        {
            var guardado = new Db().ActualizarLibro(_id, _libro);
            if (guardado > 0)
                return new
                {
                    titulo = "Actualizacion exitosita",
                    Mensaje = "nada exploto :)",
                };
            return new
            {
                titulo = "Error todo murio",
                Mensaje = "mano que hiciste?",
            };
        }

        [HttpDelete]
        [Route("Delete/{_id}")]
        public object deleteLibro(int _id)
        {
            var guardado = new Db().EliminarLibro(_id);
            if (guardado > 0)
                return new
                {
                    titulo = "Eliminar ",
                    Mensaje = "nada exploto :)",
                };
            return new
            {
                titulo = "Error todo murio",
                Mensaje = "mano que hiciste?",
            };
        }

    }
}
