namespace WorkWaveApp.Infrastructure.Data.Configuration
{
    public class JobTypeConfiguration : IEntityTypeConfiguration<JobType>
    {
        public void Configure(EntityTypeBuilder<JobType> builder)
        {
            builder.Property(c=>c.Name).IsRequired();
        }
    }
}
