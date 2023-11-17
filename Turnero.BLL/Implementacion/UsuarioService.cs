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
        public async Task<bool> CambiarClave(int IdUsuario, string ClaveActual, string ClaveNueva)
        {
            try
            {
                Usuario usuarioEncontrado = await _repository.Obtener(u => u.UsuarioId == IdUsuario);
                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");
                if (usuarioEncontrado.Clave != _utileriaService.ConvertirSha256(ClaveActual))
                    throw new TaskCanceledException("La contraseña ingresa como actual no es correcta");
                usuarioEncontrado.Clave = _utileriaService.ConvertirSha256(ClaveNueva);
                bool respuesta = await _repository.Editar(usuarioEncontrado);


                return respuesta;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<Usuario> Crear(Usuario entidad, string UrlPlantillaCorreo)
        {
            Usuario existe = await _repository.Obtener(u => u.Usuario1 == entidad.Usuario1);
            if (existe == null)
            {
                throw new TaskCanceledException("El correo ya existe");
            }
            try
            {
                string clave_generada = _utileriaService.GenerarClave();
                entidad.Clave = _utileriaService.ConvertirSha256(clave_generada);
                Usuario usuario_creado = await _repository.Crear(entidad);
                if (usuario_creado.UsuarioId == 0)
                    throw new TaskCanceledException("No se pudo crear el usuario");
                if (UrlPlantillaCorreo != "")
                {
                    UrlPlantillaCorreo = UrlPlantillaCorreo.Replace("[correo]", usuario_creado.Usuario1).Replace("[clave]", usuario_creado.Clave);
                    string htmlCorreo = "";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(UrlPlantillaCorreo);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (Stream dataStream = response.GetResponseStream())
                        {
                            StreamReader reader = null;
                            if (response.CharacterSet == null)
                            {
                                reader = new StreamReader(dataStream);

                            }
                            else
                            {
                                reader = new StreamReader(dataStream, Encoding.GetEncoding(response.CharacterSet));
                            }
                            htmlCorreo = reader.ReadToEnd();
                            response.Close();
                            reader.Close();
                        }
                    }
                    if (htmlCorreo != "")
                        await _correoService.EnviarCorreo(usuario_creado.Usuario1, "Cuenta creada con exito", htmlCorreo);


                }
                IQueryable<Usuario> query = await _repository.Consultar(u => u.UsuarioId == usuario_creado.UsuarioId);
                usuario_creado = query.Include(r => r.Rol).First();
                return usuario_creado;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<Usuario> Editar(Usuario entidad)
        {
            Usuario existe = await _repository.Obtener(u => u.Usuario1 == entidad.Usuario1 && u.UsuarioId != entidad.UsuarioId);
            if (existe == null)
            {
                throw new TaskCanceledException("El correo ya existe");
            }
            try
            {
                IQueryable<Usuario> queryUsuario = await _repository.Consultar(u => u.UsuarioId == entidad.UsuarioId);
                Usuario usuarioEditar = queryUsuario.First();
                usuarioEditar.Usuario1 = entidad.Usuario1;
                bool respuesta = await _repository.Editar(usuarioEditar);
                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar el usuario");

                Usuario editado = queryUsuario.Include(r => r.Rol).First();
                return editado;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<bool> Eliminar(int IdUsuario)
        {
            try
            {
                Usuario usuarioEncontrado = await _repository.Obtener(u => u.UsuarioId == IdUsuario);
                if (usuarioEncontrado == null)
                    throw new TaskCanceledException("El usuario no existe");
                bool respuesta = await _repository.Eliminar(usuarioEncontrado);
                return respuesta;
            }
            catch (Exception ex) { throw; }
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

        public async Task<Usuario> ObtenerPorCredenciales(string correo, string clave)
        {
            string claveEncriptada = _utileriaService.ConvertirSha256(clave);
            Usuario usuarioEncontrado = await _repository.Obtener(u => u.Usuario1.Equals(correo) && clave.Equals(claveEncriptada));
            return usuarioEncontrado;
        }

        public async Task<Usuario> ObtenerPorId(int IdUsuario)
        {
            IQueryable<Usuario> query = await _repository.Consultar(u => u.UsuarioId == IdUsuario);
            Usuario resultado = query.Include(r => r.Rol).FirstOrDefault();
            return resultado;
        }

        public Task<bool> RestablecerClave(string Correo, string UrlPlantillaCorreo)
        {
            throw new NotImplementedException();
        }
    }
}
