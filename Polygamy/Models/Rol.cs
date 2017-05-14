using System.Collections.Generic;

namespace Polygamy.Models
{
    public class Rol
    {
        public string descripción;
        public int id;
        public List<Permiso> permisos;
        public string nombre;

        public Rol()
        {

        }

        ~Rol()
        {

        }

        public virtual void Dispose()
        {

        }

        /// 
        /// <param name="modulo"></param>
        public List<Permiso> agregarModulo(Permiso modulo)
        {
            return null;
        }

        /// 
        /// <param name="modulo"></param>
        public List<Permiso> removerModulo(Permiso modulo)
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

        public string getDescripcion()
        {
            return descripción;
        }

        public void setDescripcion(string descripción)
        {
            this.descripción = descripción;
        }

        public string getNombre()
        {
            return nombre;
        }

        public void setNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public List<Permiso> getPermisos()
        {
            return permisos;
        }

        public void setermisos(List<Permiso> permisos)
        {
            this.permisos = permisos;
        }
    }
}
