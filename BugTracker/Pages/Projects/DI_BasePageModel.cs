using BugTracker.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugTracker.Pages.Projects
{
    public class DI_BasePageModel : PageModel
    {
        protected ApplicationDbContext Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<IdentityUser> UserManager { get; }
        protected RoleManager<IdentityRole> RoleManager { get; }

        public DI_BasePageModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager) : base()
        {
            Context = context;
            UserManager = userManager;
            RoleManager = roleManager;
            AuthorizationService = authorizationService;

        }
    }
}