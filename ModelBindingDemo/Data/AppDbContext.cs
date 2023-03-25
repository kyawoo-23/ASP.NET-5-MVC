using Microsoft.EntityFrameworkCore;
using ModelBindingDemo.Models;
using System.Diagnostics;

namespace ModelBindingDemo.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Developer> Developers { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<DeveloperSkill> DeveloperSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<DeveloperSkill>().HasKey(ds => new { 
            //    ds.DeveloperSkillId, 
            //    ds.DeveloperId, 
            //    ds.SkillId 
            //});
        }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

    }
}
