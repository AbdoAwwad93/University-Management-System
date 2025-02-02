using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Managment_system.Entity;

namespace University_Managment_system.Data.config
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(admin => admin.Id);
            builder.Property(admin => admin.Id).ValueGeneratedNever();
            builder.Property(admin => admin.FullName).HasColumnName("Full Name")
                .HasColumnType("Varchar(50)");
             builder.Property(admin => admin.Password).HasColumnName("Password")
                .HasColumnType("Varchar(50)");

            builder.HasOne(admin => admin.Department)
                 .WithOne(dep => dep.Admin)
                 .HasForeignKey<Admin>(admin => admin.DeptId).IsRequired();

            builder.ToTable("Admins");
            builder.HasData(LoadData());
        }

        private List<Admin> LoadData()
        {
            return new List<Admin>()
            {
                new Admin { Id = 101, FullName = "Ahmed Mohamed", Password = "admin123", Email = "ahmed.mohamed@university.edu.eg", DeptId = 1 },
                new Admin { Id = 102, FullName = "Mona Ali", Password = "admin456", Email = "mona.ali@university.edu.eg", DeptId = 2 },
                new Admin { Id = 103, FullName = "Youssef Hassan", Password = "admin789", Email = "youssef.hassan@university.edu.eg", DeptId = 3 },
                new Admin { Id = 104, FullName = "Fatma Mahmoud", Password = "admin101", Email = "fatma.mahmoud@university.edu.eg", DeptId = 4 },
            };
        }
    }
}