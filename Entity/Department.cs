using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Managment_system.Entity
{
    public class Department
    {
        public int Id { get; set; }
        public string DeptCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Admin Admin { get; set; }
        public List<Doctor>? Doctors { get; set; } = new List<Doctor>();
        public List<Course>? Courses { get; set; } = new List<Course>();
        public List<Student>? Students { get; set; } = new List<Student>();
        public List<TeacherAssistant>? TeacherAssistants { get; set; } = new List<TeacherAssistant>();
    }
}
