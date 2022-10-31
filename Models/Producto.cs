namespace NetCoreGendra.Models
{
    public class Producto
    {
        public int idproducto { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public List<Producto> lista { get; set; }
    }
}
