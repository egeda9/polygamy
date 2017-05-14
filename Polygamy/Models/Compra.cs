using System;
using System.Collections.Generic;

namespace Polygamy.Models
{
    public class Compra
    {
        private Beneficiario beneficiario;
        private List<CompraDetalle> compraDetalles;
        private DateTime fecha;
        private int id;
        private Supermercado supermercado;
        private float total;

        public Compra()
        {

        }

        ~Compra()
        {

        }

        public virtual void Dispose()
        {

        }

        /// 
        /// <param name="compraDetalle"></param>
        public List<CompraDetalle> agregarCompraDetalle(CompraDetalle compraDetalle)
        {

            return null;
        }

        /// 
        /// <param name="fechaFin"></param>
        /// <param name="fechaInicio"></param>
        public List<Compra> obtenerReporte(DateTime fechaFin, DateTime fechaInicio)
        {
            return null;
        }

        /// 
        /// <param name="compraDetalle"></param>
        public List<CompraDetalle> removerCompraDetalle(CompraDetalle compraDetalle)
        {
            return null;
        }

        public Beneficiario getBeneficiario()
        {
            return beneficiario;
        }

        public void setBeneficiario(Beneficiario beneficiario)
        {
            this.beneficiario = beneficiario;
        }

        public DateTime getFecha()
        {
            return fecha;
        }

        public void setFecha(DateTime fecha)
        {
            this.fecha = fecha;
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public Supermercado getSupermercado()
        {
            return supermercado;
        }

        public void setSupermercado(Supermercado supermercado)
        {
            this.supermercado = supermercado;
        }

        public float getTotal()
        {
            return total;
        }

        public void setTotal(float total)
        {
            this.total = total;
        }

        public List<CompraDetalle> getCompraDetalles()
        {
            return compraDetalles;
        }

        public void setCompraDetalles(List<CompraDetalle> compraDetalles)
        {
            this.compraDetalles = compraDetalles;
        }
    }
}
