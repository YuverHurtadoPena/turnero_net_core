using Microsoft.AspNetCore.Mvc;

namespace Turnero.AplicacionWeb.Controllers
{
    public class NegocioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
