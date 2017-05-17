using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Polygamy.Models
{
    public class Afiliado : Persona
    {
        private List<Beneficiario> beneficiarios;
        private float cupo;

        public Afiliado()
        {

        }

        public List<Beneficiario> Beneficiarios
        {
            get => beneficiarios;
            set => beneficiarios = value;
        }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "El cupo es obligatorio")]
        public float Cupo
        {
            get => cupo;
            set => cupo = value;
        }

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
