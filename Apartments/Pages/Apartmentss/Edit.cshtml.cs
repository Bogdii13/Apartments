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
    public class EditModel : PageModel
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

            var apartment =  await _context.Apartment.FirstOrDefaultAsync(m => m.ID == id);
            if (apartment == null)
            {
                return NotFound();
            }
            Apartment = apartment;
           ViewData["AgentID"] = new SelectList(_context.Agent, "ID", "Agentname");
           ViewData["OwnerID"] = new SelectList(_context.Owner, "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Apartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApartmentExists(Apartment.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ApartmentExists(int id)
        {
          return _context.Apartment.Any(e => e.ID == id);
        }
    }
}
