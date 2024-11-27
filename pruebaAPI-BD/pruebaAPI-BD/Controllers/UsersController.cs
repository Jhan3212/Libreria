using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MySqlConnector;
using pruebaAPI_BD.Datos;
using pruebaAPI_BD.Models;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    
    [HttpGet]
    [Route("Validate/{_nombreUser}/{_ContraUser}")]
    public List<Usuarios> ObtenerUnUsuario(string _nombreUser, string _ContraUser)
    {
         return new Db().ObtenerUsuario(_nombreUser, _ContraUser);

    }
    

}

