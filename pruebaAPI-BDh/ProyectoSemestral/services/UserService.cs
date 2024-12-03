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
    public class UserService
    {
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


    }
}
