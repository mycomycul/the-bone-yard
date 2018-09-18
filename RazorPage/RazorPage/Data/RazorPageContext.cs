using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorPage.Models
{
    public class RazorPageContext : DbContext
    {
        public RazorPageContext (DbContextOptions<RazorPageContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPage.Models.Movie> Movie { get; set; }
    }
}
