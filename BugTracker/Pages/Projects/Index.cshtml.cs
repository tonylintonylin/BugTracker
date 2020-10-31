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
using Microsoft.AspNetCore.Identity;

namespace BugTracker.Pages.Projects
{
    public class IndexModel : DI_BasePageModel
    {
        public IndexModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
            : base(context, authorizationService, userManager, roleManager)
        {
        }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string DescriptionSort { get; set; }
        public string CreatorSort { get; set; }
        public string TicketSort { get; set; }
        public string CurrentSort { get; set; }
        public string CurrentFilter { get; set; }

        // public PaginatedList<Project> Projects { get; set; }

        public ICollection<Project> Projects { get; set; }


        public async Task OnGetAsync()
        {
            var projects = from p in Context.Projects
                           select p;

            Projects = await projects
                .Include(p => p.Tickets)
                .ToListAsync();
            //sort, filter, pagination
            /*
            CurrentSort = sortOrder;

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            DateSort = sortOrder == "date_asc" ? "date_desc" : "date_asc";

            DescriptionSort = sortOrder == "description_asc" ? "description_desc" : "description_asc";

            CreatorSort = sortOrder == "creator_asc" ? "creator_desc" : "creator_asc";

            TicketSort = sortOrder == "ticket_asc" ? "ticket_desc" : "ticket_asc";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;


            IQueryable<Project> projects = from p in Context.Projects
                                           select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                projects = projects.Where(p => p.Name.Contains(searchString)
                                       || p.Description.Contains(searchString)
                                       || p.Creator.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    projects = projects.OrderByDescending(p => p.Name);
                    break;
                case "date_asc":
                    projects = projects.OrderBy(p => p.CreationDate);
                    break;
                case "date_desc":
                    projects = projects.OrderByDescending(p => p.CreationDate);
                    break;
                case "description_asc":
                    projects = projects.OrderBy(p => p.Description);
                    break;
                case "description_desc":
                    projects = projects.OrderByDescending(p => p.Description);
                    break;
                case "creator_asc":
                    projects = projects.OrderBy(p => p.Creator);
                    break;
                case "creator_desc":
                    projects = projects.OrderByDescending(p => p.Creator);
                    break;
                case "ticket_asc":
                    projects = projects.OrderBy(p => p.UnresolvedTickets);
                    break;
                case "ticket_desc":
                    projects = projects.OrderByDescending(p => p.UnresolvedTickets);
                    break;  
                default:
                    projects = projects.OrderBy(p => p.Name);
                    break;
            }

            int pageSize = 10;

            Projects = await PaginatedList<Project>
                .CreateAsync(projects
                .Include(p => p.Tickets)
                .AsNoTracking(), pageIndex ?? 1, pageSize);
            */


        }
    }
}
