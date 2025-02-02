using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Managment_system.Entity
{
    public class TeacherAssistant
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public Department Department { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public int DeptId { get; set; }
    }
}
