using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopStrumentiMusicali.Models
{
    public class UserRoleModel
    {
       public IdentityUser User { get; set; }
       public IList<SelectListItem>? Roles { get; set; }
    }
}
