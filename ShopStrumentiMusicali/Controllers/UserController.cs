using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopStrumentiMusicali.Database;
using ShopStrumentiMusicali.Repositories;

namespace ShopStrumentiMusicali.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        UserController(IUnitofWork unitofWork) {
            this._unitofWork = unitofWork;
        }
        public IActionResult Users()
        {
           /* using (ParamusicContext db = new ParamusicContext())
            {
                List<IdentityUser> ListaRoles = db.Users.ToList();
                return View("Users", ListaRoles);
            }
           */
           var users = _unitofWork.User.GetUsers();
            return View(users);
        }

        public IActionResult Edit() {

        return View();
        }
    }
}
