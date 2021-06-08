using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPageDemoProject.Pages.Movies
{
    public class DashboardModel : PageModel
    {
        private readonly RazorPageDemoProject.Data.RazorPageDemoProjectContext _context;

        public DashboardModel(RazorPageDemoProject.Data.RazorPageDemoProjectContext context)
        {
            _context = context;
        }

        /* public void OnGet()
         {
         }*/

        public string Session { get; set; }

        public IActionResult OnGet()
        {
            Session = HttpContext.Session.GetString("username");
            if (Session != null)
            {
                return Page();
            }
            return RedirectToPage("./LoginPage");
        }
    }
}
