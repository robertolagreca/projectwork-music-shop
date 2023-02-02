using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopStrumentiMusicali.Database;
using ShopStrumentiMusicali.Models;
using System.Data;

namespace ShopStrumentiMusicali.Controllers {
    public class AdministrationController : Controller {
        public IActionResult IndexAdm() {
            
            using (ParamusicContext db = new ParamusicContext()) {
                List<Instrument> instrumentsList = db.Instruments.ToList<Instrument>();
                return View("IndexAdm", instrumentsList);
            }
   
        }

        public IActionResult Warehouse() {

            using (ParamusicContext db = new ParamusicContext()) {
                List<Instrument> instrumentsList = db.Instruments.ToList<Instrument>();
                return View("Warehouse", instrumentsList);
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

                //List<Category> selectList = CategoriesToSelectList(categoriesFromDb);

                modelForView.Categories = categoriesFromDb;
              //  modelForView.ShopTransactions = shopTransactionsFromDb;
                return View("Create", modelForView);
            }
        }

        /*private static List<Category> CategoriesToSelectList(List<Category> categoriesFromDb)
        {
            List<Category> selectList = new List<Category>();
            foreach (Category category in categoriesFromDb)
            {
                Category item = new Category();
                item = category;
                selectList.Add(item);
            }

            return selectList;
        }*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InstrumentCategoriesView formData) {

            if (!ModelState.IsValid) {
                Console.WriteLine("Debug here");

                using (ParamusicContext db = new ParamusicContext()) {
                    List<Category> categoriesFromDb = db.Categories.ToList<Category>();
					
					

					formData.Categories = categoriesFromDb;
                    
                }


                return View("Create", formData);
            }

            using (ParamusicContext db = new ParamusicContext()) {
                db.Instruments.Add(formData.Instrument);
                db.SaveChanges();
            }

            return RedirectToAction("IndexAdm");
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

                //List<Category> selectList = CategoriesToSelectList(categoriesFromDb);

                modelForView.Instrument = instrumentToUpdate;
                modelForView.Categories = categoriesFromDb;

                return View("Update", modelForView);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, InstrumentCategoriesView formData)
        {
            if (!ModelState.IsValid)
            {

                using (ParamusicContext db = new ParamusicContext())
                {
                    List<Category> categoriesFromDb = db.Categories.ToList<Category>();
                    //List<Category> selectList = CategoriesToSelectList(categoriesFromDb);

                    formData.Categories = categoriesFromDb;
                }

                return View("Update", formData);
            }

            using (ParamusicContext db = new ParamusicContext())
            {

                Instrument instrumentToUpdate = db.Instruments.Where(instrument => instrument.Id == id).FirstOrDefault();

                if (instrumentToUpdate != null)
                {
                    instrumentToUpdate.Name = formData.Instrument.Name;
                    instrumentToUpdate.Description = formData.Instrument.Description;
                    instrumentToUpdate.ImageURL = formData.Instrument.ImageURL;
                    instrumentToUpdate.CategoryID = formData.Instrument.CategoryID;
                    instrumentToUpdate.Price = formData.Instrument.Price;

                    db.SaveChanges();

                    return RedirectToAction("IndexAdm");
                }
                else
                {
                    return NotFound("Lo strumento che volevi modificare non è stato trovato!");
                }
            }
        }

        [HttpGet]
        public IActionResult Purchase(int id)
        {
            using (ParamusicContext db = new ParamusicContext())
            {
                Instrument instrumentToUpdate = db.Instruments.Where(instrument => instrument.Id == id).FirstOrDefault();

                if (instrumentToUpdate == null)
                {
                    return NotFound("Lo strumento non è stato trovato");
                }

                List<Category> categoriesFromDb = db.Categories.ToList<Category>();

                InstrumentCategoriesView formData = new InstrumentCategoriesView();


                formData.Instrument = instrumentToUpdate;
                formData.Categories = categoriesFromDb; // non mi serve

                return View("Purchase", formData);
            }

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Purchase(int id, InstrumentCategoriesView formData) {
            if (!ModelState.IsValid) {

                using (ParamusicContext db = new ParamusicContext()) {
                    List<Category> categoriesFromDb = db.Categories.ToList<Category>();
                    //List<Category> selectList = CategoriesToSelectList(categoriesFromDb);

                    formData.Categories = categoriesFromDb;
                }

                return View("Purchase", formData);
            }

            
            

            using (ParamusicContext db = new ParamusicContext()) {
                
                Instrument instrumentToUpdate = db.Instruments.Where(instrument => instrument.Id == id).FirstOrDefault();
                int qtsub = (int)instrumentToUpdate.Quantity;

				instrumentToUpdate.Quantity = qtsub - formData.Quantity;

                
                UserTransaction userTransaction = new UserTransaction();

                if (instrumentToUpdate != null) {
                    userTransaction.TransactionDate = DateTime.Now;
                    userTransaction.TransactionQuantity = formData.Quantity;
                    
                    
                    
                    
                    db.UserTransactions.Add(userTransaction);
                    db.SaveChanges();

                    return RedirectToAction("IndexAdm");
                } else {
                    return NotFound("Lo strumento che volevi modificare non è stato trovato!");
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id) {
            using (ParamusicContext db = new ParamusicContext()) {
                Instrument instrumentToDelete = db.Instruments.Where(instrument => instrument.Id == id).FirstOrDefault();

                if (instrumentToDelete != null) {
                    db.Instruments.Remove(instrumentToDelete);
                    db.SaveChanges();

                    return RedirectToAction("IndexAdm");
                } else {
                    return NotFound("Lo strumento da eliminare non è stato trovato!");
                }
            }
        }
    }
}
