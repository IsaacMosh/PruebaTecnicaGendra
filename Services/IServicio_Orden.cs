using NetCoreGendra.Models;

namespace NetCoreGendra.Services
{
    public interface IServicio_Orden
    {
        Task<List<Orden>> ConsultarOrdenes();
        Task<Orden> GuardarOrden(Orden orden);
        Task<Orden> ActualizarOrden(Orden orden);
        Task<bool> EliminarOrden(int idorden);
    }
}
