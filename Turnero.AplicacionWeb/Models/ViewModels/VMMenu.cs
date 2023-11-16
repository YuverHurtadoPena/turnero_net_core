namespace Turnero.AplicacionWeb.Models.ViewModels
{
    public class VMMenu
    {
        public int MenuId { get; set; }

        public string Titulo { get; set; } = null!;

        public string? Descripcion { get; set; }

        public int? RolId { get; set; }
    }
}
