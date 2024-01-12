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
    public class JobCategoryConfiguration : IEntityTypeConfiguration<JobCategory>
    {
        public void Configure(EntityTypeBuilder<JobCategory> builder)
        {
            builder.Property(c => c.Name).IsRequired();
        }
    }
}
