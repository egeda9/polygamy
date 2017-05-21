using System;
using System.Collections.Generic;

namespace Polygamy.Models
{
    public class Compra
    {
        public Compra()
        {

        }

        public Beneficiario beneficiario { get; set; }
        public List<CompraDetalle> compraDetalles { get; set; }
        public DateTime fecha { get; set; }
        public int id { get; set; }
        public Supermercado supermercado { get; set; }
        public float total { get; set; }

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
    }
}
