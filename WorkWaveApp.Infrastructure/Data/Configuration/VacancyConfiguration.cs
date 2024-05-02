namespace WorkWaveApp.Infrastructure.Data.Configuration
{
    public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.CompanyId).IsRequired();
            builder.Property(c => c.JobTypeId).IsRequired();
            builder.Property(c => c.JobCategoryId).IsRequired();
            builder.Property(c => c.StatusId).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.EducationId).IsRequired();
            builder.Property(c => c.ExperienceId).IsRequired();
            builder.Property(c => c.WorkFormId).IsRequired();
        }
    }
}
