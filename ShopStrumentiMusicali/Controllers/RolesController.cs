using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;
using ShopStrumentiMusicali.Database;

namespace ShopStrumentiMusicali.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this._roleManager = roleManager;
        }
        //Lista tuti account creati dal utenti
        public IActionResult Index()
        {
            using (ParamusicContext db = new ParamusicContext())
            {
                List<IdentityRole> ListaRoles = db.Roles.ToList<IdentityRole>();
                return View("Index", ListaRoles);
            }
            
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole model) 
        {
            if(!_roleManager.RoleExistsAsync(model.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(model.Name)).GetAwaiter().GetResult();    
            }
            return RedirectToAction("Index");
        }

    }
}
