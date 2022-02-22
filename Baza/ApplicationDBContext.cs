using Kodius.Modeli;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kodius.Baza
{
    public class ApplicationDBContext: IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Stock> Zaliha { get; set; }
        public DbSet<Order> Narudzbe { get; set; }
        public DbSet<OrderProduct> NaruceniProizvodi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderProduct>().HasKey(x => new {x.proizvodId, x.NarudzbaId}); 
        }
    }
}
