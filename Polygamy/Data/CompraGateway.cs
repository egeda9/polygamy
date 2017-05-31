using Dapper;
using Dapper.Mapper;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public CompraGateway(IOptions<AppSettings> databaseSettings, ILoggerFactory loggerFactory)
        {
            _databaseSettings = databaseSettings;
            _logger = loggerFactory.CreateLogger<CompraGateway>();
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
                _logger.LogError(ex.Message, ex);
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
                _logger.LogError(ex.Message, ex);
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
        public List<Compra> obtener(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Compra> compras = new List<Compra>();
            using (IDbConnection conexionSql = new SqlConnection(_databaseSettings.Value.defaultConnection))
            {
                conexionSql.Open();
                string consulta = "SELECT TOP 20 c.id" +
                                " ,c.fecha" +
                                " ,c.total" +
                                " ,s.id" +
                                " ,s.ciudad" +
                                " ,s.direccion" +
                                " ,p.id" +
                                " ,p.nombres" +
                                " ,p.apellidos" +
                                " FROM Compra c" +
                                " INNER JOIN Supermercado s ON s.id = c.idSupermercado" +
                                " INNER JOIN Beneficiario b ON b.id = c.idBeneficiario" +
                                " INNER JOIN Persona p ON p.id = b.idPersona" +
                                " WHERE c.fecha BETWEEN @FechaInicio AND @FechaFin" +
                                " ORDER BY c.total DESC";

                compras = conexionSql.Query<Compra, Supermercado, Beneficiario, Compra>(consulta, (c, s, b) => { c.supermercado = s; c.beneficiario = b; return c; }, new { FechaInicio = fechaInicio, FechaFin = fechaFin } ).ToList();
                conexionSql.Close();
            }
            return compras;
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
