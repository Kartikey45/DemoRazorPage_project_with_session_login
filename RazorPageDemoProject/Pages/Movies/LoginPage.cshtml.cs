using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageDemoProject.Models;

namespace RazorPageDemoProject.Pages.Movies
{
    public class LoginPageModel : PageModel
    {
        private readonly RazorPageDemoProject.Data.RazorPageDemoProjectContext _context;

        public LoginPageModel(RazorPageDemoProject.Data.RazorPageDemoProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LoginCred loginCred { get; set; }
        public string Message { get; set; }
        public string Session1 { get; set; }
        public string Session2 { get; set; }

        public IActionResult OnGet()
        {
            Session1 = HttpContext.Session.GetString("username");
            HttpContext.Session.Remove("username");
            Session2 = HttpContext.Session.GetString("username");
            return Page();
        }
      /*  public IActionResult OnGetLogout()
        {
            Session1 = HttpContext.Session.GetString("username");
            HttpContext.Session.Remove("username");
            Session2 = HttpContext.Session.GetString("username");
            return Page();
        }*/
        public IActionResult OnPostAsync()
        {
            var result = _context.UserCredentials.Where(u => u.Username.Equals(loginCred.Username) && u.Password.Equals(loginCred.Password)).FirstOrDefault();

            if (result != null)
            {
                HttpContext.Session.SetString("username", loginCred.Username);
                return RedirectToPage("./Index");
            }
            else if(string.IsNullOrEmpty(loginCred.Username) || string.IsNullOrEmpty(loginCred.Password))
            {
                
                return Page();
            }
            else
            {
                Message = "Entered Invalid login credentials.";
                return Page();
            }
        }
    }
}
