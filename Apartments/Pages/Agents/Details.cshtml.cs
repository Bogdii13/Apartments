using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Apartments.Data;
using Apartments.Models;

namespace Apartments.Pages.Agents
{
    public class DetailsModel : PageModel
    {
        private readonly Apartments.Data.ApartmentsContext _context;

        public DetailsModel(Apartments.Data.ApartmentsContext context)
        {
            _context = context;
        }

      public Agent Agent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Agent == null)
            {
                return NotFound();
            }

            var agent = await _context.Agent.FirstOrDefaultAsync(m => m.ID == id);
            if (agent == null)
            {
                return NotFound();
            }
            else 
            {
                Agent = agent;
            }
            return Page();
        }
    }
}
