using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ShopStrumentiMusicali.Database;
using ShopStrumentiMusicali.Models;
using System.Diagnostics;

namespace ShopStrumentiMusicali.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() {

            using (ParamusicContext db = new ParamusicContext()) {
                List<Instrument> instrumentsList = db.Instruments.ToList<Instrument>();
                return View("Index", instrumentsList);
            }

        }

        public IActionResult Details(int id) {
            using (ParamusicContext db = new ParamusicContext()) {
                // LINQ: syntax methos
                Instrument instrumentFound = db.Instruments
                    .Where(singleInstrument => singleInstrument.Id == id)
                    .Include(instrument => instrument.Category)
                    .FirstOrDefault();

                if (instrumentFound != null) {
                    return View(instrumentFound);
                }

                return NotFound("Lo strumento con l'id cercato non esiste!");

            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}