using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Proiect_Cozma_Marian.Models
{
    public class Booking
    {
        public int ID { get; set; }
        public int? UserID { get; set; }
        public User? User { get; set; }
        public int? MovieID { get; set; }
        public Movie? Movie { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }

        //[DataType(DataType.Time)]
        public DateTime ReturnTime { get; set; }
    }
}
