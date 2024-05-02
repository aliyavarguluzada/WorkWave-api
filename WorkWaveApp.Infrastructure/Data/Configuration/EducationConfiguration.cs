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
