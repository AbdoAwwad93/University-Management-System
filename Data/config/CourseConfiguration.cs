using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Managment_system.Entity;

namespace University_Managment_system.Data.config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(course => course.Id);
            builder.Property(course => course.Id).ValueGeneratedNever();
            builder.Property(course => course.Name).HasColumnName("Name")
                .HasColumnType("Varchar(50)");
            builder.Property(course => course.Credits).HasColumnName("Credits")
                .HasColumnType("float");

            builder.HasOne(course => course.Department)
                .WithMany(dep => dep.Courses)
                .HasForeignKey(course => course.DeptId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(LoadData());
            builder.ToTable("Courses");
        }

        private List<Course> LoadData()
        {
            return new List<Course> {
             new Course { Id = 301, Name = "Programming Fundamentals", Credits = 3, DeptId = 1, DoctorId = 201 },
             new Course { Id = 302, Name = "Data Structures", Credits = 4, DeptId = 1, DoctorId = 205 },
             new Course { Id = 303, Name = "Database Systems", Credits = 3, DeptId = 2, DoctorId = 202 },
             new Course { Id = 304, Name = "Web Development", Credits = 3, DeptId = 2, DoctorId = 206 },
             new Course { Id = 305, Name = "Artificial Intelligence", Credits = 4, DeptId = 4, DoctorId = 204 },
             new Course { Id = 306, Name = "Machine Learning", Credits = 4, DeptId = 4, DoctorId = 208 },
             new Course { Id = 307, Name = "Software Engineering", Credits = 3, DeptId = 1, DoctorId = 209 },
             new Course { Id = 308, Name = "Operating Systems", Credits = 3, DeptId = 1, DoctorId = 213 },
             new Course { Id = 309, Name = "Network Security", Credits = 3, DeptId = 2, DoctorId = 210 },
             new Course { Id = 310, Name = "Cloud Computing", Credits = 4, DeptId = 2, DoctorId = 214 },
             new Course { Id = 311, Name = "Data Mining", Credits = 4, DeptId = 4, DoctorId = 212 },
             new Course { Id = 312, Name = "Natural Language Processing", Credits = 4, DeptId = 4, DoctorId = 216 },
             new Course { Id = 313, Name = "Mobile Application Development", Credits = 3, DeptId = 1, DoctorId = 217 },
             new Course { Id = 314, Name = "Computer Graphics", Credits = 3, DeptId = 1, DoctorId = 201 },
             new Course { Id = 315, Name = "Information Security", Credits = 3, DeptId = 2, DoctorId = 202 },
             new Course { Id = 316, Name = "Big Data Analytics", Credits = 4, DeptId = 2, DoctorId = 206 },
             new Course { Id = 317, Name = "Deep Learning", Credits = 4, DeptId = 4, DoctorId = 204 },
             new Course { Id = 318, Name = "Computer Vision", Credits = 4, DeptId = 4, DoctorId = 208 },
             new Course { Id = 319, Name = "Human-Computer Interaction", Credits = 3, DeptId = 1, DoctorId = 209 },
             new Course { Id = 320, Name = "Distributed Systems", Credits = 3, DeptId = 1, DoctorId = 213 }
};
        }
    }
}
