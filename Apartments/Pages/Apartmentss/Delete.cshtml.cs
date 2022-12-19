using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Apartments.Data;
using Apartments.Models;

namespace Apartments.Pages.Apartmentss
{
    public class DeleteModel : PageModel
    {
        private readonly Apartments.Data.ApartmentsContext _context;

        public DeleteModel(Apartments.Data.ApartmentsContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Apartment Apartment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Apartment == null)
            {
                return NotFound();
            }

            var apartment = await _context.Apartment.FirstOrDefaultAsync(m => m.ID == id);

            if (apartment == null)
            {
                return NotFound();
            }
            else 
            {
                Apartment = apartment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Apartment == null)
            {
                return NotFound();
            }
            var apartment = await _context.Apartment.FindAsync(id);

            if (apartment != null)
            {
                Apartment = apartment;
                _context.Apartment.Remove(Apartment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
