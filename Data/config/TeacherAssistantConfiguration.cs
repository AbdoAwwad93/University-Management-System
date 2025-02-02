using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Managment_system.Entity;

namespace University_Managment_system.Data.config
{
    public class TeacherAssistantConfiguration : IEntityTypeConfiguration<TeacherAssistant>
    {
        public void Configure(EntityTypeBuilder<TeacherAssistant> builder)
        {
            builder.HasKey(TA => TA.Id);
            builder.Property(TA => TA.Id).ValueGeneratedNever();
            builder.Property(TA => TA.FullName).HasColumnName("Full Name")
                .HasColumnType("Varchar(50)");
            builder.Property(TA => TA.Email).HasColumnName("Email")
               .HasColumnType("Varchar(50)");

            builder.HasOne(TA => TA.Department)
                 .WithMany(dep => dep.TeacherAssistants)
                 .HasForeignKey(TA => TA.DeptId);

            builder.HasOne(TA => TA.Course)
                .WithMany(course => course.TeacherAssistants)
                .HasForeignKey(TA => TA.CourseId);

            builder.HasData(LoadData());
            builder.ToTable("TeacherAssistants");
        }

        private List<TeacherAssistant> LoadData()
        {
            return new List<TeacherAssistant> {
                  new TeacherAssistant { Id = 501, FullName = "Ahmed Samir", Email = "ahmed.samir@university.edu.eg", DeptId = 1, CourseId = 301 },
                  new TeacherAssistant { Id = 502, FullName = "Mona Adel", Email = "mona.adel@university.edu.eg", DeptId = 2, CourseId = 303 },
                  new TeacherAssistant { Id = 503, FullName = "Youssef Tarek", Email = "youssef.tarek@university.edu.eg", DeptId = 3, CourseId = 305 },
                  new TeacherAssistant { Id = 504, FullName = "Fatma Sherif", Email = "fatma.sherif@university.edu.eg", DeptId = 4, CourseId = 307 },
                  new TeacherAssistant { Id = 505, FullName = "Omar Hossam", Email = "omar.hossam@university.edu.eg", DeptId = 1, CourseId = 309 },
                  new TeacherAssistant { Id = 506, FullName = "Nada Khaled", Email = "nada.khaled@university.edu.eg", DeptId = 2, CourseId = 311 },
                  new TeacherAssistant { Id = 507, FullName = "Karim Nabil", Email = "karim.nabil@university.edu.eg", DeptId = 3, CourseId = 313 },
                  new TeacherAssistant { Id = 508, FullName = "Hana Ali", Email = "hana.ali@university.edu.eg", DeptId = 4, CourseId = 315 },
                  new TeacherAssistant { Id = 509, FullName = "Ali Mahmoud", Email = "ali.mahmoud@university.edu.eg", DeptId = 1, CourseId = 317 },
                  new TeacherAssistant { Id = 510, FullName = "Rana Ibrahim", Email = "rana.ibrahim@university.edu.eg", DeptId = 2, CourseId = 319 },
                  new TeacherAssistant { Id = 511, FullName = "Tamer Mohamed", Email = "tamer.mohamed@university.edu.eg", DeptId = 3, CourseId = 301 },
                  new TeacherAssistant { Id = 512, FullName = "Dina Hassan", Email = "dina.hassan@university.edu.eg", DeptId = 4, CourseId = 303 },
                  new TeacherAssistant { Id = 513, FullName = "Sherif Samir", Email = "sherif.samir@university.edu.eg", DeptId = 1, CourseId = 305 },
                  new TeacherAssistant { Id = 514, FullName = "Laila Adel", Email = "laila.adel@university.edu.eg", DeptId = 2, CourseId = 307 },
                  new TeacherAssistant { Id = 515, FullName = "Hassan Tarek", Email = "hassan.tarek@university.edu.eg", DeptId = 3, CourseId = 309 },
                  new TeacherAssistant { Id = 516, FullName = "Nour Sherif", Email = "nour.sherif@university.edu.eg", DeptId = 4, CourseId = 311 },
                  new TeacherAssistant { Id = 517, FullName = "Amr Hossam", Email = "amr.hossam@university.edu.eg", DeptId = 1, CourseId = 313 },
                  new TeacherAssistant { Id = 518, FullName = "Sara Khaled", Email = "sara.khaled@university.edu.eg", DeptId = 2, CourseId = 315 },
                  new TeacherAssistant { Id = 519, FullName = "Kareem Nabil", Email = "kareem.nabil@university.edu.eg", DeptId = 3, CourseId = 317 },
                  new TeacherAssistant { Id = 520, FullName = "Dalia Ali", Email = "dalia.ali@university.edu.eg", DeptId = 4, CourseId = 319 }
};
        }
    }
}
