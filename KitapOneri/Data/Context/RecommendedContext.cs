using Microsoft.EntityFrameworkCore;
using KitapOneri.Data.Entities;
using Microsoft.AspNetCore.Authentication;
using KitapOneri.Data.Configuration.BookConfiguration;
using KitapOneri.Data.Configuration.UserConfiguration;

namespace KitapOneri.Data.Context
{
    public class RecommendedContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public RecommendedContext(DbContextOptions<RecommendedContext> options) : base(options)
        {
        }

        public RecommendedContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.Entity<Book>().HasMany(x => x.Categories).WithOne(x => x.Book).HasForeignKey(x => x.BookId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
