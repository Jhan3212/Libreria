using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MySqlConnector;
using pruebaAPI_BD.Datos;
using pruebaAPI_BD.Models;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    
    // Valida el usuario administrador
    [HttpGet]
    [Route("Validate/{_nombreUser}/{_ContraUser}")]
    public List<Usuarios> ObtenerUnUsuario(string _nombreUser, string _ContraUser)
    {
         return new Db().ObtenerUsuario(_nombreUser, _ContraUser);

    }

    // Obtiene un usuario cliente
    [HttpGet]
    [Route("Client/{_nombreUser}/{_contraUser}")]
    public List<Cliente> DameUnCliente(string _nombreUser, string _contraUser)
    {
        // Obtén la lista de clientes según las credenciales
        List<Cliente> clientes = new Db().ObtenerUnCliente(_nombreUser, _contraUser);

        // Llenar la lista de libros para cada cliente
        foreach (var cliente in clientes)
        {
            cliente.libros = LlenarLibrosRecursivamente(cliente.idCliente);
        }

        return clientes;
    }

    // esto llena la lista de libros
    private List<Libro> LlenarLibrosRecursivamente(int clienteId)
    {
        List<Libro> libros = new List<Libro>();

        try
        {
            // Obtener libros asociados a este cliente
            libros = new Db().ObtenerLibroXuser(clienteId);

            // Si deseas realizar operaciones adicionales en cada libro, puedes hacerlo aquí
        }
        catch (Exception ex)
        {
            throw new Exception("Error llenando los libros recursivamente", ex);
        }

        return libros;
    }



    // Inserta un cliente en la base datos
    [HttpPost]
    [Route("InsertClient")]
    public object InsertarUnCliente(ClienteRequest cliente)
    {
        var guardado = new Db().InsertarCliente(cliente);
        if (guardado > 0)
            return new
            {
                mensajito = "Todo bien pa :)"
            };
        return new
        {
            mensajito = "Todo exploto :V"
        };
    }

    //esto edita los atributos de un usuario
    [HttpPut]
    [Route("EditClient/{_id}")]
    public object EditarCafe(int _id, ClienteRequest _usuario)
    {
        var editado = new Db().ActualizarCliente(_id, _usuario);
        if (editado > 0)
            return new
            {
                
                Mensaje = "Cliente editado con exito"
                
            };
        return new
        {
            Mensaje = "Mano que hiciste, todo exploto :U ?"
            
        };
    }

    //elimina un usuario de la base de datos
    [HttpDelete]
    [Route("DeleteClient/{_id}")]
    public object BorrarCliente(int _id)
    {
        var guardado = new Db().EliminarCliente(_id);
        if (guardado > 0)
            return new
            {
                mensajito = "Eliminacion Exitosa, Casi Explota bro :)"
            };
        return new
        {
            mensajito = "EXPLOSIOOOOOON MURIO EL SERVER :("
        };
    }
}

