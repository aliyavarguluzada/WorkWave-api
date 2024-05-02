namespace WorkWaveApp.Infrastructure.Data.Configuration
{
    public class WorkFormConfiguration : IEntityTypeConfiguration<WorkForm>
    {
        public void Configure(EntityTypeBuilder<WorkForm> builder)
        {
            builder.Property(c => c.Name).IsRequired();
        }
    }
}
