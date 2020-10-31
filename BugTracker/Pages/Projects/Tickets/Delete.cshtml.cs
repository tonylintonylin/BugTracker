using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data;
using BugTracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace BugTracker.Pages.Tickets
{
    [Authorize(Roles = "Admin, Project Manager")]
    public class DeleteModel : PageModel
    {
        private readonly BugTracker.Data.ApplicationDbContext _context;

        public DeleteModel(BugTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket Ticket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Tickets
                .Include(t => t.Project).FirstOrDefaultAsync(m => m.ID == id);

            if (Ticket == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Tickets.FindAsync(id);

            if (Ticket != null)
            {
                _context.Tickets.Remove(Ticket);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
