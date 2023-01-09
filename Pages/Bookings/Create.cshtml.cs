using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Cozma_Marian.Data;
using Proiect_Cozma_Marian.Models;

namespace Proiect_Cozma_Marian.Pages.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Cozma_Marian.Data.Proiect_Cozma_MarianContext _context;

        public CreateModel(Proiect_Cozma_Marian.Data.Proiect_Cozma_MarianContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var movieList = _context.Movie
               // .Include(b => b.Director)
                .Select(x => new
            {
                x.ID,
                MovieFullName = x.Name 
            });

            ViewData["MovieID"] = new SelectList(movieList, "ID", "MovieFullName");
            ViewData["UserID"] = new SelectList(_context.User, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
