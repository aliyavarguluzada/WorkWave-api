namespace WorkWaveApp.Infrastructure.Data.Configuration
{
    public class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.StatusId).IsRequired();
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.Phone).IsRequired();
            builder.Property(c => c.Subject).IsRequired();
        }
    }
}
