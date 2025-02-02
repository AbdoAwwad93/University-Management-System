using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Managment_system.Entity
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public Department Department { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<TeacherAssistant> TeacherAssistants{ get; set; } = new List <TeacherAssistant>();
        public Doctor? Doctor { get; set; }
        public int DoctorId { get; set; }
        public int DeptId { get; set; }


    }
}
