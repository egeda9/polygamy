using System.ComponentModel.DataAnnotations;

namespace Polygamy.Models
{
    public class Persona
    {
        public Persona()
        {

        }

        public int id { get; set; }

        [Display(Name = "Identificación")]
        [Required(ErrorMessage = "El número de identificación es obligatorio")]
        public int identificacion { get; set; }

        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "Los nombres son obligatorios")]
        public string nombres { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        public string apellidos { get; set; }

        [Display(Name = "Número Telefono")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "El número de telefono es obligatorio")]
        public long numeroTelefono { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "El email es obligatorio")]
        public string email { get; set; }

        [Display(Name = "Dirección de Residencia")]
        public string direccionResidencia { get; set; }

        [Display(Name = "Ciudad de Residencia")]
        public string ciudadResidencia { get; set; }
    }
}
