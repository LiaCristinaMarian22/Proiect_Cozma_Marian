using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Cozma_Marian.Data;
using Proiect_Cozma_Marian.Models;

namespace Proiect_Cozma_Marian.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Cozma_Marian.Data.Proiect_Cozma_MarianContext _context;

        public IndexModel(Proiect_Cozma_Marian.Data.Proiect_Cozma_MarianContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;
        public MovieData MovieD { get; set; }
        public int MovieID { get; set; }
        public int GenreID { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? genreID, string searchString)
        {
            MovieD = new MovieData();

            CurrentFilter = searchString;

            MovieD.Movies = await _context.Movie
            .Include(m => m.MovieGenres)
            .ThenInclude(m => m.Genre)
            .AsNoTracking()
            .OrderBy(m => m.Name)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                MovieD.Movies = MovieD.Movies.Where(s => s.Director.Contains(searchString)

               || s.Director.Contains(searchString)
               || s.Name.Contains(searchString));
               
            } 

                if (id != null)
            {
                MovieID = id.Value;
                Movie movie = MovieD.Movies
                .Where(i => i.ID == id.Value).Single();
                MovieD.Genres = movie.MovieGenres.Select(s => s.Genre);
            }
        }
    }
}
