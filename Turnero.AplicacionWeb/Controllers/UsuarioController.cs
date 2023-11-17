using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Newtonsoft.Json;
using Turnero.AplicacionWeb.Models.ViewModels;
using Turnero.AplicacionWeb.Utilidades.Response;
using Turnero.BLL.Interfaces;
using Turnero.Entity;

namespace Turnero.AplicacionWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;
        private readonly IRolService _rolService;

        public UsuarioController(IMapper mapper, IUsuarioService usuarioService, IRolService rolService)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
            _rolService = rolService;

        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> ListaRoles()
        {
            var lista = await _rolService.Lista();
            List<VMRol> roles = new List<VMRol>();
            List<VMRol> vmListaRoles = _mapper.Map<List<VMRol>>(lista);
            return StatusCode(StatusCodes.Status200OK, vmListaRoles);
        }
        [HttpGet]
        public async Task<IActionResult> ListaUsuario()
        {
            var lista = await _rolService.Lista();
            List<VMUsuario> vmUsuarioLista = _mapper.Map<List<VMUsuario>>(await _usuarioService.Lista());
            return StatusCode(StatusCodes.Status200OK, vmUsuarioLista);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromForm] string modelo)
        {
            GenericResponse<VMUsuario> genericResponse = new GenericResponse<VMUsuario>();
            try
            {
                VMUsuario vMUsuario = JsonConvert.DeserializeObject<VMUsuario>(modelo);
                string urlPlantillaCorreo = $"{this.Request.Scheme}:// {this.Request.Host}/Plantilla/EnviarCorreo?correo=[correo]&clave=[clave]";
                Usuario usuario_creado = await _usuarioService.Crear(_mapper.Map < Usuario > (vMUsuario), urlPlantillaCorreo);
                vMUsuario = _mapper.Map<VMUsuario>(usuario_creado);
                genericResponse.Estado = true;
                genericResponse.Objeto =vMUsuario;
            }
            catch (Exception ex) {
                genericResponse.Estado = false;
                genericResponse.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, genericResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromForm] string modelo)
        {
            GenericResponse<VMUsuario> genericResponse = new GenericResponse<VMUsuario>();
            try
            {
                VMUsuario vMUsuario = JsonConvert.DeserializeObject<VMUsuario>(modelo);
                
                Usuario usuario_editado = await _usuarioService.Editar(_mapper.Map<Usuario>(vMUsuario) );
                vMUsuario = _mapper.Map<VMUsuario>(usuario_editado);
                genericResponse.Estado = true;
                genericResponse.Objeto = vMUsuario;
            }
            catch (Exception ex)
            {
                genericResponse.Estado = false;
                genericResponse.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, genericResponse);
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int idUsuario)
        {
            GenericResponse<string>genericResponse = new GenericResponse<string>();
            try{
                genericResponse.Estado = await _usuarioService.Eliminar(idUsuario);

            }
            catch(Exception ex)
            {
                genericResponse.Estado = false;
                genericResponse.Mensaje = ex.Message;
            }
            return StatusCode(StatusCodes.Status200OK, genericResponse);
        }
    }
}
