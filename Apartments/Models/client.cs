using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Apartments.Models
{
    public class Client
    {
        public int ID { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "The first name must start with a capital letter (eg Ana or Ana Maria or AnaMaria)")]
        [StringLength(30, MinimumLength = 3)]
        public string? FirstName { get; set; }


        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string? LastName { get; set; }


        [StringLength(70)]
        public string? Adress { get; set; }

        public string Email { get; set; }


        //[RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", ErrorMessage = "The phone must be in shape '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
        [RegularExpression(@"^([0]{1})[-. ]?([0-9]{3})?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$",
           ErrorMessage = "The phone number must start with the number 0!")]
        public string? Phone { get; set; }


        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public ICollection<Rental>? Rentals { get; set; }
    }
}
