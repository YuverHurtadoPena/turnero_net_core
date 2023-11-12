using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnero.BLL.Interfaces;
using Turnero.Entity;
using System.Net;
using Turnero.Entity;
using Turnero.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Turnero.BLL.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _repository;
        private readonly IUtileriaService _utileriaService;
        private readonly ICorreoService _correoService;
        public UsuarioService(
             IGenericRepository<Usuario> repository,
             IUtileriaService utileriaService,
             ICorreoService correoService
            )
        {
            _repository = repository;
            _utileriaService = utileriaService;
            _correoService = correoService;
        }
        public Task<bool> CambiarClave(int IdUsuario, string ClaveActual, string ClaveNueva)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> Crear(Usuario entidad, string UrlPlantillaCorreo)
        {
            Usuario existe = await _repository.Obtener(u => u.Usuario1 == entidad.Usuario1);
            if ( existe == null )
            {
                throw new TaskCanceledException("El correo ya existe");
            }
            try{
                string clave_generada = _utileriaService.GenerarClave();
                entidad.Clave = _utileriaService.ConvertirSha256(clave_generada);
                Usuario usuario_creado = await _repository.Crear(entidad);
                if( usuario_creado.UsuarioId == 0)
                    throw new TaskCanceledException("No se pudo crear el usuario");
                if(UrlPlantillaCorreo != "")
                {
                    UrlPlantillaCorreo = UrlPlantillaCorreo.Replace("[correo]", usuario_creado.Usuario1).Replace("[clave]", usuario_creado.Clave);
                    string htmlCorreo = "";
                }
            }
            catch(Exception ex) { }
        }

        public Task<Usuario> Editar(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GuardarPerfil(Usuario entidad)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Usuario>> Lista()
        {
            IQueryable<Usuario> query = await _repository.Consultar();
            return query.Include(r => r.Rol).ToList();
        }

        public Task<Usuario> ObtenerPorCredenciales(string correo, string clave)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObtenerPorId(int IdUsuario)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RestablecerClave(string Correo, string UrlPlantillaCorreo)
        {
            throw new NotImplementedException();
        }
    }
}
