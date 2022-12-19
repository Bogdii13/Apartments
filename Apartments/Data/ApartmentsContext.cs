using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Apartments.Models;

namespace Apartments.Data
{
    public class ApartmentsContext : DbContext
    {
        public ApartmentsContext (DbContextOptions<ApartmentsContext> options)
            : base(options)
        {
        }

        public DbSet<Apartments.Models.Agent> Agent { get; set; } = default!;

        public DbSet<Apartments.Models.Apartment> Apartment { get; set; }

        public DbSet<Apartments.Models.Apartamentcategory> Apartamentcategory { get; set; }

        public DbSet<Apartments.Models.Category> Category { get; set; }

        public DbSet<Apartments.Models.Client> Client { get; set; }

        public DbSet<Apartments.Models.Owner> Owner { get; set; }

        public DbSet<Apartments.Models.Rental> Rental { get; set; }
    }
}
