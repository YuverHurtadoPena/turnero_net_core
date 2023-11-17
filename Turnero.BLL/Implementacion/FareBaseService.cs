using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Turnero.BLL.Interfaces;
using Firebase.Auth;
using Firebase.Storage;
using Turnero.Entity;
using Turnero.DAL;
using Turnero.DAL.Interfaces;
using Firebase.Auth.Providers;

namespace Turnero.BLL.Implementacion
{
    public class FareBaseService : IFareBaseServicio
    {
        private readonly IGenericRepository<Configuracion> _repository;
        public FareBaseService(IGenericRepository<Configuracion> repository)
        {
            _repository = repository;
        }
        public Task<string> EliminarStorage(string CarpetaDestino, string NombreArchivo)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SubirStorage(Stream StreamArchivo, string carpetaDestino, string nombreArchivo)
        {
            try
            {
                return "";
                /*IQueryable<Configuracion> query = await _repository.Consultar(c => c.Recurso.Equals("FireBase_Storage"));
                Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);
                var auth = new FirebaseAuthProvider(new FirebaseConfig(Config["api_key"]));*/
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
