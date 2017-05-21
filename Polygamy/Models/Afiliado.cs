using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Polygamy.Models
{
    public class Afiliado : Persona
    {
        public Afiliado()
        {

        }

        public int idAfiliado { get; set; }

        public List<Beneficiario> beneficiarios { get; set; }

        [Display(Name = "Cupo (COP)")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "El cupo es obligatorio")]
        public float cupo { get; set; }

        /// 
        /// <param name="beneficiario"></param>
        public List<Beneficiario> agregarBeneficiario(Beneficiario beneficiario)
        {
            if (beneficiarios == null)
                beneficiarios = new List<Beneficiario>();

            beneficiarios.Add(beneficiario);

            return beneficiarios;
        }

        /// 
        /// <param name="beneficiario"></param>
        public List<Beneficiario> removerBeneficiario(Beneficiario beneficiario)
        {
            if (beneficiarios != null)
                beneficiarios.Remove(beneficiario);

            return beneficiarios;
        }
    }
}
