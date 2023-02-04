using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ShopStrumentiMusicali.Database;
using ShopStrumentiMusicali.Models;
using ShopStrumentiMusicali.Models.DTOs;

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
                DateTime lastMonth = DateTime.Now.AddMonths(-1);
                List<int> mostTransactedInstruments = db.UserTransactions
                  .Where(t => t.TransactionDate >= lastMonth)
                  .GroupBy(t => t.InstrumentID)
                  .OrderByDescending(g => g.Count())
                  .Select(g => g.Key)
                  .Take(10)
                  .ToList();

                List<Instrument> piuvenduti = db.Instruments
                  .Where(i => mostTransactedInstruments.Contains(i.Id))
                  .ToList();
                return Ok(new { instruments , piuvenduti});
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

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]InstrumentDto instrumentDto)
        {
            using (ParamusicContext db = new ParamusicContext())
            {
                Instrument instrumentFromDb = db.Instruments.Where(instrument => instrument.Id == id).FirstOrDefault();
                if(instrumentFromDb is null)
                {
                    return BadRequest($"Instrument with id: {id} does not exist");
                }

                instrumentFromDb.UserLikes = instrumentDto.UserLikes;
                db.SaveChanges();
                return Ok(instrumentFromDb.UserLikes);
            }
        }






    }


}


