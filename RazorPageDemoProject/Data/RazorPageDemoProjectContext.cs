using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPageDemoProject.Models;

namespace RazorPageDemoProject.Data
{
    public class RazorPageDemoProjectContext : DbContext
    {
        public RazorPageDemoProjectContext (DbContextOptions<RazorPageDemoProjectContext> options) : base(options)
        {

        }

        public DbSet<RazorPageDemoProject.Models.Movie> Movie { get; set; }

        public DbSet<RazorPageDemoProject.Models.LoginCred> UserCredentials { get; set; }
    }
}
