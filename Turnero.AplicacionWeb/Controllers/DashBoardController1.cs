using Microsoft.AspNetCore.Mvc;

namespace Turnero.AplicacionWeb.Controllers
{
    public class DashBoardController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
