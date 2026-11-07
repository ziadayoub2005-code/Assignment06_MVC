using Microsoft.EntityFrameworkCore;
using MVCGiza02.Models;

namespace MVCGiza02.Data.DbContexts
{
    public class DigitalDbContext : DbContext
    {
        // .NET 8.0 : 
        // Encryption - Data Protection - .. 
        // Server - DB - Auth - ..
        // Server - DB - Auth + Encryption + Trustservercert - .. 
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Digital;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        }

        // Dbsets ? Not a must !!
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfigurations());
            modelBuilder.ApplyConfiguration(new EmployeeConfigurations());
        }
    }
}
