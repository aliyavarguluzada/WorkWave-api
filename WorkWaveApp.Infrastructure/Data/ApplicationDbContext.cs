using Microsoft.EntityFrameworkCore;
using WorkWaveApp.Domain.Entities;
using WorkWaveApp.Infrastructure.Data.Configuration;

namespace WorkWaveApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new ContactInfoConfiguration());
            modelBuilder.ApplyConfiguration(new EducationConfiguration());
            modelBuilder.ApplyConfiguration(new ExperienceConfiguration());
            modelBuilder.ApplyConfiguration(new JobCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new JobTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new VacancyConfiguration());
            modelBuilder.ApplyConfiguration(new WorkFormConfiguration());

            base.OnModelCreating(modelBuilder);
        }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //string connection = "User ID=postgres;Password=admin123;Host=localhost;Port=5432;Database=WorkWaveApp;";
        //    string connection = "Data Source=DESKTOP-9RG21DM\\SQLEXPRESS;Initial Catalog=WorkWaveDb;Integrated Security=true;TrustServerCertificate=true";
        //    optionsBuilder.UseNpgsql(connection);
        //    base.OnConfiguring(optionsBuilder);
        //}

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ContactInfo> ContactInfos { get; set; }
        public virtual DbSet<Education> Educations { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<JobCategory> JobCategories { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Vacancy> Vacancies { get; set; }
        public virtual DbSet<WorkForm> WorkForms { get; set; }



    }
}
