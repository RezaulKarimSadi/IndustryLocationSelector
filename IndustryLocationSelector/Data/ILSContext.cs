using IndustryLocationSelector.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndustryLocationSelector.Data
{
    public class ILSContext:DbContext
    {
        public DbSet<Organizations> Organizations { get; set; }
        public DbSet<OrganizationType> OrganizationType { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<PlaceType> PlaceType { get; set; }

        public ILSContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organizations>().HasOne(o=>o.OrganizationType).WithMany(ot=>ot.Organizations).HasForeignKey(o=>o.OrganizationTypeId);

            modelBuilder.Entity<Place>().HasOne(p => p.PlaceType).WithMany(pt => pt.Places).HasForeignKey(pt => pt.PlaceTypeId);
        
            base.OnModelCreating(modelBuilder);
        }
    }
}
