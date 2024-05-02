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
