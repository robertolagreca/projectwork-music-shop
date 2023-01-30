using Microsoft.AspNetCore.Mvc;
using ShopStrumentiMusicali.Database;
using ShopStrumentiMusicali.Models;

namespace ShopStrumentiMusicali.Controllers {
    public class AdministrationController : Controller {
        public IActionResult Index() {
            
            using (ParamusicContext db = new ParamusicContext()) {
                List<Instrument> instrumentsList = db.Instruments.ToList<Instrument>();
                return View("Index", instrumentsList);
            }
   
        }

        [HttpGet]
        public IActionResult Create() {
            using (ParamusicContext db = new ParamusicContext()) {
                List<Category> categoriesFromDb = db.Categories.ToList<Category>();

                InstrumentCategoriesView modelForView = new InstrumentCategoriesView();
                modelForView.Instrument = new Instrument();

                modelForView.Categories = categoriesFromDb;

                return View("Create", modelForView);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InstrumentCategoriesView formData) {
            if (!ModelState.IsValid) {
                using (ParamusicContext db = new ParamusicContext()) {
                    List<Category> categories = db.Categories.ToList<Category>();
                    formData.Categories = categories;
                }


                return View("Create", formData);
            }

            using (ParamusicContext db = new ParamusicContext()) {
                db.Instruments.Add(formData);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id) {
            using (ParamusicContext db = new ParamusicContext()) {
                Instrument instrumentToUpdate = db.Instruments.Where(instrument => instrument.Id == id).FirstOrDefault();

                if (instrumentToUpdate == null) {
                    return NotFound("Lo strumento non è stato trovato");
                }

                List<Category> categories = db.Categories.ToList<Category>();

                InstrumentCategoriesView modelForView = new InstrumentCategoriesView();
                modelForView.Instrument = InstrumentCategoriesView;
                modelForView.Categories = categories;

                return View("Update", instrumentToUpdate);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(InstrumentCategoriesView formData) {
            if (!ModelState.IsValid) {

                using (InstrumentCategoriesView db = new InstrumentCategoriesView()) {
                    List<Category> categories = db.Categories.ToList<Category>();

                    formData.Categories = categories;
                }

                return View("Update", formData);
            }

            using (ParamusicContext db = new ParamusicContext()) {
                
                Instrument instrumentToUpdate = db.Instruments.Where(instrument => instrument.Id == formData.Id).FirstOrDefault();

                if (instrumentToUpdate != null) {
                    instrumentToUpdate.Name = formData.Name;
                    instrumentToUpdate.Description = formData.Description;
                    instrumentToUpdate.ImageURL = instrumentToUpdate.ImageURL;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                } else {
                    return NotFound("Lo strumento che volevi modificare non è stato trovato!");
                }
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id) {
            using (ParamusicContext db = new ParamusicContext()) {
                Instrument instrumentToDelete = db.Instruments.Where(instrument => instrument.Id == id).FirstOrDefault();

                if (instrumentToDelete != null) {
                    db.Instruments.Remove(instrumentToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                } else {
                    return NotFound("Lo strumento da eliminare non è stato trovato!");
                }
            }
        }
    }
}
