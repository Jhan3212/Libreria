using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        //obtiene todos los libros
        public async Task<List<Libros>> ObtenerTodosLosLibritos()
        {
            HttpClient client = new HttpClient();
            try
            {
                var respuesta = await client.GetAsync("https://localhost:7061/api/Libros/alls");

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

        public async Task<ApiRespuesta> IngresarLibro(LibrosRequest libro)
        {
            using (HttpClient client = new HttpClient())
            {
                var datos = JsonConvert.SerializeObject(libro);
                var data = new StringContent(datos, Encoding.UTF8, "application/json");


                // Realizar la solicitud HTTP POST
                var respuesta = await client.PostAsync("https://localhost:7061/api/Libros/Save", data);

                // Asegurar que la respuesta fue exitosa
                respuesta.EnsureSuccessStatusCode();

                // Leer la respuesta y deserializarla como ApiRespuesta
                var contenido = await respuesta.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ApiRespuesta>(contenido);
            }
        }

        //este metodo sirve para editar un libro
        public async Task<T> EditarLibro<T>(int id, LibrosRequest libros)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Serializamos los datos de cliente en formato JSON
                    var datos = JsonConvert.SerializeObject(libros);
                    var data = new StringContent(datos, Encoding.UTF8, "application/json");


                    // Realizar la solicitud HTTP PUT
                    var respuesta = await client.PutAsync($"https://localhost:7061/api/Libros/Update/{id}", data);

                    // Asegurar que la respuesta fue exitosa
                    if (!respuesta.IsSuccessStatusCode)
                    {
                        var errorContenido = await respuesta.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error del API:\n{respuesta.StatusCode} - {errorContenido}", "Error del API");
                        throw new Exception($"Error al llamar al API: {respuesta.StatusCode}");
                    }

                    // Leer la respuesta y deserializarla
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    MessageBox.Show($"Respuesta del API:\n{contenido}", "Respuesta del API");
                    return JsonConvert.DeserializeObject<T>(contenido);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error");
                    throw;
                }
            }
        }



        public static async Task<string> EliminarLibro(int idlibro)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7061/api/Libros/Delete/{idlibro}";
                HttpResponseMessage respuesta = await client.DeleteAsync(url);

                if (respuesta.IsSuccessStatusCode)
                {
                    // Solo retornamos el contenido como texto
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    return contenido;  // Devuelve el contenido como texto (mensaje de la API)
                }
                else
                {
                    // Si la solicitud falla, devolvemos el error
                    return $"Error en la solicitud: {respuesta.StatusCode}";
                }
            }
        }
    }
}
