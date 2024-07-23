using Microsoft.AspNetCore.Mvc;

namespace EventCore_UI.ViewComponents.HomePage
{
    public class _DefaultFeatureComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
