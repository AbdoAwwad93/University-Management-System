using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Managment_system.Entity;

namespace University_Managment_system.Data.config
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(doctor => doctor.Id);
            builder.Property(doctor => doctor.Id).ValueGeneratedNever();
            builder.Property(doctor => doctor.FullName).HasColumnName("Full Name")
                .HasColumnType("Varchar(50)");
            builder.Property(doctor => doctor.Password).HasColumnName("Password")
               .HasColumnType("Varchar(50)");
            builder.Property(doctor => doctor.Email).HasColumnName("Email")
               .HasColumnType("Varchar(50)");

            builder.HasOne(doctor => doctor.Department)
                 .WithMany(dep => dep.Doctors)
                 .HasForeignKey(doc => doc.DeptId);

            builder.HasMany(doc => doc.Courses)
                .WithOne(course => course.Doctor)
                .HasForeignKey(course => course.DoctorId);
            builder.HasData(LoadData());
            builder.ToTable("Doctors");
        }

        private List<Doctor> LoadData()
        {
            return new List<Doctor> {

              new Doctor { Id = 201, FullName = "Dr. Ahmed El-Sayed", Password = "doctor123", Email = "ahmed.elsayed@university.edu.eg", DeptId = 1 },
              new Doctor { Id = 202, FullName = "Dr. Mona Hassan", Password = "doctor456", Email = "mona.hassan@university.edu.eg", DeptId = 2 },
              new Doctor { Id = 203, FullName = "Dr. Youssef Ali", Password = "doctor789", Email = "youssef.ali@university.edu.eg", DeptId = 3 },
              new Doctor { Id = 204, FullName = "Dr. Fatma Mahmoud", Password = "doctor101", Email = "fatma.mahmoud@university.edu.eg", DeptId = 4 },
              new Doctor { Id = 205, FullName = "Dr. Omar Ibrahim", Password = "doctor202", Email = "omar.ibrahim@university.edu.eg", DeptId = 1 },
              new Doctor { Id = 206, FullName = "Dr. Nada Samir", Password = "doctor303", Email = "nada.samir@university.edu.eg", DeptId = 2 },
              new Doctor { Id = 207, FullName = "Dr. Karim Adel", Password = "doctor404", Email = "karim.adel@university.edu.eg", DeptId = 3 },
              new Doctor { Id = 208, FullName = "Dr. Hana Tarek", Password = "doctor505", Email = "hana.tarek@university.edu.eg", DeptId = 4 },
              new Doctor { Id = 209, FullName = "Dr. Ali Khaled", Password = "doctor606", Email = "ali.khaled@university.edu.eg", DeptId = 1 },
              new Doctor { Id = 210, FullName = "Dr. Rana Sherif", Password = "doctor707", Email = "rana.sherif@university.edu.eg", DeptId = 2 },
              new Doctor { Id = 211, FullName = "Dr. Tamer Nabil", Password = "doctor808", Email = "tamer.nabil@university.edu.eg", DeptId = 3 },
              new Doctor { Id = 212, FullName = "Dr. Dina Hossam", Password = "doctor909", Email = "dina.hossam@university.edu.eg", DeptId = 4 },
              new Doctor { Id = 213, FullName = "Dr. Sherif Omar", Password = "doctor1010", Email = "sherif.omar@university.edu.eg", DeptId = 1 },
              new Doctor { Id = 214, FullName = "Dr. Laila Ahmed", Password = "doctor1111", Email = "laila.ahmed@university.edu.eg", DeptId = 2 },
              new Doctor { Id = 215, FullName = "Dr. Hassan Mohamed", Password = "doctor1212", Email = "hassan.mohamed@university.edu.eg", DeptId = 3 },
              new Doctor { Id = 216, FullName = "Dr. Nour Ali", Password = "doctor1313", Email = "nour.ali@university.edu.eg", DeptId = 4 },
              new Doctor { Id = 217, FullName = "Dr. Amr Tarek", Password = "doctor1414", Email = "amr.tarek@university.edu.eg", DeptId = 1 },
              new Doctor { Id = 218, FullName = "Dr. Sara Khaled", Password = "doctor1515", Email = "sara.khaled@university.edu.eg", DeptId = 2 },
              new Doctor { Id = 219, FullName = "Dr. Kareem Samir", Password = "doctor1616", Email = "kareem.samir@university.edu.eg", DeptId = 3 },
              new Doctor { Id = 220, FullName = "Dr. Dalia Adel", Password = "doctor1717", Email = "dalia.adel@university.edu.eg", DeptId = 4 }
            };
        }
    }
}