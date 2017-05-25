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
    public class AfiliadoGateway
    {
        private readonly IOptions<AppSettings> _databaseSettings;
        
        public AfiliadoGateway(IOptions<AppSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        /// 
        /// <param name="afiliado"></param>
        public bool actualizar(Afiliado afiliado)
        {
            return true;
        }

        /// 
        /// <param name="afiliado"></param>
        public bool crear(Afiliado afiliado)
        {
            bool resultadoProceso = false;
            try
            {
                using (IDbConnection conexionSql = new SqlConnection(_databaseSettings.Value.defaultConnection))
                {
                    conexionSql.Open();

                    string insertarPersona = "INSERT INTO Persona(identificacion, nombres, apellidos, numeroTelefono, email, direccionResidencia, ciudadResidencia) VALUES (@Identificacion, @Nombres, @Apellidos, @NumeroTelefono, @Email, @DireccionResidencia, @CiudadResidencia); " +
                                              "SELECT CAST(SCOPE_IDENTITY() as int)";
                    string insertarAfiliado = "INSERT INTO Afiliado(cupo, idPersona) VALUES (@Cupo, @IdPersona)";

                    using (IDbTransaction transaccion = conexionSql.BeginTransaction())
                    {
                        int personaId = conexionSql.Query<int>(insertarPersona, new { Identificacion = afiliado.identificacion, Nombres = afiliado.nombres, Apellidos = afiliado.apellidos, NumeroTelefono = afiliado.numeroTelefono, Email = afiliado.email, DireccionResidencia = afiliado.direccionResidencia, CiudadResidencia = afiliado.ciudadResidencia }, transaccion).Single();
                        conexionSql.Execute(insertarAfiliado, new { Cupo = afiliado.cupo, IdPersona = personaId }, transaccion);
                        transaccion.Commit();
                    }
                    conexionSql.Close();

                    resultadoProceso = true;
                }
            }

            catch(Exception ex)
            {
                resultadoProceso = false;
            }
            return resultadoProceso;
        }

        /// 
        /// <param name="id"></param>s
        public bool eliminar(int id)
        {
            return true;
        }

        public List<Afiliado> listar()
        {
            List<Afiliado> afiliados = new List<Afiliado>();
            using (IDbConnection conexionSql = new SqlConnection(_databaseSettings.Value.defaultConnection))
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
            Afiliado afiliado;
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
                                  " ,a.cupo" +
                                  " ,a.id AS idAfiliado" +
                                  " FROM Persona p" +
                                  " INNER JOIN Afiliado a ON a.idPersona = p.id" +
                                  " WHERE p.id = @Id";

                List<Afiliado> afiliados = conexionSql.Query<Afiliado>(consulta, new { Id = id }).ToList();
                afiliado = afiliados.FirstOrDefault();
                conexionSql.Close();
            }
            return afiliado;
        }
    }
}
