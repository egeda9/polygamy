using System.Collections.Generic;

namespace Polygamy.Models
{
    public class Red_Supermercado
    {
        public int id;
        public string nombre;
        public List<Supermercado> supermercados;

        public Red_Supermercado()
        {

        }

        ~Red_Supermercado()
        {

        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public List<Supermercado> getSupermercados()
        {
            return supermercados;
        }

        public void setSupermercados(List<Supermercado> supermercados)
        {
            this.supermercados = supermercados;
        }

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
