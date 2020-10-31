using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Data;
using BugTracker.Models;
using BugTracker.Pages.Projects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BugTracker.Pages
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
        public IEnumerable<IdentityUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public ICollection<Project> Projects { get; set; }
        public async Task OnGetAsync()
        {
            Users = UserManager.Users;
            Roles = RoleManager.Roles;

            var projects = from p in Context.Projects
                           select p;

            Projects = await projects
                .Include(p => p.Tickets)
                .ToListAsync();
        }
    }
}
