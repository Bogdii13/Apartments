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
    public class IndexModel : PageModel
    {
        private readonly Apartments.Data.ApartmentsContext _context;

        public IndexModel(Apartments.Data.ApartmentsContext context)
        {
            _context = context;
        }

        public IList<Agent> Agent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Agent != null)
            {
                Agent = await _context.Agent.ToListAsync();
            }
        }
    }
}
