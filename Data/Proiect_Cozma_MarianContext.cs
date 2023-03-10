using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Cozma_Marian.Models;

namespace Proiect_Cozma_Marian.Data
{
    public class Proiect_Cozma_MarianContext : DbContext
    {
        
        public Proiect_Cozma_MarianContext (DbContextOptions<Proiect_Cozma_MarianContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Cozma_Marian.Models.Movie> Movie { get; set; } = default!;

        public DbSet<Proiect_Cozma_Marian.Models.Genre> Genre { get; set; }

        public DbSet<Proiect_Cozma_Marian.Models.User> User { get; set; }

        public DbSet<Proiect_Cozma_Marian.Models.Booking> Booking { get; set; }

        public DbSet<Proiect_Cozma_Marian.Models.Schedule> Schedule { get; set; }

        public DbSet<Proiect_Cozma_Marian.Models.Offer> Offer { get; set; }
    }
}
