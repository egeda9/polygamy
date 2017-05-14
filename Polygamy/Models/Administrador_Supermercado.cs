namespace Polygamy.Models
{
    public class Administrador_Supermercado : Persona
    {
        private Supermercado supermercado;

        public Administrador_Supermercado()
        {

        }

        ~Administrador_Supermercado()
        {

        }

        public Supermercado getSupermercado()
        {
            return supermercado;
        }

        public void setSupermercado(Supermercado supermercado)
        {
            this.supermercado = supermercado;
        }
    }
}
