using Microsoft.EntityFrameworkCore;
using Szakmak.Models;

namespace Szakmak.Data
{
    public class SzakmakDbContext: DbContext
    {
        public SzakmakDbContext(DbContextOptions<SzakmakDbContext> options): base(options)
        {
            
        }

        public DbSet<Szakma> Szakmak { get; set; }
        public DbSet<Orszag> Orszagok { get; set; }
        public DbSet<Versenyzo> Versenyzok { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Versenyzo>()
                .HasOne(S=>S.Szakma).WithMany(V=> V.Versenyzok)
                .HasForeignKey(S=>S.SzakmaId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Versenyzo>()
               .HasOne(S => S.Orszag).WithMany(V => V.Versenyzok)
               .HasForeignKey(S => S.OrszagId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
