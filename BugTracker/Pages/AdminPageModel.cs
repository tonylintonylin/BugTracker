using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace BugTracker.Pages
{
    // Users and Roles
    [Authorize(Roles = "Admin")]
    public class AdminPageModel : PageModel
    {
    }
}