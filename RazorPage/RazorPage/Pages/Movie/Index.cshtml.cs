using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage.Models;

namespace RazorPage.Pages.Movie
{
    public class IndexModel : PageModel
    {
        private readonly RazorPage.Models.RazorPageContext _context;

        public IndexModel(RazorPage.Models.RazorPageContext context)
        {
            _context = context;
        }

        public IList<Models.Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
