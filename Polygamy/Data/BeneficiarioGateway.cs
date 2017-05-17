using Dapper;
using Microsoft.Extensions.Options;
using Polygamy.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Polygamy.Data
{
    public class BeneficiarioGateway
    {
        private readonly IOptions<AppSettings> _databaseSettings;

        public BeneficiarioGateway(IOptions<AppSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        /// 
        /// <param name="beneficiario"></param>
        public void actualizar(Beneficiario beneficiario)
        {

        }

        /// 
        /// <param name="beneficiario"></param>
        public void crear(Beneficiario beneficiario)
        {

        }

        /// 
        /// <param name="id"></param>
        public void eliminar(int id)
        {

        }

        public List<Beneficiario> listar()
        {
            List<Beneficiario> beneficiarios = new List<Beneficiario>();
            using (IDbConnection conexionSql = new SqlConnection(_databaseSettings.Value.DefaultConnection))
            {
                conexionSql.Open();
                string consulta = "SELECT p.id" +
                                  " ,p.identificacion" +
                                  " ,p.nombres" +
                                  " ,p.apellidos" +
                                  " ,p.ciudadResidencia" +
                                  " ,p.direccionResidencia" +
                                  " ,p.numeroTelefono" +
                                  " ,p.email" +
                                  " ,b.cupo" +
                                  " ,b.fechaCompraInicio" +
                                  " ,b.fechaCompraFin" +
                                  " ,b.activo" +
                                  " FROM Persona p" +
                                  " INNER JOIN Beneficiario b ON b.idPersona = p.id";

                beneficiarios = conexionSql.Query<Beneficiario>(consulta).ToList();
                conexionSql.Close();
            }
            return beneficiarios;
        }

        /// 
        /// <param name="id"></param>
        public Beneficiario obtener(int id)
        {
            return null;
        }
    }
}
