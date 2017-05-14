using System;

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

        ~Beneficiario()
        {

        }

        public bool getActivo()
        {
            return activo;
        }

        public void setActivo(bool activo)
        {
            this.activo = activo;
        }

        public float getCupo()
        {
            return cupo;
        }

        public void setCupo(float cupo)
        {
            this.cupo = cupo;
        }

        public DateTime getFechaCompraFin()
        {
            return fechaCompraFin;
        }

        public void setFechaCompraFin(DateTime DateTime)
        {
            this.fechaCompraFin = DateTime;
        }

        public DateTime getFechaCompraInicio()
        {
            return fechaCompraInicio;
        }

        public void setFechaCompraInicio(DateTime fechaCompraInicio)
        {
            this.fechaCompraInicio = fechaCompraInicio;
        }
    }
}
