namespace Polygamy.Models
{
    public class Cajero_Supermercado : Persona
    {
        private int numeroCaja;
        private Supermercado supermercado;

        public Cajero_Supermercado()
        {

        }

        ~Cajero_Supermercado()
        {

        }

        public int getNumeroCaja()
        {
            return numeroCaja;
        }

        public void setNumeroCaja(int numeroCaja)
        {
            this.numeroCaja = numeroCaja;
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
