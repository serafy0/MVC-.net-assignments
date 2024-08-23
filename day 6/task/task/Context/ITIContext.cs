using Microsoft.EntityFrameworkCore;
using task.Models;

namespace task.Context
{
    public class ITIContext: DbContext
    {
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }

        public ITIContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set conditions/contrains that can be set in the database
            modelBuilder.Entity<Drug>(
                bldr =>
                {
                    bldr.HasOne(d => d.Company).WithMany(c=>c.Drugs).HasForeignKey(d=>d.CompanyID);
                    bldr.HasKey(d => d.ID);
                    bldr.Property(d => d.Name).IsRequired().HasMaxLength(50);
                    bldr.Property(d => d.ImagePath).IsRequired();
                    bldr.Property(d => d.ManufactureDate).IsRequired();
                    bldr.Property(d => d.ExpirationDate).IsRequired();


                });
            modelBuilder.Entity<Company>(
                blder => {
                    blder.Property(c => c.Name).HasDefaultValue("NA");

                }
                );
        }
    }
}
