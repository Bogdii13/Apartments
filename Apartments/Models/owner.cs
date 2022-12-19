using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Apartments.Models
{
    public class Owner
    {


        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Owner Name")]
        public string FullName { get { return FirstName + " " + LastName; } }

        public ICollection<Apartment>? Apartments { get; set; }
    }
}
