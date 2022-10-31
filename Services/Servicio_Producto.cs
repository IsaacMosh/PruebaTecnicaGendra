using NetCoreGendra.Models;
using Newtonsoft.Json;
using System.Text;

namespace NetCoreGendra.Services
{
    public class Servicio_Producto : IServicio_Producto
    {
        private string _baseurl = "http://localhost8080/";

        public async Task<Producto> ActualizarProducto(Producto objeto)
        {
            Producto productoActualizado = new Producto();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await client.PutAsync("producto/actualizarProducto/", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_respuesta);
                productoActualizado = resultado;
            }

            return productoActualizado;
        }

        public async Task<List<Producto>> ConsultarProductos()
        {
            List<Producto> listaProducto = new List<Producto>();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var response = await client.GetAsync("producto/consultarProducto");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_respuesta);
                listaProducto = resultado.lista;
            }

            return listaProducto;
        }

        public async Task<bool> EliminarProducto(int idproducto)
        {
            bool respuesta = false;

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var response = await client.DeleteAsync($"producto/eliminarProducto/{idproducto}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<Producto> GuardarProducto(Producto objeto)
        {
            Producto productoNuevo = new Producto();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("producto/guardarProducto/", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_respuesta);
                productoNuevo = resultado;
            }

            return productoNuevo;
        }
    }
}
