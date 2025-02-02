using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Managment_system.Entity;

namespace University_Managment_system.Data
{
    public class AppDbContext:DbContext
    {
      public DbSet<Student> Students { get; set; }
      public DbSet<Doctor> Doctors { get; set; }
      public DbSet<Admin> Admins { get; set; }
      public DbSet<Course> Courses { get; set; }
      public DbSet<Department> Departments { get; set; }
      public DbSet<TeacherAssistant> TeacherAssistants { get; set; }
      public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("Appsettings.json")
                  .Build();
            var contstr = configuration.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(contstr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        }
    }
}
