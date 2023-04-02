using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelBindingDemo.Models;
using System.Diagnostics;

namespace ModelBindingDemo.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Developer> Developers { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<DeveloperSkill> DeveloperSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Developer>()
                .Property(d => d.Name)
                .IsRequired();
            builder.Entity<Developer>()
                .Property(d => d.Gender)
                .IsRequired();
            builder.Entity<Developer>()
                .Property(d => d.Type)
                .IsRequired();

            builder.Entity<Note>()
                .Property(n => n.Title)
                .IsRequired();
            builder.Entity<Note>()
                .Property(n => n.Content)
                .IsRequired();

            builder.Entity<Skill>()
                .Property(s => s.SkillName)
                .IsRequired();
            builder.Entity<Skill>()
                .HasIndex(s => s.SkillName)
                .IsUnique();
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
