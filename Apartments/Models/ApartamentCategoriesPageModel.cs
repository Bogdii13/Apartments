using Microsoft.AspNetCore.Mvc.RazorPages;
using Apartments.Data;

namespace Apartments.Models
{
    public class ApartamentCategoriesPageModel:PageModel
    {

        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(ApartmentsContext context,
        Apartment Apartment)
        {
            var allCategories = context.Category;
            var Apartmentcategories = new HashSet<int>(
            Apartment.Apartmentcategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = Apartmentcategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateApartamentcategories(ApartmentsContext context,
        string[] selectedCategories, Apartment ApartmentToUpdate)
        {
            if (selectedCategories == null)
            {
                ApartmentToUpdate.Apartmentcategories = new List<Apartamentcategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var Apartmentcategories = new HashSet<int>
            (ApartmentToUpdate.Apartmentcategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!Apartmentcategories.Contains(cat.ID))
                    {
                        ApartmentToUpdate.Apartmentcategories.Add(
                        new Apartamentcategory
                        {
                            ApartmentID = ApartmentToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (Apartmentcategories.Contains(cat.ID))
                    {
                        Apartamentcategory courseToRemove
                        = ApartmentToUpdate.Apartmentcategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }


    }
}
