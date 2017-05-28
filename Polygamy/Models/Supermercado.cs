namespace Polygamy.Models
{
    public class Supermercado
    {
        public Supermercado()
        {

        }

        public string ciudad { get; set; }
        public int id { get; set; }
        public string direccion { get; set; }
        public Red_Supermercado redSupermercado { get; set; }
    }
}
