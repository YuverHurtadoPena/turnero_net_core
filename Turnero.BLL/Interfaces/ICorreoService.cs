using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnero.BLL.Interfaces
{
    public interface ICorreoService
    {
        public Task<bool> EnviarCorreo(string CorreoDestino, string Asunto, string Mensaje);
    }
}
