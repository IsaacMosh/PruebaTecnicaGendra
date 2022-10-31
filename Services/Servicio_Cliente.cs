using NetCoreGendra.Models;
using Newtonsoft.Json;
using System.Text;

namespace NetCoreGendra.Services
{
    public class Servicio_Cliente : IServicio_Cliente
    {
        private string _baseurl = "http://localhost8080/";

        public async Task<Cliente> ActualizarCliente(Cliente objeto)
        {
            Cliente clienteActualizado = new Cliente();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await client.PutAsync("cliente/actualizarCliente/", content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                clienteActualizado = resultado;
            }

            return clienteActualizado;
        }

        public async Task<List<Cliente>> ConsultarClientes()
        {
            List<Cliente> listaCliente = new List<Cliente>();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var response = await client.GetAsync("cliente/consultarCliente");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                listaCliente = resultado.lista;
            }

            return listaCliente;
        }

        public async Task<bool> EliminarCliente(int idCliente)
        {
            bool respuesta = false;

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);           

            var response = await client.DeleteAsync($"cliente/eliminarCliente/{idCliente}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<Cliente> GuardarCliente(Cliente objeto)
        {
            Cliente clienteNuevo = new Cliente();

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("cliente/guardarCliente/",content);

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                clienteNuevo = resultado;
            }

            return clienteNuevo;
        }
    }
}
