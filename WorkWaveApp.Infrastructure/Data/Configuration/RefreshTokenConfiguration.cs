namespace WorkWaveApp.Infrastructure.Data.Configuration
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.Property(c => c.IsUsed).IsRequired();
            builder.Property(c => c.IsRevoked).IsRequired();
            builder.Property(c => c.AddedDate).IsRequired();
            builder.Property(c => c.Token).IsRequired();
            builder.Property(c => c.ExpiryDate).IsRequired();
        }
    }
}
