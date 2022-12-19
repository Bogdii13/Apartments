namespace Apartments.Models
{
    public class Category
    {

        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Apartamentcategory>? ApartmentCategories { get; set; }
    }
}
