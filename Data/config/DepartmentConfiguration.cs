using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Managment_system.Entity;

namespace University_Managment_system.Data.config
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(dep => dep.Id);
            builder.Property(dep => dep.Id).ValueGeneratedNever();
            builder.Property(doctor => doctor.Name).HasColumnName("Name")
                .HasColumnType("Varchar(50)");
            builder.HasData(LoadData());
        }

        private List<Department> LoadData()
        {
            return new List<Department> {
                 new Department { Id = 1, DeptCode = "CS", Name = "Computer Science", Description = "Department of Computer Science" },
                 new Department { Id = 2, DeptCode = "IT", Name = "Information Technology", Description = "Department of Information Technology" },
                 new Department { Id = 3, DeptCode = "IS", Name = "Information Systems", Description = "Department of Information Systems" },
                 new Department { Id = 4, DeptCode = "AI", Name = "Artificial Intelligence", Description = "Department of Artificial Intelligence" }
           };
        }
    }
}