using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apartments.Models
{
    public class Apartment
    {

        public int ID { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Real estate for rent ")]
        public string Title { get; set; }


        public int? OwnerID { get; set; }
        public Owner? Owner { get; set; }


        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 1000)]
        public decimal Price { get; set; }



        [DataType(DataType.Date)]
        public DateTime Date { get; set; }


        public int?     AgentID { get; set; }
        public Agent? Agent { get; set; }

        public ICollection<Apartamentcategory>? Apartmentcategories { get; set; }
    }

}
