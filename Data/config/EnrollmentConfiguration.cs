using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using University_Managment_system.Entity;

namespace University_Managment_system.Data.config
{
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(x => new { x.StudentId, x.CourseId });

            builder.HasData(LoadData());
            builder.ToTable("Enrollments");
        }

        private List<Enrollment> LoadData()
        {
            return new List<Enrollment> {
            new Enrollment { StudentId = 401, CourseId = 301 },
    new Enrollment { StudentId = 402, CourseId = 303 },
    new Enrollment { StudentId = 403, CourseId = 305 },
    new Enrollment { StudentId = 404, CourseId = 307 },
    new Enrollment { StudentId = 405, CourseId = 309 },
    new Enrollment { StudentId = 406, CourseId = 311 },
    new Enrollment { StudentId = 407, CourseId = 313 },
    new Enrollment { StudentId = 408, CourseId = 315 },
    new Enrollment { StudentId = 409, CourseId = 317 },
    new Enrollment { StudentId = 410, CourseId = 319 },
    new Enrollment { StudentId = 411, CourseId = 301 },
    new Enrollment { StudentId = 412, CourseId = 303 },
    new Enrollment { StudentId = 413, CourseId = 305 },
    new Enrollment { StudentId = 414, CourseId = 307 },
    new Enrollment { StudentId = 415, CourseId = 309 },
    new Enrollment { StudentId = 416, CourseId = 311 },
    new Enrollment { StudentId = 417, CourseId = 313 },
    new Enrollment { StudentId = 418, CourseId = 315 },
    new Enrollment { StudentId = 419, CourseId = 317 },
    new Enrollment { StudentId = 420, CourseId = 319 }
};
        }
    }
}
