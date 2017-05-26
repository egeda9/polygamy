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
        public bool actualizar(Compra compra)
        {
            int resultado = 0;
            try
            {
                using (IDbConnection conexionSql = new SqlConnection(_databaseSettings.Value.defaultConnection))
                {
                    conexionSql.Open();

                    string actualizarCompra = "UPDATE Compra SET total = @Total WHERE id = @Id";

                    using (IDbTransaction transaccion = conexionSql.BeginTransaction())
                    {
                        resultado = conexionSql.Execute(actualizarCompra, compra, transaccion);
                        transaccion.Commit();
                    }
                    conexionSql.Close();
                }
            }

            catch (Exception ex)
            {

            }
            return resultado > 0;
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

                    string insertarCompra = "INSERT INTO Compra(idSupermercado, idBeneficiario, fecha, total) VALUES (@IdSupermercado, @IdBeneficiario, @Fecha, @Total); " +
                                            "SELECT CAST(SCOPE_IDENTITY() as int)";

                    using (IDbTransaction transaccion = conexionSql.BeginTransaction())
                    {
                        compraId = conexionSql.Query<int>(insertarCompra, new { IdSupermercado = compra.supermercado.id, IdBeneficiario = compra.beneficiario.idBeneficiario, Fecha = compra.fecha, Total = 0 }, transaccion).Single();                        
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
                                  " ,c.fecha" +
                                  " ,c.total" +
                                  " ,b.id AS idBeneficiario" +
                                  " ,b.idAfiliado" + 
                                  " ,b.cupo" +
                                  " ,b.fechaCompraInicio" +
                                  " ,b.fechaCompraFin" +
                                  " ,b.idPersona" +
                                  " ,b.activo" +
                                  " ,a.id AS idAfiliado" +
                                  " ,a.cupo" +                                  
                                  " FROM Compra c" +
                                  " INNER JOIN Beneficiario b ON b.id = c.idBeneficiario" +
                                  " INNER JOIN Afiliado a ON a.id = b.idAfiliado" +
                                  " WHERE c.id = @Id";

                List<Compra> compras = conexionSql.Query<Compra, Beneficiario, Afiliado, Compra>(consulta, (c, b, a) => { c.beneficiario = b; c.beneficiario.afiliado = a; return c; }, new { Id = id }, splitOn: "idBeneficiario, idAfiliado" ).ToList();
                compra = compras.FirstOrDefault();
                conexionSql.Close();
            }
            return compra;
        }
    }
}
