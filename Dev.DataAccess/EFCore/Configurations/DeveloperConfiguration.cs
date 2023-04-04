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
    public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
    {
        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.Property(d => d.Name).IsRequired();
            builder.Property(d => d.Gender).IsRequired();
            builder.Property(d => d.Type).IsRequired();
        }
    }
}
