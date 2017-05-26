﻿using Dapper;
using Microsoft.Extensions.Options;
using Polygamy.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Polygamy.Data
{
    public class CompraDetalleGateway
    {
        private readonly IOptions<AppSettings> _databaseSettings;

        public CompraDetalleGateway(IOptions<AppSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        /// 
        /// <param name="compraDetalle"></param>
        public int crear(CompraDetalle compraDetalle)
        {
            int compraDetalleId = 0;
            try
            {
                using (IDbConnection conexionSql = new SqlConnection(_databaseSettings.Value.defaultConnection))
                {
                    conexionSql.Open();

                    string insertarCompra = "INSERT INTO CompraDetalle(idProducto, cantidad, idCompra) VALUES (@IdProducto, @Cantidad, @IdCompra); " +
                                            "SELECT CAST(SCOPE_IDENTITY() as int)";

                    using (IDbTransaction transaccion = conexionSql.BeginTransaction())
                    {
                        compraDetalleId = conexionSql.Query<int>(insertarCompra, new { IdProducto = compraDetalle.producto.id, Cantidad = compraDetalle.cantidad, IdCompra = compraDetalle.compra.id }, transaccion).Single();
                        transaccion.Commit();
                    }
                    conexionSql.Close();
                }
            }

            catch (Exception ex)
            {

            }
            return compraDetalleId;
        }

        /// 
        /// <param name="id"></param>
        public bool eliminar(int id)
        {
            return true;
        }

        public List<CompraDetalle> listar()
        {
            return null;
        }

        /// 
        /// <param name="compraId"></param>
        public List<CompraDetalle> listar(int compraId)
        {
            return null;
        }

        /// 
        /// <param name="id"></param>
        public CompraDetalle obtener(int id)
        {
            return null;
        }
    }
}
