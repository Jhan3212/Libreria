using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PruebaWithAPI.Models;

namespace PruebaWithAPI.Services
{
    public class CafeService
    {
        public async Task<List<Cafe>> ObtenerTodosLosCafe()
        {
            HttpClient client = new HttpClient();
            var respuesta = await client.GetAsync("https://localhost:7061/api/Cafecito/TotalCafes");

            return JsonConvert.DeserializeObject<List<Cafe>>(respuesta.Content.ReadAsStringAsync().Result);
        }
    }
}
