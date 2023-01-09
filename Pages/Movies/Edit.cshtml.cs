using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Cozma_Marian.Data;
using Proiect_Cozma_Marian.Models;

namespace Proiect_Cozma_Marian.Pages.Movies
{
    [Authorize(Roles = "Admin")]
    public class EditModel : MovieGenrePageModel
    {
        private readonly Proiect_Cozma_Marian.Data.Proiect_Cozma_MarianContext _context;

        public EditModel(Proiect_Cozma_Marian.Data.Proiect_Cozma_MarianContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movie == null)
            {
                return NotFound();
            }
            Movie = await _context.Movie
 .Include(b => b.MovieGenres).ThenInclude(m => m.Genre)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);

            //var movie =  await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);
            if (Movie == null)
            {
                return NotFound();
            }
            PopulateAssignedGenreData(_context, Movie);
            //Movie = movie;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedGenres)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movieToUpdate = await _context.Movie
            .Include(i => i.MovieGenres)
            .ThenInclude(i => i.Genre)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (movieToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Movie>(
            movieToUpdate,
            "Movie",
            i => i.Name, i => i.Director,
             i => i.ReleaseDate))
            {
                UpdateMovieGenres(_context, selectedGenres, movieToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateMovieGenres(_context, selectedGenres, movieToUpdate);
            PopulateAssignedGenreData(_context, movieToUpdate);
            return Page();
        }
    }
}
