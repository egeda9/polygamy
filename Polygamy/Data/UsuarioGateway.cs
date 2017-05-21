using Dapper;
using Microsoft.Extensions.Options;
using Polygamy.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Polygamy.Data
{
    public class UsuarioGateway
    {
        private readonly IOptions<AppSettings> _databaseSettings;

        public UsuarioGateway(IOptions<AppSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        /// 
        /// <param name="usuario"></param>
        public void actualizar(Usuario usuario)
        {

        }

        /// 
        /// <param name="usuario"></param>
        public void crear(Usuario usuario)
        {

        }

        /// 
        /// <param name="id"></param>
        public void eliminar(int id)
        {

        }

        /// 
        /// <param name="usuarios"></param>
        public List<Usuario> listar()
        {
            List<Usuario> usuarios = new List<Usuario>();
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
                                  " ,u.nombreUsuario" +
                                  " ,u.contrasena" +
                                  " FROM Persona p" +
                                  " INNER JOIN Usuario u ON u.idPersona = p.id";

                usuarios = conexionSql.Query<Usuario>(consulta).ToList();
                conexionSql.Close();
            }
            return usuarios;
        }

        /// 
        /// <param name="id"></param>
        public Usuario obtener(int id)
        {
            return null;
        }

        /// 
        /// <param name="contrasena"></param>
        /// <param name="nombreUsuario"></param>
        public Usuario obtener(string contrasena, string nombreUsuario)
        {
            Usuario usuario;
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
                                  " ,u.nombreUsuario" +
                                  " ,u.contrasena" +
                                  " FROM Persona p" +
                                  " INNER JOIN Usuario u ON u.idPersona = p.id" +
                                  " WHERE nombreUsuario = @NombreUsuario" +
                                  " AND contrasena = @Contrasena";

                List<Usuario> usuarios = conexionSql.Query<Usuario>(consulta, new { NombreUsuario = nombreUsuario, Contrasena = contrasena }).ToList();
                usuario = usuarios.FirstOrDefault();
                conexionSql.Close();
            }
            return usuario;
        }
    }
}
