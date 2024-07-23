using Microsoft.AspNetCore.Mvc;

namespace EventCore_UI.Controllers
{
    public class AllEventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
