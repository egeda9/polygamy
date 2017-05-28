namespace Polygamy.Models
{
    public class Administrador_Supermercado : Persona
    {
        public Administrador_Supermercado()
        {

        }

        public int idAdministrador { get; set; }

        public Supermercado supermercado { get; set; }        
    }
}
