using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Dev.Entities.Models;
using Dev.DataAccess.EFCore.Configurations;

namespace ModelBindingDemo.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-L27SV6P\\SQLEXPRESS;Database=EFCoreTesting;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<DeveloperSkill> DeveloperSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DeveloperConfiguration());
            builder.ApplyConfiguration(new NoteConfiguration());
            builder.ApplyConfiguration(new SkillConfiguration());

            base.OnModelCreating(builder);
        }

        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{
        //}

    }
}
