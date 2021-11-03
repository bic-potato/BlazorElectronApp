using BlazorElectronApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorElectronApp.Data
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./data.db");
        }

        public DbSet<Cat> Cats { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
