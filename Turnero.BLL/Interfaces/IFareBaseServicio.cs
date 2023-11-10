using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnero.BLL.Interfaces
{
    public interface IFareBaseServicio
    {
        Task<string> SubirStorage(Stream StreamArchivo, string carpetaDestino, string nombreArchivo);
        Task<string> EliminarStorage(string CarpetaDestino, string NombreArchivo);
    }
}
