namespace Polygamy.Models
{
    public class Usuario : Persona
    {
        public string contrasena;
        public string nombreUsuario;
        public Rol rol;

        public Usuario()
        {

        }

        ~Usuario()
        {

        }

        /// 
        /// <param name="contrasena"></param>
        public bool comprobarContrasenaSegura(string contrasena)
        {
            return false;
        }

        /// 
        /// <param name="contrasena"></param>
        /// <param name="usuario"></param>
        public bool comprobarUsuarioYContrasena(string contrasena, string usuario)
        {
            return false;
        }

        public string getContrasena()
        {
            return contrasena;
        }

        public void setContrasena(string contrasena)
        {
            this.contrasena = contrasena;
        }

        public string getNombreUsuario()
        {
            return nombreUsuario;
        }

        public void setNombreUsuario(string nombreUsuario)
        {
            this.nombreUsuario = nombreUsuario;
        }

        public Rol getRol()
        {
            return rol;
        }

        public void setRol(Rol rol)
        {
            this.rol = rol;
        }
    }
}
