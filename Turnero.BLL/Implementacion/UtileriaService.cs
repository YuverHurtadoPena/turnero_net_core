using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnero.BLL.Interfaces;
using System.Security.Cryptography;
namespace Turnero.BLL.Implementacion
{
    public class UtileriaService : IUtileriaService
    {
        public string ConvertirSha256(string texto)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                //sacamos los byte de la variable texto
                Byte[] result = hash.ComputeHash(enc.GetBytes(texto));
                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();

        }

        public string GenerarClave()
        {
            //con el formato N le estamos indicando que nos proporcione numeros y letras
            string clave = Guid.NewGuid().ToString("N").Substring(0, 6);
            return clave;
        }
    }
}
