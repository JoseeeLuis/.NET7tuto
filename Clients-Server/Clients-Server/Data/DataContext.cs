using Microsoft.EntityFrameworkCore;

namespace Clients_Server.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }

        public DbSet <Worker> Workers { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet <WorkerDetails> WorkersDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkerDetails>()
                .Property(w => w.Salary)
                .HasColumnType("decimal(18,2)");
        }
    }
}
