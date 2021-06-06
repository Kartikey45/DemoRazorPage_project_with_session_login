using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPageDemoProject.Data;
using RazorPageDemoProject.Models;

namespace RazorPageDemoProject.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPageDemoProject.Data.RazorPageDemoProjectContext _context;

        public IndexModel(RazorPageDemoProject.Data.RazorPageDemoProjectContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }
        public string Username { get; set; }
        public string Session { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Session = HttpContext.Session.GetString("username");
            if(Session != null)
            {
                Username = HttpContext.Session.GetString("username");
                Movie = await _context.Movie.ToListAsync();
                return Page();
            }
            return RedirectToPage("./LoginPage");
        }
    }
}
