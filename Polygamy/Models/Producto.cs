namespace Polygamy.Models
{
    public class Producto
    {
        private int codigo;
        private string descripcion;
        private float precioUnitario;

        public Producto()
        {

        }

        ~Producto()
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

        public string getDescripcion()
        {
            return descripcion;
        }

        public void setDescripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }

        public float getPrecioUnitario()
        {
            return codigo;
        }

        public void setPrecioUnitario(float precioUnitario)
        {
            this.precioUnitario = precioUnitario;
        }

        public virtual void Dispose()
        {

        }
    }
}
