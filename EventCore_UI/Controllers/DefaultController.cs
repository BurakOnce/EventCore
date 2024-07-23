using Microsoft.AspNetCore.Mvc;

namespace EventCore_UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
