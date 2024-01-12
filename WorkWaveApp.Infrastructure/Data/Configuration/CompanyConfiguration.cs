using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWaveApp.Domain.Entities;

namespace WorkWaveApp.Infrastructure.Data.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(c=>c.Name).IsRequired();
            builder.Property(c=>c.Email).IsRequired();
            builder.Property(c=>c.Logo).IsRequired();
            builder.Property(c=>c.Phone).IsRequired();
        }
    }
}
