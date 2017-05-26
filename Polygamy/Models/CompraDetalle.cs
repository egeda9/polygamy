using System.ComponentModel.DataAnnotations;

namespace Polygamy.Models
{
    public class CompraDetalle
    {
        public CompraDetalle()
        {

        }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "La cantidad es obligatoria")]
        public int cantidad { get; set; }

        public int id { get; set; }

        [Display(Name = "Producto")]
        public Producto producto { get; set; }

        public Compra compra { get; set; }
    }
}
