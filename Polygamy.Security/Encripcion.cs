    using System.Security.Cryptography;
using System.Text;

namespace Polygamy.Security
{
    public class Encripcion
    {
        public string encriptarContrasena(string contrasena)
        {
            byte[] data = Encoding.ASCII.GetBytes(contrasena);
            using (SHA256 sha256 = SHA256.Create())
            {
                data = sha256.ComputeHash(data);
            }
            return Encoding.ASCII.GetString(data);
        }
    }
}
