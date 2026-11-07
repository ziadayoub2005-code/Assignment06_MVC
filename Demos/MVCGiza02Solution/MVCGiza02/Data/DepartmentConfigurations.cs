using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCGiza02.Models;

namespace MVCGiza02.Data
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Db object
            builder.ToTable("Departments");

            // PK 
            builder.HasKey(d => d.Id);

            // Properties
            builder.Property(d => d.Name)
                .HasMaxLength(50);
            builder.Property(D=>D.Mgrname)
                .HasMaxLength(50);
        }
    }
}
