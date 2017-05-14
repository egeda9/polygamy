using System.Collections.Generic;

namespace Polygamy.Models
{
    public class Permiso
    {
        private int id;
        private string nombre;
        private List<Rol> roles;

        public Permiso()
        {

        }

        ~Permiso()
        {

        }

        public virtual void Dispose()
        {

        }

        /// 
        /// <param name="rol"></param>
        public List<Rol> agregarRol(Rol rol)
        {
            return null;
        }

        /// 
        /// <param name="rol"></param>
        public List<Rol> removerRol(Rol rol)
        {
            return null;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public List<Rol> getRoles()
        {
            return roles;
        }

        public void setRoles(List<Rol> roles)
        {
            this.roles = roles;
        }
    }
}
