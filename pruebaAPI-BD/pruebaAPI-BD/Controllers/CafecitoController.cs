using Microsoft.AspNetCore.Mvc;
using pruebaAPI_BD.Datos;
using pruebaAPI_BD.Models;

namespace pruebaAPI_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafecitoController : ControllerBase
    {
        [HttpGet]
        [Route("TotalCafes")]
        public List<Cafe> ObtenerCafes()
        {
            return new Db().ObtenerCafe();
        }
    }
}
