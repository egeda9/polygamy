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
            using (IDbConnection conexionSql = new SqlConnection(_databaseSettings.Value.defaultConnection))
            {
                conexionSql.Open();

                string insertarPersona = "INSERT INTO Persona(identificacion, nombres, apellidos, numeroTelefono, email, direccionResidencia, ciudadResidencia) VALUES (@Identificacion, @Nombres, @Apellidos, @NumeroTelefono, @Email, @DireccionResidencia, @CiudadResidencia); " +
                                          "SELECT CAST(SCOPE_IDENTITY() as int)";
                string insertarAfiliado = "INSERT INTO Beneficiario(cupo, fechaCompraInicio, fechaCompraFin, idAfiliado, idPersona, activo) VALUES (@Cupo, @FechaCompraInicio, @FechaCompraFin, @IdAfiliado, @IdPersona, @Activo)";

                using (IDbTransaction transaccion = conexionSql.BeginTransaction())
                {
                    int personaId = conexionSql.Query<int>(insertarPersona, new { Identificacion = beneficiario.identificacion, Nombres = beneficiario.nombres, Apellidos = beneficiario.apellidos, NumeroTelefono = beneficiario.numeroTelefono, Email = beneficiario.email, DireccionResidencia = beneficiario.direccionResidencia, CiudadResidencia = beneficiario.ciudadResidencia }, transaccion).Single();
                    conexionSql.Execute(insertarAfiliado, new { Cupo = beneficiario.cupo, FechaCompraInicio = beneficiario.fechaCompraInicio, FechaCompraFin = beneficiario.fechaCompraFin, IdAfiliado = beneficiario.afiliado.idAfiliado, IdPersona = personaId, Activo = beneficiario.activo }, transaccion);
                    transaccion.Commit();
                }
                conexionSql.Close();
            }
        }

        /// 
        /// <param name="id"></param>
        public void eliminar(int id)
        {

        }

        public List<Beneficiario> listar()
        {
            List<Beneficiario> beneficiarios = new List<Beneficiario>();
            using (IDbConnection conexionSql = new SqlConnection(_databaseSettings.Value.defaultConnection))
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
