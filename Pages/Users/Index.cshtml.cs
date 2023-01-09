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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Cozma_Marian.Data.Proiect_Cozma_MarianContext _context;

        public IndexModel(Proiect_Cozma_Marian.Data.Proiect_Cozma_MarianContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.User != null)
            {
                User = await _context.User.ToListAsync();
            }
        }
    }
}
