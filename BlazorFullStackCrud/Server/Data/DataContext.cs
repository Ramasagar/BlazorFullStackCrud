namespace BlazorFullStackCrud.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ward>().HasData(
                new Ward { Id = 1, Name = "General" },
                new Ward { Id = 2, Name = "ICU" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor
                {
                    Id = 1,
                    FirstName = "Sukesh",
                    LastName = "D",
                    Specialization = "General Anesthesia",
                    WardId = 1,
                },
                new Doctor
                {
                    Id = 2,
                    FirstName = "Madhu",
                    LastName = "Pilli",
                    Specialization = "Orthopaedics",
                    WardId = 2
                }
            );
        }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Ward> Wards { get; set; }
    }
}
