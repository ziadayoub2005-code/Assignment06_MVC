using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCGiza02.Models;

namespace MVCGiza02.Data
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Dbobjects : table / schema / View / ... 
            builder.ToTable("Employees");

            // PK 
            builder.HasKey(E => E.Id);

            // Properties 
            builder.Property(E => E.Name)
                .HasMaxLength(100);
            builder.Property(E => E.Title)
                .HasMaxLength(50);
            builder.Property(E => E.Address)
                .HasMaxLength(50);

            // relationship 
            builder.HasOne(E=>E.Dept)
                .WithMany(D => D.Emps)
                .HasForeignKey(E => E.DeptId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
