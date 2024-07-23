using Microsoft.AspNetCore.Mvc;

namespace EventCore_UI.ViewComponents.Layout
{
    public class _ScriptViewComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
