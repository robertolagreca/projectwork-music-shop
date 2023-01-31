using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopStrumentiMusicali.Database;
using ShopStrumentiMusicali.Models;

namespace ShopStrumentiMusicali.Controllers {
    public class AdministrationController : Controller {
        public IActionResult IndexAdm() {
            
            using (ParamusicContext db = new ParamusicContext()) {
                List<Instrument> instrumentsList = db.Instruments.ToList<Instrument>();
                return View("IndexAdm", instrumentsList);
            }
   
        }

        [HttpGet]
        public IActionResult Create() {
            using (ParamusicContext db = new ParamusicContext())
            {
                List<Category> categoriesFromDb = db.Categories.ToList<Category>();
                List<ShopTransaction> shopTransactionsFromDb = db.ShopTransactions.ToList<ShopTransaction>();

                InstrumentCategoriesView modelForView = new InstrumentCategoriesView();
                modelForView.Instrument = new Instrument();

                List<Category> selectList = CategoriesToSelectList(categoriesFromDb);

                modelForView.Categories = categoriesFromDb;
                modelForView.ShopTransactions = shopTransactionsFromDb;
                return View("Create", modelForView);
            }
        }

        private static List<Category> CategoriesToSelectList(List<Category> categoriesFromDb)
        {
            List<Category> selectList = new List<Category>();
            foreach (Category category in categoriesFromDb)
            {
                Category item = new Category();
                item = category;
                selectList.Add(item);
            }

            return selectList;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InstrumentCategoriesView formData) {
            if (!ModelState.IsValid) {
                using (ParamusicContext db = new ParamusicContext()) {
                    List<Category> categoriesFromDb = db.Categories.ToList<Category>();
                    List<Category> selectList = CategoriesToSelectList(categoriesFromDb);


                    formData.Categories = categoriesFromDb;
                    List<ShopTransaction> transactions = db.ShopTransactions.ToList<ShopTransaction>();
                    formData.ShopTransactions = transactions;
                }


                return View("Create", formData);
            }

            using (ParamusicContext db = new ParamusicContext()) {
                db.Instruments.Add(formData.Instrument);
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

                List<Category> categoriesFromDb = db.Categories.ToList<Category>();

                InstrumentCategoriesView modelForView = new InstrumentCategoriesView();

                List<Category> selectList = CategoriesToSelectList(categoriesFromDb);

                modelForView.Instrument = instrumentToUpdate;
                modelForView.Categories = selectList;

                return View("Update", instrumentToUpdate);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, InstrumentCategoriesView formData) {
            if (!ModelState.IsValid) {

                using (ParamusicContext db = new ParamusicContext()) {
                    List<Category> categoriesFromDb = db.Categories.ToList<Category>();
                    List<Category> selectList = CategoriesToSelectList(categoriesFromDb);

                    formData.Categories = selectList;
                }

                return View("Update", formData);
            }

            using (ParamusicContext db = new ParamusicContext()) {
                
                Instrument instrumentToUpdate = db.Instruments.Where(instrument => instrument.Id == id).FirstOrDefault();

                if (instrumentToUpdate != null) {
                    instrumentToUpdate.Name = formData.Instrument.Name;
                    instrumentToUpdate.Description = formData.Instrument.Description;
                    instrumentToUpdate.ImageURL = formData.Instrument.ImageURL;

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
