using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Apartments.Data;
using Apartments.Models;

namespace Apartments.Pages.Rentals
{
    public class CreateModel : PageModel
    {
        private readonly Apartments.Data.ApartmentsContext _context;

        public CreateModel(Apartments.Data.ApartmentsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ApartmentID"] = new SelectList(_context.Apartment, "ID", "Title");
        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Rental Rental { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rental.Add(Rental);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
