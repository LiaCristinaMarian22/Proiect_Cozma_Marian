using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Cozma_Marian.Data;
using Proiect_Cozma_Marian.Models;

namespace Proiect_Cozma_Marian.Pages.Movies
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : MovieGenrePageModel
    {
        private readonly Proiect_Cozma_Marian.Data.Proiect_Cozma_MarianContext _context;

        public CreateModel(Proiect_Cozma_Marian.Data.Proiect_Cozma_MarianContext context)
        {
            _context = context;
        }


        public IActionResult OnGet()
        {
            var movie = new Movie();
            movie.MovieGenres = new List<MovieGenre>();

            PopulateAssignedGenreData(_context, movie);

            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedGenres)
        {
            var newMovie = Movie;
            if (selectedGenres != null)
            {
                newMovie.MovieGenres = new List<MovieGenre>();
                foreach (var gen in selectedGenres)
                {
                    var genToAdd = new MovieGenre
                    {
                        GenreID = int.Parse(gen)
                    };
                    newMovie.MovieGenres.Add(genToAdd);
                }
            }

            if (await TryUpdateModelAsync<Movie>(
                 newMovie,
                 "Movie",
                 i => i.Name, i => i.Director, i => i.Actor, i => i.ReleaseDate))
            {

                _context.Movie.Add(newMovie);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            PopulateAssignedGenreData(_context, newMovie);
            return Page();
        }
    }
}