using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Managment_system.Entity;

namespace University_Managment_system.Data.config
{
    public partial class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(student => student.Id);
            builder.Property(student => student.Id).ValueGeneratedNever();
            builder.Property(student => student.FullName).HasColumnName("Full Name")
                .HasColumnType("Varchar(50)");
            builder.Property(student => student.Password).HasColumnName("Password")
               .HasColumnType("Varchar(50)");
            builder.Property(doctor => doctor.Email).HasColumnName("Email")
               .HasColumnType("Varchar(50)");

            builder.HasMany(student => student.Courses)
                .WithMany(course => course.Students)
                .UsingEntity<Enrollment>();

            builder.HasOne(student => student.Department)
                .WithMany(dep => dep.Students)
                .HasForeignKey(student => student.DeptId).OnDelete(DeleteBehavior.NoAction);
            builder.HasData(LoadData());
            builder.ToTable("Students");
        }

        private List<Student> LoadData()
        {
            return new List<Student> {
              new Student { Id = 401, FullName = "Mohamed Ahmed", Password = "student123", Email = "mohamed.ahmed@university.edu.eg", DeptId = 1, GPA = 3.5, level = 1 },
              new Student { Id = 402, FullName = "Ali Hassan", Password = "student456", Email = "ali.hassan@university.edu.eg", DeptId = 2, GPA = 3.8, level = 2 },
              new Student { Id = 403, FullName = "Fatma Mahmoud", Password = "student789", Email = "fatma.mahmoud@university.edu.eg", DeptId = 3, GPA = 3.6, level = 1 },
              new Student { Id = 404, FullName = "Youssef Ali", Password = "student101", Email = "youssef.ali@university.edu.eg", DeptId = 4, GPA = 3.9, level = 2 },
              new Student { Id = 405, FullName = "Nada Samir", Password = "student202", Email = "nada.samir@university.edu.eg", DeptId = 1, GPA = 3.7, level = 3 },
              new Student { Id = 406, FullName = "Karim Adel", Password = "student303", Email = "karim.adel@university.edu.eg", DeptId = 2, GPA = 3.4, level = 4 },                  
              new Student { Id = 407, FullName = "Hana Tarek", Password = "student404", Email = "hana.tarek@university.edu.eg", DeptId = 3, GPA = 3.8, level = 3 },
              new Student { Id = 408, FullName = "Omar Ibrahim", Password = "student505", Email = "omar.ibrahim@university.edu.eg", DeptId = 4, GPA = 3.6, level = 4 },
              new Student { Id = 409, FullName = "Rana Sherif", Password = "student606", Email = "rana.sherif@university.edu.eg", DeptId = 1, GPA = 3.9, level = 1 },
              new Student { Id = 410, FullName = "Tamer Nabil", Password = "student707", Email = "tamer.nabil@university.edu.eg", DeptId = 2, GPA = 3.5, level = 2 },
              new Student { Id = 411, FullName = "Dina Hossam", Password = "student808", Email = "dina.hossam@university.edu.eg", DeptId = 3, GPA = 3.7, level = 1 },
              new Student { Id = 412, FullName = "Sherif Omar", Password = "student909", Email = "sherif.omar@university.edu.eg", DeptId = 4, GPA = 3.8, level = 2 },
              new Student { Id = 413, FullName = "Laila Ahmed", Password = "student1010", Email = "laila.ahmed@university.edu.eg", DeptId = 1, GPA = 3.6, level = 3 },
              new Student { Id = 414, FullName = "Hassan Mohamed", Password = "student1111", Email = "hassan.mohamed@university.edu.eg", DeptId = 2, GPA = 3.9, level = 4 },
              new Student { Id = 415, FullName = "Nour Ali", Password = "student1212", Email = "nour.ali@university.edu.eg", DeptId = 3, GPA = 3.5, level = 3 },
              new Student { Id = 416, FullName = "Amr Tarek", Password = "student1313", Email = "amr.tarek@university.edu.eg", DeptId = 4, GPA = 3.7, level = 4 },
              new Student { Id = 417, FullName = "Sara Khaled", Password = "student1414", Email = "sara.khaled@university.edu.eg", DeptId = 1, GPA = 3.8, level = 1 },
              new Student { Id = 418, FullName = "Kareem Samir", Password = "student1515", Email = "kareem.samir@university.edu.eg", DeptId = 2, GPA = 3.6, level = 2 },
              new Student { Id = 419, FullName = "Dalia Adel", Password = "student1616", Email = "dalia.adel@university.edu.eg", DeptId = 3, GPA = 3.9, level = 1 },
              new Student { Id = 420, FullName = "Ahmed Youssef", Password = "student1717", Email = "ahmed.youssef@university.edu.eg", DeptId = 4, GPA = 3.7, level = 2 }
        };
        }
    }
}
