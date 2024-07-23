using Microsoft.AspNetCore.Mvc;

namespace EventCore_UI.ViewComponents.Layout
{
    public class _HeaderViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
