namespace NetCoreGendra.Models
{
    public class Orden
    {
        public int idorden { get; set; }
        public int idCliente { get; set; }
        public int idproducto { get; set; }
        public string observaciones { get; set; }
        public List<Orden> lista { get; set; }

    }
}
