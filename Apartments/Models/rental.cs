using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Apartments.Models
{
    public class Rental
    {

        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? ApartmentID { get; set; }
        public Apartment? Apartment { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
