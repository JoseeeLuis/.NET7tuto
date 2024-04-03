using Microsoft.EntityFrameworkCore;

namespace Clients_Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<WorkerDetails> WorkersDetails { get; set; }
        public DbSet<DepartamentType> DepartamentTypes { get; set; }
        public DbSet <SeniorityType> SeniorityTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().ToTable("Workers");
            modelBuilder.Entity<Worker>().HasKey(u => u.WorkerId);

            modelBuilder.Entity<WorkerDetails>().ToTable("WorkersDetails");
            modelBuilder.Entity<WorkerDetails>().HasKey(u => u.WorkerDetailsId);

            modelBuilder.Entity<Address>().ToTable("Addresses");
            modelBuilder.Entity<Address>().HasKey(u => u.AddressId);

            modelBuilder.Entity<DepartamentType>().ToTable("Departaments");
            modelBuilder.Entity<DepartamentType>().HasKey(u => u.DepartamentTypeCode);

            modelBuilder.Entity<SeniorityType>().ToTable("Seniorities");
            modelBuilder.Entity<SeniorityType>().HasKey(u => u.SeniorityTypeCode);

            modelBuilder.Entity<WorkerDetails>()
                .Property(w => w.Salary)
                .HasColumnType("decimal(18,2)");
            
            modelBuilder.Entity<Worker>()
                .HasOne(w => w.WorkerDetails)
                .WithMany()
                .HasForeignKey(d => d.WorkerDetailsId);
 
            modelBuilder.Entity<WorkerDetails>()
                .HasOne(W => W.SeniorityType)
                .WithMany()
                .HasForeignKey(w => w.SeniorityTypeCode);

            modelBuilder.Entity<WorkerDetails>()
                .HasOne(w => w.DepartamentType)
                .WithMany()
                .HasForeignKey(w => w.DepartamentTypeCode);
        }
    }
}
