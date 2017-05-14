using Dapper;
using Microsoft.Extensions.Options;
using Polygamy.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Polygamy.Data
{
    public class AfiliadoGateway
    {
        private readonly IOptions<AppSettings> _databaseSettings;
        
        public AfiliadoGateway(IOptions<AppSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        /// 
        /// <param name="afiliado"></param>
        public void actualizar(Afiliado afiliado)
        {

        }

        /// 
        /// <param name="afiliado"></param>
        public void crear(Afiliado afiliado)
        {

        }

        /// 
        /// <param name="id"></param>s
        public void eliminar(int id)
        {

        }

        public List<Afiliado> listar()
        {
            List<Afiliado> afiliados = new List<Afiliado>();
            using (IDbConnection conexionSql = new SqlConnection(_databaseSettings.Value.DefaultConnection))
            {
                conexionSql.Open();
                string consulta = "SELECT p.id" +
                                  " , p.identificacion" +
                                  " ,p.nombres" +
                                  " ,p.apellidos" +
                                  " ,p.ciudadResidencia" +
                                  " ,p.direccionResidencia" +
                                  " ,p.numeroTelefono" +
                                  " ,p.email" +
                                  " ,a.cupo" +
                                  " FROM Persona p" +
                                  " INNER JOIN Afiliado a ON a.idPersona = p.id";

                afiliados = conexionSql.Query<Afiliado>(consulta).ToList();
                conexionSql.Close();
            }
            return afiliados;
        }

        /// 
        /// <param name="id"></param>
        public Afiliado obtener(int id)
        {
            return null;
        }
    }
}
