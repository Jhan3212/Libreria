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
    public class UserService
    {

        public async Task<List<Cliente>> ObtenerTodosLosUsuariosNegros()
        {
            HttpClient client = new HttpClient();
            try
            {
                var respuesta = await client.GetAsync("https://localhost:7061/api/Users/all");

                // Validar si la respuesta es exitosa
                if (!respuesta.IsSuccessStatusCode)
                {
                    throw new Exception($"Error al obtener todos los usuarios: {respuesta.StatusCode}");
                }

                // Leer y deserializar el contenido de la respuesta
                var contenido = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Cliente>>(contenido) ?? new List<Cliente>();
            }
            catch (Exception ex)
            {
                // Manejo de excepciones (puedes loguear el error aquí)
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                return new List<Cliente>(); // Retornar una lista vacía en caso de error
            }
        }

        public static async Task<List<Users>> ObtenerTodosLosUsuarios(UserRequest _usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7061/api/Users/Validate/{_usuario.Name}/{_usuario.Password}";
                HttpResponseMessage respuesta = await client.GetAsync(url);

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Users>>(contenido);
                }
                else
                {
                    throw new Exception($"Error en la solicitud: {respuesta.StatusCode}");
                }
            }
        }

        public static async Task<List<Cliente>> ObtenerTodosLosClientes(Cliente _cliente)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7061/api/Users/Client/{_cliente.nombre}/{_cliente.pass}";
                HttpResponseMessage respuesta = await client.GetAsync(url);

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = await respuesta.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Cliente>>(contenido);
                }
                else
                {
                    throw new Exception($"Error en la solicitud: {respuesta.StatusCode}");
                }
            }
        }

        public async Task<T> RegistrarCliente<T>(ClienteRequest cliente)
        {
            using (HttpClient client = new HttpClient())
            {
                var datos = JsonConvert.SerializeObject(cliente);
                var data = new StringContent(datos, Encoding.UTF8, "application/json");

                // Realizar la solicitud HTTP POST
                var respuesta = await client.PostAsync("https://localhost:7061/api/Users/InsertClient", data);

                // Asegurar que la respuesta fue exitosa
                respuesta.EnsureSuccessStatusCode();

                // Leer la respuesta y deserializarla
                var contenido = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(contenido);
            }
        }

        //este metodo sirve para editar el cliente
        public async Task<T> EditarCliente<T>(int id, ClienteRequest cliente)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Serializamos los datos de cliente en formato JSON
                    var datos = JsonConvert.SerializeObject(cliente);
                    var data = new StringContent(datos, Encoding.UTF8, "application/json");


                    // Realizar la solicitud HTTP PUT
                    var respuesta = await client.PutAsync($"https://localhost:7061/api/Users/EditClient/{id}", data);

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




        //metodo para eliminar cliente
        public static async Task<string> EliminarCliente(int clienteId)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://localhost:7061/api/Users/DeleteClient/{clienteId}";
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
