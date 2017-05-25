using Dapper;
using Microsoft.Extensions.Options;
using Polygamy.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Polygamy.Data
{
    public class ProductoGateway
    {
        private readonly IOptions<AppSettings> _databaseSettings;

        public ProductoGateway(IOptions<AppSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        public List<Producto> listar()
        {
            List<Producto> productos = new List<Producto>();
            using (IDbConnection conexionSql = new SqlConnection(_databaseSettings.Value.defaultConnection))
            {
                conexionSql.Open();
                string consulta = "SELECT p.id" +
                                  " ,p.descripcion" +
                                  " ,p.precioUnitario" +
                                  " FROM Producto p";

                productos = conexionSql.Query<Producto>(consulta).ToList();
                conexionSql.Close();
            }
            return productos;
        }

        /**
         * 
         * @param codigo
         */
        public Producto obtener(int codigo)
        {
            return null;
        }
    }
}
