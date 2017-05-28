using Polygamy.Models;
using System.Collections.Generic;

namespace Polygamy.Data
{
    public class Administrador_SupermercadoGateway
    {
        public Administrador_SupermercadoGateway()
        {

        }

        /// 
        /// <param name="administradorSupermercado"></param>
        public bool actualizar(Administrador_Supermercado administradorSupermercado)
        {
            return true;
        }

        /// 
        /// <param name="administradorSupermercado"></param>
        public bool crear(Administrador_Supermercado administradorSupermercado)
        {
            return true;
        }

        /// 
        /// <param name="id"></param>
        public bool eliminar(int id)
        {
            return true;
        }

        public List<Administrador_Supermercado> listar()
        {
            return null;
        }

        /// 
        /// <param name="id"></param>
        public Administrador_Supermercado obtener(int id)
        {
            return null;
        }
    }
}
