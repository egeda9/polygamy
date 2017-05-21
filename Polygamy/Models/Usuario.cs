using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Polygamy.Models
{
    public class Usuario : Persona
    {
        public Usuario()
        {

        }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string contrasena { get; set; }

        [Display(Name = "Nombre de Usuario")]
        [Required(ErrorMessage = "El Nombre de Usuario es obligatorio")]
        public string nombreUsuario { get; set; }

        public Rol rol { get; set; }

        private const string regexPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";

        /// 
        /// <param name="contrasena"></param>
        public bool comprobarContrasenaSegura()
        {
            Regex regex = new Regex(regexPassword);
            return regex.IsMatch(contrasena);
        }
    }
}
