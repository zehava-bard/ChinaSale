using Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Project.DAL
{
    public class Context:DbContext
    {
        public DbSet<Presents> Presents { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Donors> Donors { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Purchases> Purchases { get; set; }
        public DbSet<Card> Card { get; set; }

        public Context(DbContextOptions<Context> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>().Property(c => c.Id).UseIdentityColumn(100, 100);
            //modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(6,2)");
            //base.OnModelCreating(modelBuilder);
        }

    }
}
