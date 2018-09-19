﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public SelectList Genres { get; set; }
        public string  MovieGenre { get; set; }

        public async Task OnGetAsync(string searchString, string movieGenre)
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
