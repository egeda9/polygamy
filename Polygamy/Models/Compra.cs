using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public float total { get; set; }

        [Display(Name = "Supermercado")]
        public Supermercado supermercado { get; set; }        

        /// 
        /// <param name="compraDetalle"></param>
        public List<CompraDetalle> agregarCompraDetalle(CompraDetalle compraDetalle)
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
