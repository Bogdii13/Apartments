namespace Apartments.Models
{
    public class Apartamentcategory
    {
        public int ID { get; set; }
        public int ApartmentID { get; set; }
        public Apartment Apartment { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
