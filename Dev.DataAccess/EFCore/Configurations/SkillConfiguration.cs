using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dev.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.DataAccess.EFCore.Configurations
{
    internal class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.Property(s => s.SkillName).IsRequired();
            builder.HasIndex(s => s.SkillName).IsUnique();
        }
    }
}
