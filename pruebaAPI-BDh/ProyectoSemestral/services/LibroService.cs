using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProyectoSemestral.Models;

namespace ProyectoSemestral.Services
{
    public class LibroService
    {
        //obtiene todos los libros
        public async Task<List<Libros>> ObtenerTodosLosLibros()
        {
            HttpClient client = new HttpClient();
            try
            {
                var respuesta = await client.GetAsync("https://localhost:7061/api/Libros/all");

                // Validar si la respuesta es exitosa
                if (!respuesta.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al obtener libros: {respuesta.StatusCode}");
                }

                // Leer y deserializar el contenido de la respuesta
                var contenido = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Libros>>(contenido) ?? new List<Libros>();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones (puedes loguear el error aquí)
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                return new List<Libros>(); // Retornar una lista vacía en caso de error
            }
        }

        string baseUrl = "https://localhost:7061/api/Libros";

        public async Task<object> ComprarLibroAsync(int _idUser, int _idLibro)
        {
            using (HttpClient client = new HttpClient())
            {
                // Construir la URL con los parámetros
                string url = $"{baseUrl}/Buy/{_idUser}/{_idLibro}";

                // Enviar la solicitud GET
                HttpResponseMessage respuesta = await client.GetAsync(url);

                if (respuesta.IsSuccessStatusCode)
                {
                    // Leer y deserializar el contenido de la respuesta
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<object>(contenido);
                }
                else
                {
                    // Manejar errores de la solicitud
                    throw new Exception($"Error en la solicitud: {respuesta.StatusCode}");
                }
            }
        }

        public async Task<object> VenderLibroAsync(int _idLibro)
        {
            using (HttpClient client = new HttpClient())
            {
                // Construir la URL con los parámetros
                string url = $"{baseUrl}/Sale/{_idLibro}";

                // Enviar la solicitud GET
                HttpResponseMessage respuesta = await client.GetAsync(url);

                if (respuesta.IsSuccessStatusCode)
                {
                    // Leer y deserializar el contenido de la respuesta
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<object>(contenido);
                }
                else
                {
                    // Manejar errores de la solicitud
                    throw new Exception($"Error en la solicitud: {respuesta.StatusCode}");
                }
            }
        }

    }
}
