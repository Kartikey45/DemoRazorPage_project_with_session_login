using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPageDemoProject.Data;
using RazorPageDemoProject.Models;

namespace RazorPageDemoProject.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPageDemoProject.Data.RazorPageDemoProjectContext _context;

        public CreateModel(RazorPageDemoProject.Data.RazorPageDemoProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
