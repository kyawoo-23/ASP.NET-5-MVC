using Microsoft.EntityFrameworkCore;
using ModelBindingDemo.Models;
using System.Diagnostics;

namespace ModelBindingDemo.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Developer> Developers { get; set; }

        public DbSet<Note> Notes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

    }
}
