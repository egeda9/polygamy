using System;
using System.ComponentModel.DataAnnotations;

namespace Polygamy.Models
{
    public class Beneficiario : Persona
    {
        private bool activo;
        private float cupo;
        private DateTime fechaCompraFin;
        private DateTime fechaCompraInicio;

        public Beneficiario()
        {

        }

        public bool Activo
        {
            get => activo;
            set => activo = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El cupo es obligatorio")]
        public float Cupo
        {
            get => cupo;
            set => cupo = value;
        }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de fin de compra es obligatoria")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Final de Compra")]
        public DateTime FechaCompraFin
        {
            get => fechaCompraFin;
            set => fechaCompraFin = value;
        }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha de inicio de compra es obligatoria")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Inicial de Compra")]
        public DateTime FechaCompraInicio
        {
            get => fechaCompraInicio;
            set => fechaCompraInicio = value;
        }
    }
}
