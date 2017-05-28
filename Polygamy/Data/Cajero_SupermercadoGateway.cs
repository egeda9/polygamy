using Polygamy.Models;
using System.Collections.Generic;

namespace Polygamy.Data
{
    public class Cajero_SupermercadoGateway
    {
        public Cajero_SupermercadoGateway()
        {

        }

        /// 
        /// <param name="cajeroSupermercado"></param>
        public bool actualizar(Cajero_Supermercado cajeroSupermercado)
        {
            return true;
        }

        /// 
        /// <param name="cajeroSupermercado"></param>
        public bool crear(Cajero_Supermercado cajeroSupermercado)
        {
            return true;
        }

        /// 
        /// <param name="id"></param>
        public bool eliminar(int id)
        {
            return true;
        }

        public List<Cajero_Supermercado> listar()
        {
            return null;
        }

        /// 
        /// <param name="id"></param>
        public Cajero_Supermercado obtener(int id)
        {
            return null;
        }

    }
}
