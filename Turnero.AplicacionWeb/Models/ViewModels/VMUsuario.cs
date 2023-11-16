namespace Turnero.AplicacionWeb.Models.ViewModels
{
    public class VMUsuario
    {
        public int UsuarioId { get; set; }

        public string Usuario1 { get; set; } = null!;

        public string Clave { get; set; } = null!;

        public int? RolId { get; set; }

        public bool Activo { get; set; }

        public string NombreRol { get; set; } = null!;
        public int? IdPersona { get; set; }

        
    }
}
