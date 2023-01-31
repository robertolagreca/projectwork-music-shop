using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopStrumentiMusicali.Database;
using ShopStrumentiMusicali.Models;
using ShopStrumentiMusicali.Repositories;
using System.Data;

namespace ShopStrumentiMusicali.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        
        public readonly IUnitofWork _unitofWork;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(IUnitofWork unitofWork , SignInManager<IdentityUser> signInManager) {
            _unitofWork = unitofWork;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
           /* using (ParamusicContext db = new ParamusicContext())
            {
                List<IdentityUser> ListaRoles = db.Users.ToList();
                return View("Index", ListaRoles);
            }*/
           
           var users = _unitofWork.User.GetUsers();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id) {
            var user = _unitofWork.User.GetUser(id);
           var roles = _unitofWork.Role.GetRoles();
            var userroles = await _signInManager.UserManager.GetRolesAsync(user);


            var roleitems = roles.Select(role => 
            new SelectListItem(role.Name,role.Id,
            userroles.Any(ur =>ur.Contains(role.Name)))).ToList();

            var vm = new UserRoleModel
            {
                User = user,
               Roles = roleitems,
            };

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> OnPostAsync(UserRoleModel data)
        {
            var user = _unitofWork.User.GetUser(data.User.Id);
            if (user == null)
            {
                return NotFound();
            }

            var userRolesInDb = await _signInManager.UserManager.GetRolesAsync(user);

            //Cicla in UserRoleModel
            //Verifica se Ruolo e assegnato in DB
            //Se assegnato niente
            //Se no assegna ruolo

            var rolesToAdd = new List<string>();
            var rolesToDelete = new List<string>();

            foreach (var role in data.Roles)
            {
                var assignedInDb = userRolesInDb.FirstOrDefault(ur => ur == role.Text);
                if (role.Selected)
                {
                    if (assignedInDb == null)
                    {
                        rolesToAdd.Add(role.Text);
                    }
                }
                else
                {
                    if (assignedInDb != null)
                    {
                        rolesToDelete.Add(role.Text);
                    }
                }
            }

            if (rolesToAdd.Any())
            {
                await _signInManager.UserManager.AddToRolesAsync(user, rolesToAdd);
            }

            if (rolesToDelete.Any())
            {
                await _signInManager.UserManager.RemoveFromRolesAsync(user, rolesToDelete);
            }

            if (data.User.Email != null & data.User.Email != "")
            {
                user.Email = data.User.Email;
            }
            _unitofWork.User.UpdateUser(user);

            return RedirectToAction("Edit", new { id = user.Id });
        }
    }
}
    

