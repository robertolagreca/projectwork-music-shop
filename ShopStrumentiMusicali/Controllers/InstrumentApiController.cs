using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ShopStrumentiMusicali.Database;
using ShopStrumentiMusicali.Models;

namespace ShopStrumentiMusicali.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class InstrumentApiController : ControllerBase {

        private readonly ParamusicContext _context;

        public InstrumentApiController(ParamusicContext context)
        {
            _context = context;
        }
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



        [HttpPost("increment")]
        public async Task<ActionResult<int>> IncrementLike(int id)
        {
            var instrument = await _context.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound("L'instrument con questo id non è stato trovato!");
            }

            instrument.UserLikes++;
            await _context.SaveChangesAsync();

            return Ok(instrument);
        }

        [HttpPost("decrement")]
        public async Task<ActionResult<int>> DecrementLike(int id)
        {
            var instrument = await _context.Instruments.FindAsync(id);
            if (instrument == null)
            {
                return NotFound("L'instrument con questo id non è stato trovato!");
            }
            instrument.UserLikes--;
            await _context.SaveChangesAsync();

            return Ok(instrument);
        }




    }


}


