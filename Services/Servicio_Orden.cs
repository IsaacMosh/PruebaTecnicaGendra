using NetCoreGendra.Models;
using Newtonsoft.Json;
using System.Text;

namespace NetCoreGendra.Services
{
    public class Servicio_Orden : IServicio_Orden
    {
        private string _baseurl = "http://localhost8080/";

        public async Task<Orden> ActualizarOrden(Orden objeto)
        {
            Orden ordenActualizado = new Orden();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await client.PutAsync("orden/actualizarOrden/", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Orden>(json_respuesta);
                ordenActualizado = resultado;
            }

            return ordenActualizado;
        }

        public async Task<List<Orden>> ConsultarOrdenes()
        {
            List<Orden> listaOrden = new List<Orden>();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var response = await client.GetAsync("orden/consultarOrden");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Orden>(json_respuesta);
                listaOrden = resultado.lista;
            }

            return listaOrden;
        }

        public async Task<bool> EliminarOrden(int idorden)
        {
            bool respuesta = false;

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var response = await client.DeleteAsync($"orden/eliminarOrden/{idorden}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<Orden> GuardarOrden(Orden objeto)
        {
            Orden ordenNuevo = new Orden();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("orden/guardarOrden/", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Orden>(json_respuesta);
                ordenNuevo = resultado;
            }

            return ordenNuevo;
        }
    }
}
