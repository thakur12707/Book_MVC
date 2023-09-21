using Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Movies> Movies { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movies>().HasData(
                new Movies { Id =1,Name="Action", DisplayOrder = 1 },
                new Movies { Id = 2, Name = "Scifi", DisplayOrder = 2 },
                new Movies { Id = 3, Name = "History", DisplayOrder = 3 }
            ); 
        }

    }
}
