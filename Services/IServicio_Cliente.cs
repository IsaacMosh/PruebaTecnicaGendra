using NetCoreGendra.Models;

namespace NetCoreGendra.Services
{
    public interface IServicio_Cliente
    {
        Task<List<Cliente>> ConsultarClientes();
        Task<Cliente> GuardarCliente(Cliente cliente);
        Task<Cliente> ActualizarCliente(Cliente cliente);
        Task<bool> EliminarCliente(int idCliente);
    }
}
