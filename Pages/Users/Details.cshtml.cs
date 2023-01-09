using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Cozma_Marian.Data;
using Proiect_Cozma_Marian.Models;

namespace Proiect_Cozma_Marian.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Cozma_Marian.Data.Proiect_Cozma_MarianContext _context;

        public DetailsModel(Proiect_Cozma_Marian.Data.Proiect_Cozma_MarianContext context)
        {
            _context = context;
        }

      public User User { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User.FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                User = user;
            }
            return Page();
        }
    }
}
