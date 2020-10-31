using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BugTracker.Pages.Projects;

namespace BugTracker.Pages.Tickets
{
    [Authorize(Roles = "Admin, Project Manager")]
    public class EditModel : DI_BasePageModel
    {
        public EditModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
            : base(context, authorizationService, userManager, roleManager)
        {
        }

        [BindProperty]
        public Ticket Ticket { get; set; }
        public IEnumerable<IdentityUser> Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await Context.Tickets
                .Include(t => t.Project).FirstOrDefaultAsync(m => m.ID == id);

            if (Ticket == null)
            {
                return NotFound();
            }

            Users = UserManager.Users;

            ViewData["DeveloperID"] = new SelectList(Users, "Id", "UserName");

            ViewData["ProjectID"] = new SelectList(Context.Projects, "ProjectID", "Description");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Context.Attach(Ticket).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(Ticket.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Details", new { id = Ticket.ID });
        }

        private bool TicketExists(int id)
        {
            return Context.Tickets.Any(e => e.ID == id);
        }
    }
}
