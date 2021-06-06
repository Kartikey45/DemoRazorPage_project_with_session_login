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
    public class DetailsModel : PageModel
    {
        private readonly RazorPageDemoProject.Data.RazorPageDemoProjectContext _context;

        public DetailsModel(RazorPageDemoProject.Data.RazorPageDemoProjectContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }
        public string Session { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Session = HttpContext.Session.GetString("username");
            if (Session != null)
            {
                if (id == null)
                {
                    return NotFound();
                }

                Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

                if (Movie == null)
                {
                    return NotFound();
                }
                return Page();
            }
            return RedirectToPage("./LoginPage");
        }
    }
}
