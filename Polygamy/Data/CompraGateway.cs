using Dapper;
using Microsoft.Extensions.Options;
using Polygamy.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Polygamy.Data
{
    public class CompraGateway
    {
        private readonly IOptions<AppSettings> _databaseSettings;

        public CompraGateway(IOptions<AppSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        /// 
        /// <param name="compra"></param>
        public Compra actualizar(Compra compra)
        {
            return new Compra();
        }

        /// 
        /// <param name="compra"></param>
        public int crear(Compra compra)
        {
            int compraId = 0;
            try
            {
                using (IDbConnection conexionSql = new SqlConnection(_databaseSettings.Value.defaultConnection))
                {
                    conexionSql.Open();

                    string insertarCompra = "INSERT INTO Compra(idSupermercado, idBeneficiario, fecha) VALUES (@IdSupermercado, @IdBeneficiario, @Fecha); " +
                                            "SELECT CAST(SCOPE_IDENTITY() as int)";

                    using (IDbTransaction transaccion = conexionSql.BeginTransaction())
                    {
                        compraId = conexionSql.Query<int>(insertarCompra, new { IdSupermercado = compra.supermercado.id, IdBeneficiario = compra.beneficiario.idBeneficiario, Fecha = compra.fecha }, transaccion).Single();                        
                        transaccion.Commit();
                    }
                    conexionSql.Close();
                }
            }

            catch (Exception ex)
            {

            }
            return compraId;
        }

        public List<Compra> listar()
        {
            return null;
        }

        /// 
        /// <param name="fechaFin"></param>
        /// <param name="fechaInicio"></param>
        public List<Compra> obtener(DateTime fechaFin, DateTime fechaInicio)
        {
            return null;
        }

        public Compra obtener(int id)
        {
            Compra compra;
            using (IDbConnection conexionSql = new SqlConnection(_databaseSettings.Value.defaultConnection))
            {
                conexionSql.Open();
                string consulta = "SELECT c.id" +
                                  " ,c.idSupermercado" +
                                  " ,c.idBeneficiario" +
                                  " ,c.fecha" +
                                  " FROM Compra c" +
                                  " INNER JOIN Beneficiario b ON b.idBeneficiario = c.idBeneficiario" +
                                  " WHERE c.id = @Id";

                List<Compra> compras = conexionSql.Query<Compra>(consulta, new { Id = id }).ToList();
                compra = compras.FirstOrDefault();
                conexionSql.Close();
            }
            return compra;
        }
    }
}
