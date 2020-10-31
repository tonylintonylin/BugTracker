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
using BugTracker.Pages.Projects;

namespace BugTracker.Pages.Tickets
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

        public IEnumerable<IdentityUser> Users { get; set; }
        public Project Project { get; set; }

        public IActionResult OnGet()
        {
            Users = UserManager.Users;

            ViewData["ProjectID"] = new SelectList(Context.Projects, "ProjectID", "Name");
            ViewData["DeveloperID"] = new SelectList(Users, "Id", "UserName");

            return Page();
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Ticket.Creator = UserManager.GetUserName(User);

            // Compare with CreatorID to match projects with users associated
            Ticket.CreatorID = UserManager.GetUserId(User);

            Ticket.CreationDate = DateTime.Now.ToString("MM/dd/yyyy h:mm tt");

            Ticket.Status = Status.New;

            // Generate random unique id
            Ticket.ID = Guid.NewGuid().GetHashCode();

            Context.Tickets.Add(Ticket);
            await Context.SaveChangesAsync();

            // Route directly to the details page for the newly created ticket
            return RedirectToPage("./Details", new { id = Ticket.ID });
        }
    }
}
