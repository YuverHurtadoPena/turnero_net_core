using Microsoft.AspNetCore.Mvc;

namespace Turnero.AplicacionWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
