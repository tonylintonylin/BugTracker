using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BugTracker.Pages.Projects
{
    [Authorize(Roles = "Admin, Project Manager")]
    public class CreateModel : DI_BasePageModel
    {
        public CreateModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
            : base(context, authorizationService, userManager, roleManager)
        {
        }

        [BindProperty]
        public Project Project { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Project.Creator = UserManager.GetUserName(User);

            // Compare with CreatorID to match projects with users associated
            Project.CreatorID = UserManager.GetUserId(User);

            Project.CreationDate = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");

            Context.Projects.Add(Project);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
