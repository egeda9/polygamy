using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Polygamy.Models
{
    public class Usuario : Persona
    {
        private string contrasena;
        private string nombreUsuario;
        private Rol rol;

        private string regexPassword = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";

        public Usuario()
        {

        }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Contrasena
        {
            get => contrasena;
            set => contrasena = value;
        }

        [Display(Name = "Nombre de Usuario")]
        [Required(ErrorMessage = "El Nombre de Usuario es obligatorio")]
        public string NombreUsuario
        {
            get => nombreUsuario;
            set => nombreUsuario = value;
        }

        public Rol Rol
        {
            get => rol;
            set => rol = value;
        }

        /// 
        /// <param name="contrasena"></param>
        public bool comprobarContrasenaSegura()
        {
            Regex regex = new Regex(regexPassword);
            return regex.IsMatch(contrasena);
        }
    }
}
