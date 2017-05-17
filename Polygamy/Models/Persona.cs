using System.ComponentModel.DataAnnotations;

namespace Polygamy.Models
{
    public class Persona
    {
        private int id;
        private int identificacion;
        private string nombres;
        private string apellidos;
        private long numeroTelefono;
        private string email;
        private string direccionResidencia;
        private string ciudadResidencia;        

        public Persona()
        {

        }

        public int Id
        {
            get => id;
            set => id = value;
        }
        
        [Display(Name = "Identificación")]
        [Required(ErrorMessage = "El número de identificación es obligatorio")]
        public int Identificacion
        {
            get => identificacion;
            set => identificacion = value;
        }

        [Required(ErrorMessage = "Los nombres son obligatorios")]
        public string Nombres
        {
            get => nombres;
            set => nombres = value;
        }

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        public string Apellidos
        {
            get => apellidos;
            set => apellidos = value;
        }

        [Display(Name = "Número Telefono")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "El número de telefono es obligatorio")]
        public long NumeroTelefono
        {
            get => numeroTelefono;
            set => numeroTelefono = value;
        }

        [EmailAddress]
        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email
        {
            get => email;
            set => email = value;
        }

        [Display(Name = "Dirección de Residencia")]
        public string DireccionResidencia
        {
            get => direccionResidencia;
            set => direccionResidencia = value;
        }

        [Display(Name = "Ciudad de Residencia")]
        public string CiudadResidencia
        {
            get => ciudadResidencia;
            set => ciudadResidencia = value;
        }
    }
}
