using System.Collections.Generic;

namespace Polygamy.Models
{
    public class Red_Supermercado
    {
        public Red_Supermercado()
        {

        }

        public int id { get; set; }
        public string nombre { get; set; }
        public List<Supermercado> supermercados { get; set; }

        public List<Supermercado> agregarSupermercado(Supermercado supermercado)
        {
            return null;
        }

        public List<Supermercado> removerSupermercado(Supermercado supermercado)
        {
            return null;
        }
    }
}
