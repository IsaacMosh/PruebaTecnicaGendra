using NetCoreGendra.Models;

namespace NetCoreGendra.Services
{
    public interface IServicio_Producto
    {
        Task<List<Producto>> ConsultarProductos();
        Task<Producto> GuardarProducto(Producto producto);
        Task<Producto> ActualizarProducto(Producto producto);
        Task<bool> EliminarProducto(int idproducto);
    }
}
