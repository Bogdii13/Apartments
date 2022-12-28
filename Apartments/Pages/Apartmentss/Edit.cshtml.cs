using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Apartments.Data;
using Apartments.Models;


namespace Apartments.Pages.Apartmentss
{
    public class EditModel :  ApartamentCategoriesPageModel
    {
        private readonly Apartments.Data.ApartmentsContext _context;

        public EditModel(Apartments.Data.ApartmentsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Apartment Apartment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Apartment == null)
            {
                return NotFound();
            }


            Apartment = await _context.Apartment
 .Include(b => b.Agent)
 .Include(b => b.Apartmentcategories).ThenInclude(b => b.Category)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);


            var apartment =  await _context.Apartment.FirstOrDefaultAsync(m => m.ID == id);
            if (apartment == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Apartment);
            Apartment = apartment;
            var ownerList = _context.Owner.Select(x => new
            {
                x.ID,
                FullName = x.FirstName + " " + x.LastName
            });
            ViewData["OwnerID"] = new SelectList(ownerList, "ID", "FullName");
            ViewData["AgentID"] = new SelectList(_context.Set<Models.Agent>(), "ID", "AgentName");
            return Page();
        }


       

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ApartmentToUpdate = await _context.Apartment
            .Include(i => i.Agent)
            .Include(i => i.Apartmentcategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (ApartmentToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Apartment>(
            ApartmentToUpdate,
            "Apartment",
            i => i.Title, i => i.Owner,
            i => i.Price, i => i.Date, i => i.Agent))
            {
                UpdateApartamentcategories(_context, selectedCategories, ApartmentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care 
            //este editata 
            UpdateApartmentcategories(_context, selectedCategories, ApartmentToUpdate);
            PopulateAssignedCategoryData(_context, ApartmentToUpdate);
            return Page();
        }
    }

}
