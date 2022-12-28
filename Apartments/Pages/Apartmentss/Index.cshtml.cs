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
    public class IndexModel : PageModel
    {
        private readonly Apartments.Data.ApartmentsContext _context;

        public IndexModel(Apartments.Data.ApartmentsContext context)
        {
            _context = context;
        }

        public IList<Apartment> Apartment { get;set; } = default!;

        public ApartmentData ApartmentD { get; set; }
        public int ApartmentID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            ApartmentD = new ApartmentData();

            ApartmentD.Apartments = await _context.Apartment
            .Include(b => b.Agent)
            .Include(b => b.Apartmentcategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
            if (id != null)
            {
                ApartmentID = id.Value;
                Apartment book = ApartmentD.Apartments
                .Where(i => i.ID == id.Value).Single();
                ApartmentD.Categories = book.Apartmentcategories.Select(s => s.Category);
            }
        }

    }
}

