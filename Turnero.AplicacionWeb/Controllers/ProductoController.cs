using Microsoft.AspNetCore.Mvc;

namespace Turnero.AplicacionWeb.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
