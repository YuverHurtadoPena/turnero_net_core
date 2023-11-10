using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnero.BLL.Interfaces
{
    public interface IUtileriaService
    {
        string GenerarClave();
        string ConvertirSha256(string texto);
    }
}
