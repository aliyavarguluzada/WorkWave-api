namespace WorkWaveApp.Infrastructure.Data.Configuration
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.Property(c => c.Name).IsRequired();
        }
    }
}
