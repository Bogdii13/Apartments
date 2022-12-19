using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Apartments.Data;
using Apartments.Models;
using Microsoft.EntityFrameworkCore;

namespace Apartments.Pages.Apartmentss
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

            var ownerList = _context.Owner.Select(x => new
            {
                x.ID,
                FullName = x.FirstName + " " + x.LastName
            });
            ViewData["OwnerID"] = new SelectList(ownerList, "ID", "FullName");
            ViewData["AgentID"] = new SelectList(_context.Set<Models.Agent>(), "ID", "AgentName");
            return Page();
        }

        [BindProperty]
        public Apartment Apartment { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Apartment.Add(Apartment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
