namespace Polygamy.Models
{
    public class Supermercado
    {
        public string ciudad;
        public int codigo;
        public string direccion;

        public Supermercado()
        {

        }

        ~Supermercado()
        {

        }

        public int getCodigo()
        {
            return codigo;
        }

        public void setCodigo(int codigo)
        {
            this.codigo = codigo;
        }

        public string getCiudad()
        {
            return ciudad;
        }

        public void setCiudad(string ciudad)
        {
            this.ciudad = ciudad;
        }

        public string getDireccion()
        {
            return direccion;
        }

        public void setDireccion(string direccion)
        {
            this.direccion = direccion;
        }
    }
}
