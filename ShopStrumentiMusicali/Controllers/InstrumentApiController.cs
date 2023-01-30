using Microsoft.AspNetCore.Mvc;

namespace ShopStrumentiMusicali.Controllers {
    public class InstrumentApiController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
