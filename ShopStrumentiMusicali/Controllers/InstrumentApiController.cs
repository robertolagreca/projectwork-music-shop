using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopStrumentiMusicali.Database;
using ShopStrumentiMusicali.Models;

namespace ShopStrumentiMusicali.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentApiController : ControllerBase {
        
        [HttpGet]
        public IActionResult Get() {
            using (ParamusicContext db = new ParamusicContext()) {
                List<Instrument> instruments = db.Instruments.Include(instrument => instrument.Category).ToList<Instrument>();

                return Ok(instruments);
            }
        }
    }
}
