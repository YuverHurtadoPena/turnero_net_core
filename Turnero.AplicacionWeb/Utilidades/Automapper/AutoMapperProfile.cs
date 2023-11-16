using Turnero.AplicacionWeb.Models.ViewModels;
using Turnero.Entity;
using System.Globalization;
using AutoMapper;

namespace Turnero.AplicacionWeb.Utilidades.Automapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            
            CreateMap<Rol, VMRol>().ReverseMap();
            CreateMap<Usuario, VMUsuario>().ForMember(
                destino => destino.NombreRol, 
                opt => opt.MapFrom(origen => origen.Rol.Descripcion)
                );
            CreateMap<VMUsuario, Usuario>().ForMember(
               destino => destino.Rol,
               opt => opt.Ignore()
               ) ;
        }
    }
}
