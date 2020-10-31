using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.Pages.Tickets
{
    public class DetailsModel : PageModel
    {
        private readonly BugTracker.Data.ApplicationDbContext _context;

        public DetailsModel(BugTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Ticket Ticket { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket = await _context.Tickets
                .Include(t => t.Project)
                .Include(t => t.Developer)
                .FirstOrDefaultAsync(m => m.ID == id);
            
            if (Ticket == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
