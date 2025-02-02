using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Managment_system.Entity
{
    public class Doctor:User
    {
        public List<Course> Courses { get; set; } = new List<Course>();
        public void ViewPersonalData()
        {
            var department = DatabaseHelper.GetDepartment(this.DeptId);
            Console.WriteLine("=========================================");
            Console.WriteLine("|          STUDENT INFORMATION          |");
            Console.WriteLine("=========================================");
            Console.WriteLine($"| {"ID",-10}: {Id,-28} |");
            Console.WriteLine($"| {"Full Name",-10}: {FullName,-28}");
            Console.WriteLine($"| {"Email",-10}: {Email,-28} ");
            Console.WriteLine($"| {"Department",-10}: {department,-28} ");
            Console.WriteLine("=========================================");
            Console.WriteLine();
        }
    }
}
