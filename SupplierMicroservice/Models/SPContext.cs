using Microsoft.EntityFrameworkCore;
using SupplierMicroservice.Models;

namespace SupplierMicroservice.Models
{
    public class SPContext: DbContext
    {
        public SPContext(DbContextOptions<SPContext>options):base(options) { }
        public DbSet<Supplier_Part> Parts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierPart> SupplierParts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupplierPart>()
                .HasKey(k => new { k.SID, k.PID });
            modelBuilder.Entity<SupplierPart>()
                .HasOne(t => t.Supplier)
                .WithMany(t => t.PartsLink)
                .HasForeignKey(p => p.SID);
            modelBuilder.Entity<SupplierPart>()
                .HasOne(t => t.Supplier_Part)
                .WithMany(t => t.SuppliersLink)
                .HasForeignKey(p => p.PID);
        }
    }
    
}
