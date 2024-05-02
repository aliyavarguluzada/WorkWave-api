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
