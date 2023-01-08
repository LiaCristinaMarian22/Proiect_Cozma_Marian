using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_Cozma_Marian.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Display(Name = "Movie Name")]

        public string Name { get; set; }
        public string Director { get; set; }

        public string Actor { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public ICollection<MovieGenre>? MovieGenres { get; set; }



    }
}
