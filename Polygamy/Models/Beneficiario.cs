using System;
using System.ComponentModel.DataAnnotations;

namespace Polygamy.Models
{
    public class Beneficiario : Persona
    {
        public Beneficiario()
        {

        }

        [Display(Name = "Activo")]
        public bool activo { get; set; }

        [Display(Name = "Cupo (COP)")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "El cupo es obligatorio")]
        public float cupo { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de fin de compra es obligatoria")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Final de Compra")]
        public DateTime fechaCompraFin { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de inicio de compra es obligatoria")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Inicial de Compra")]
        public DateTime fechaCompraInicio { get; set; }

        [Display(Name = "Afiliado")]
        public Afiliado afiliado { get; set; }
    }
}
