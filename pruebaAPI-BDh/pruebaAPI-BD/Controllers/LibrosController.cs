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

        [HttpGet]
        [Route("alls")]
        public List<Libro> TotalitosLibritos()
        {
            return new Db().ObtenerTodosLibros();
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
            if (libro == null)
            {
                return new { titulo = "Error", Mensaje = "No se recibió el objeto libro." };
            }
            var guardado = new Db().InsertarLibro(libro);
            if (guardado > 0)
                return new { titulo = "Libro guardado con exito", Mensaje = "nada exploto :)" };
            return new { titulo = "Error al guardar un libro", Mensaje = "mano que hiciste?" };
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
                    titulo = "Eliminacion exitosa ",
                    Mensaje = "nada exploto :)",
                };
            return new
            {
                titulo = "Error todo murio",
                Mensaje = "mano que hiciste?",
            };
        }

        [HttpGet]
        [Route("Buy/{_idUser}/{_idLibro}")]
        public object ComproUnLibro(int _idUser, int _idLibro)
        {
            var guardado = new Db().compraLibro(_idUser, _idLibro);
            if (guardado > 0)
                return new
                {
                    titulo = "Compra Realizada ",
                    Mensaje = "nada exploto :)",
                };
            return new
            {
                titulo = "Compra Rechazada",
                Mensaje = "mano que hiciste?",
            };
        }

        [HttpGet]
        [Route("Sale/{_idLibro}")]
        public object VenderUnLibro(int _idLibro)
        {
            var guardado = new Db().venderLibro(_idLibro);
            if (guardado > 0)
                return new
                {
                    titulo = "Venta Realizada ",
                    Mensaje = "nada exploto :)",
                };
            return new
            {
                titulo = "Venta Rechazada",
                Mensaje = "mano que hiciste?",
            };
        }

    }
}
