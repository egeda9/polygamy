using Dapper;
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
    public class BeneficiarioGateway
    {
        private readonly IOptions<AppSettings> _databaseSettings;
        private readonly ILogger _logger;

        public BeneficiarioGateway(IOptions<AppSettings> databaseSettings, ILoggerFactory loggerFactory)
        {
            _databaseSettings = databaseSettings;
            _logger = loggerFactory.CreateLogger<BeneficiarioGateway>();
        }

        /// 
        /// <param name="beneficiario"></param>
        public bool actualizar(Beneficiario beneficiario)
        {
            return true;
        }

        /// 
        /// <param name="beneficiario"></param>
        public bool crear(Beneficiario beneficiario)
        {
            bool resultadoProceso = false;
            try
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
                    resultadoProceso = true;
                }
            }

            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                resultadoProceso = false;
            }
            return resultadoProceso;
        }

        /// 
        /// <param name="id"></param>
        public bool eliminar(int id)
        {
            return true;
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
                                  " ,b.id AS idBeneficiario" +
                                  " ,b.fechaCompraInicio" +
                                  " ,b.fechaCompraFin" +
                                  " ,b.activo" +
                                  " ,p1.id" +
                                  " ,p1.identificacion" +
                                  " ,p1.nombres" +
                                  " ,p1.apellidos" +
                                  " ,p1.ciudadResidencia" +
                                  " ,p1.direccionResidencia" +
                                  " ,p1.numeroTelefono" +
                                  " ,p1.email" +
                                  " ,a.cupo" +
                                  " ,a.id AS idAfiliado" +
                                  " FROM Persona p" +
                                  " INNER JOIN Beneficiario b ON b.idPersona = p.id" +
                                  " INNER JOIN Afiliado a ON a.id = b.idAfiliado" +
                                  " INNER JOIN Persona p1 ON p1.id = a.idPersona";

                beneficiarios = conexionSql.Query<Beneficiario, Afiliado, Beneficiario>(consulta, (b, a) => { b.afiliado = a; return b; }).ToList();
                conexionSql.Close();
            }
            return beneficiarios;
        }

        /// 
        /// <param name="id"></param>
        public Beneficiario obtenerPorIdentificacion(int identificacion)
        {
            Beneficiario beneficiario;
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
                                  " ,b.id AS idBeneficiario" +
                                  " ,b.fechaCompraInicio" +
                                  " ,b.fechaCompraFin" +
                                  " ,b.activo" +
                                  " ,p1.id" +
                                  " ,p1.identificacion" +
                                  " ,p1.nombres" +
                                  " ,p1.apellidos" +
                                  " ,p1.ciudadResidencia" +
                                  " ,p1.direccionResidencia" +
                                  " ,p1.numeroTelefono" +
                                  " ,p1.email" +
                                  " ,a.cupo" +
                                  " ,a.id AS idAfiliado" +
                                  " FROM Beneficiario b" +
                                  " INNER JOIN Persona p ON b.idPersona = p.id" +
                                  " INNER JOIN Afiliado a ON a.id = b.idAfiliado" +
                                  " INNER JOIN Persona p1 ON p1.id = a.idPersona" +
                                  " WHERE p.identificacion = @Identificacion";

                List<Beneficiario> beneficiarios = conexionSql.Query<Beneficiario, Afiliado, Beneficiario>(consulta, (b, a) => { b.afiliado = a; return b; }, new { Identificacion = identificacion }).ToList();
                beneficiario = beneficiarios.FirstOrDefault();
                conexionSql.Close();
            }
            return beneficiario;
        }

        /// 
        /// <param name="id"></param>
        public Beneficiario obtenerPorId(int idBeneficiario)
        {
            Beneficiario beneficiario;
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
                                  " ,b.id AS idBeneficiario" +
                                  " ,b.fechaCompraInicio" +
                                  " ,b.fechaCompraFin" +
                                  " ,b.activo" +
                                  " ,p1.id" +
                                  " ,p1.identificacion" +
                                  " ,p1.nombres" +
                                  " ,p1.apellidos" +
                                  " ,p1.ciudadResidencia" +
                                  " ,p1.direccionResidencia" +
                                  " ,p1.numeroTelefono" +
                                  " ,p1.email" +
                                  " ,a.cupo" +
                                  " ,a.id AS idAfiliado" +
                                  " FROM Beneficiario b" +
                                  " INNER JOIN Persona p ON b.idPersona = p.id" +
                                  " INNER JOIN Afiliado a ON a.id = b.idAfiliado" +
                                  " INNER JOIN Persona p1 ON p1.id = a.idPersona" +
                                  " WHERE b.id = @IdBeneficiario";

                List<Beneficiario> beneficiarios = conexionSql.Query<Beneficiario, Afiliado, Beneficiario>(consulta, (b, a) => { b.afiliado = a; return b; }, new { IdBeneficiario = idBeneficiario }).ToList();
                beneficiario = beneficiarios.FirstOrDefault();
                conexionSql.Close();
            }
            return beneficiario;
        }
    }
}
