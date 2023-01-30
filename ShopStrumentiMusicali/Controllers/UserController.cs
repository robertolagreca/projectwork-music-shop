using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopStrumentiMusicali.Database;

namespace ShopStrumentiMusicali.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Users()
        {
            using (ParamusicContext db = new ParamusicContext())
            {
                List<IdentityUser> ListaRoles = db.Users.ToList();
                return View("Users", ListaRoles);
            }
        }

        public IActionResult Edit() {

        return View();
        }
    }
}
