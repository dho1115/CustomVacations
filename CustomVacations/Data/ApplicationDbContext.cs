using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CustomVacations.Models;

namespace CustomVacations.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<VacationModel> VacationModels { get; set; }
        public DbSet<VacationCategory> vacationCategories { get; set; }
        public DbSet<VacationCart> VacationCarts { get; set; }
        public DbSet<VacationModelVacationCart> VacationModelCarts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        
            builder.Entity<VacationCategory>().HasKey(x => x.CategoryName);

            builder.Entity<VacationCategory>().Property(x => x.DateCreated).HasDefaultValueSql("GetDate()");

            builder.Entity<VacationCategory>().Property(x => x.DateLastModified).HasDefaultValueSql("GetDate()");

            builder.Entity<ApplicationUser>()
                .HasOne(x => x.VacationCart)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey<VacationCart>(x => x.Applicationuserid);
        }
    }
}
