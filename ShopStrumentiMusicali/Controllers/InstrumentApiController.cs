using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            using (ParamusicContext db = new ParamusicContext())
            {
                Instrument instrument = db.Instruments.Where(ins => ins.Id == id).FirstOrDefault();

                if (instrument is null)
                {
                    return NotFound("L'instrument con questo id non è stato trovato!");
                }

                return Ok(instrument);
            }

        }



    }

}
