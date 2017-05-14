namespace Polygamy.Models
{
    public class CompraDetalle
    {
        private int cantidad;
        private int id;
        private Producto producto;

        public CompraDetalle()
        {

        }

        ~CompraDetalle()
        {

        }

        public virtual void Dispose()
        {

        }

        public int getCantidad()
        {
            return cantidad;
        }

        public void setCantidad(int cantidad)
        {
            this.cantidad = cantidad;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public Producto getProducto()
        {
            return producto;
        }

        public void setProducto(Producto producto)
        {
            this.producto = producto;
        }
    }
}
