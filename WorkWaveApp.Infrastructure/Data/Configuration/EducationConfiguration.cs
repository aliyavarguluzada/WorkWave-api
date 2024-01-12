using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkWaveApp.Domain.Entities;

namespace WorkWaveApp.Infrastructure.Data.Configuration
{
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.Property(c => c.Name).IsRequired();
        }
    }
}
