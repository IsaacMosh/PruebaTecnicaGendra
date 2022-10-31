namespace NetCoreGendra.Models
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public int frecuente { get; set; }
        public List<Cliente> lista { get; set; }
    }
}
