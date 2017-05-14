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

        public int Identificacion
        {
            get => identificacion;
            set => identificacion = value;
        }

        public string Nombres
        {
            get => nombres;
            set => nombres = value;
        }

        public string Apellidos
        {
            get => apellidos;
            set => apellidos = value;
        }

        public long NumeroTelefono
        {
            get => numeroTelefono;
            set => numeroTelefono = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public string DireccionResidencia
        {
            get => direccionResidencia;
            set => direccionResidencia = value;
        }

        public string CiudadResidencia
        {
            get => ciudadResidencia;
            set => ciudadResidencia = value;
        }
    }
}
