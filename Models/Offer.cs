using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proiect_Cozma_Marian.Models
{
    public class Offer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName = "decimal(7,3)")]
        [Range(0.01, 505)]
        public decimal Price { get; set; }
    }
}
