using Dapper;
using Microsoft.Extensions.Options;
using Polygamy.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Polygamy.Data
{
    public class SupermercadoGateway
    {
        private readonly IOptions<AppSettings> _databaseSettings;

        public SupermercadoGateway(IOptions<AppSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        /// 
        /// <param name="supermercado"></param>
        public bool actualizar(Supermercado supermercado)
        {
            return true;
        }

        /// 
        /// <param name="supermercado"></param>
        public bool crear(Supermercado supermercado)
        {
            return true;
        }

        /// 
        /// <param name="codigo"></param>
        public bool eliminar(int codigo)
        {
            return true;
        }

        public List<Supermercado> listar()
        {
            List<Supermercado> supermercados;
            using (IDbConnection conexionSql = new SqlConnection(_databaseSettings.Value.defaultConnection))
            {
                conexionSql.Open();
                string consulta = "SELECT s.id" +
                                  " ,s.ciudad" +
                                  " ,s.direccion" +
                                  " ,s.idRedSupermercado" +
                                  " FROM Supermercado s";

                supermercados = conexionSql.Query<Supermercado>(consulta).ToList();
                conexionSql.Close();
            }
            return supermercados;
        }

        /// 
        /// <param name="codigo"></param>
        public Supermercado obtener(int id)
        {
            Supermercado supermercado;
            using (IDbConnection conexionSql = new SqlConnection(_databaseSettings.Value.defaultConnection))
            {
                conexionSql.Open();
                string consulta = "SELECT s.id" +
                                  " ,s.ciudad" +
                                  " ,s.direccion" +
                                  " ,s.idRedSupermercado" +
                                  " FROM Supermercado s" +
                                  " WHERE s.id = @Id";

                List<Supermercado> supermercados = conexionSql.Query<Supermercado>(consulta, new { Id = id }).ToList();
                supermercado = supermercados.FirstOrDefault();
                conexionSql.Close();
            }
            return supermercado;
        }
    }
}
