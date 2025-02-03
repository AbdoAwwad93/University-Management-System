using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using University_Managment_system.Data;
using University_Managment_system.Entity;
using University_Managment_system.Migrations;

namespace University_Managment_system
{
    public static class DatabaseHelper
    {
        static AppDbContext context = new AppDbContext();
        // Add Student
        public static bool AddStudent()
        {
            var student = GetStudentData();
            if (student != null)
            {
                context.Students.Add(student);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        
        public static bool RemoveStudent(int studentID)
        {
            var student = context.Students.SingleOrDefault(x => x.Id==studentID);
            if (student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        
        public static bool AddDoctor()
        {
            var doctor = GetDoctorData();
            if (doctor != null)
            {
                context.Doctors.Add(doctor);
                context.SaveChanges();
                return true;
            }
            return false;
        }

       
        public static bool RemoveDoctor(int doctorId)
        {
            var doctor = context.Doctors.SingleOrDefault(x => x.Id==doctorId);
            if (doctor != null)
            {
                context.Doctors.Remove(doctor);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        
        public static bool AddCourse()
        {
            var course = GetCourseData();

            if (course != null)
            {
                context.Courses.Add(course);
                context.SaveChanges();
                return true;
            }
            return false;
        }

       
        public static bool RemoveCourse(int courseID)
        {
            var course = context.Courses.SingleOrDefault(x => x.Id==courseID);
            if (course != null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        public static void ShowStudentEnrolledCourses(Student student)
        {
            var department = GetDepartment(student.DeptId);
            var result = (from s in context.Enrollments
                          join course in context.Courses
                          on s.CourseId equals course.Id
                          where s.StudentId == student.Id
                          select new
                          {
                              Name = course.Name,
                              credits = course.Credits,
                              Doctor = context.Doctors
                                  .Where(doc => doc.Id == course.DoctorId)
                                  .Select(doc => doc.FullName)
                                  .SingleOrDefault() ?? "N/A"
                          }).ToList();

            Console.WriteLine("==============================================");
            Console.WriteLine("          STUDENT ENROLLED COURSES           ");
            Console.WriteLine("==============================================");
            Console.WriteLine($" Name: {student.FullName}");
            Console.WriteLine($" Department: {department}");
            Console.WriteLine("==============================================");
            Console.WriteLine(" Enrolled Courses:");
            Console.WriteLine("==============================================");

            if (result.Any())
            {
                int nameWidth = Math.Max(
                    result.Max(c => c.Name.Length),
                    "Course Name".Length
                );
                int creditsWidth = Math.Max(
                    result.Max(c => c.credits.ToString().Length),
                    "Credits".Length
                );
                int doctorWidth = Math.Max(
                    result.Max(c => c.Doctor.Length),
                    "Doctor".Length
                );                
                string separator = $"+-{new string('-', nameWidth)}-+-{new string('-', creditsWidth)}-+-{new string('-', doctorWidth)}-+";
                Console.WriteLine(separator);
                Console.WriteLine($"| {Helper.PadCenter("Course Name", nameWidth)} | {Helper.PadCenter("Credits", creditsWidth)} | {Helper.PadCenter("Doctor", doctorWidth)} |");
                Console.WriteLine(separator);

                
                foreach (var course in result)
                {
                    Console.WriteLine($"| {course.Name.PadRight(nameWidth)} " +
                                    $"| {course.credits.ToString().PadLeft(creditsWidth)} " +
                                    $"| {course.Doctor.PadRight(doctorWidth)} |");
                }

                Console.WriteLine(separator);
            }
            else
            {
                Console.WriteLine("No courses enrolled");
            }
        }


        public static void EnrollCourse(Student student, int CourseID)
        {
            if (context.Enrollments.Any(x => x.CourseId == CourseID&&x.StudentId==student.Id))
            {
                Helper.ShowError("Already Enrolled in this course !");
                return;
            }
                var course = context.Courses.SingleOrDefault(x => x.Id == CourseID);
                if (course is not null && student is not null)
                {
                    student.Courses.Add(course);
                    context.SaveChanges();
                    Helper.ShowSuccess($"Enrolled in {course.Name}");

                }
                else
                Helper.ShowError("Invalid Course ID !");            
        }
        public static void ShowAllStudents()
        {
            var students = context.Students.ToList();
            if (students.Count == 0)
            {
                Helper.ShowInfo("No students found.");
                return;
            }

            
            int idWidth = Helper.GetMaxWidth(students, s => s.Id.ToString(), "ID");
            int nameWidth = Helper.GetMaxWidth(students, s => s.FullName, "Name");
            int deptWidth = Helper.GetMaxWidth(students, s => GetDepartment(s.DeptId), "Department");
            int gpaWidth = Helper.GetMaxWidth(students, s => s.GPA.ToString("0.0"), "GPA");
            int levelWidth = Helper.GetMaxWidth(students, s => s.level.ToString(), "Level");
            int emailWidth = Helper.GetMaxWidth(students, s => s.Email, "Email");

            
            string separator = Helper.GenerateSeparator(idWidth, nameWidth, deptWidth, gpaWidth, levelWidth, emailWidth);

            Console.WriteLine("\n--- All Students ---");
            Console.WriteLine(separator);
            Console.WriteLine($"| {"ID".PadRight(idWidth)} | {"Name".PadRight(nameWidth)} | {"Department".PadRight(deptWidth)} | {"GPA".PadRight(gpaWidth)} | {"Level".PadRight(levelWidth)} | {"Email".PadRight(emailWidth)} |");
            Console.WriteLine(separator);

            foreach (var std in students)
            {
                Console.WriteLine(
                    $"| {std.Id.ToString().PadRight(idWidth)} " +
                    $"| {std.FullName.PadRight(nameWidth)} " +
                    $"| {GetDepartment(std.DeptId).PadRight(deptWidth)} " +
                    $"| {std.GPA.ToString("0.0").PadRight(gpaWidth)} " +
                    $"| {std.level.ToString().PadRight(levelWidth)} " +
                    $"| {std.Email.PadRight(emailWidth)} |"
                );
            }

            Console.WriteLine(separator);
            Helper.ShowInfo($"Total Students: {students.Count}");
        }
        public static void ShowAllCourses()
        {
            var courses = context.Courses.ToList();
            if (courses.Count == 0)
            {
                Helper.ShowInfo("No courses found.");
                return;
            }

          
            int idWidth = Helper.GetMaxWidth(courses, c => c.Id.ToString(), "ID");
            int nameWidth = Helper.GetMaxWidth(courses, c => c.Name, "Name");
            int deptWidth = Helper.GetMaxWidth(courses, c => GetDepartment(c.DeptId), "Department");
            int creditsWidth = Helper.GetMaxWidth(courses, c => c.Credits.ToString(), "Credits");
            int doctorIdWidth = Helper.GetMaxWidth(courses, c => c.DoctorId.ToString(), "Doctor ID");

            string separator = Helper.GenerateSeparator(idWidth, nameWidth, deptWidth, creditsWidth, doctorIdWidth);

            Console.WriteLine("\n--- All Courses ---");
            Console.WriteLine(separator);
            Console.WriteLine($"| {"ID".PadRight(idWidth)} | {"Name".PadRight(nameWidth)} | {"Department".PadRight(deptWidth)} | {"Credits".PadRight(creditsWidth)} | {"Doctor ID".PadRight(doctorIdWidth)} |");
            Console.WriteLine(separator);

            foreach (var course in courses)
            {
                Console.WriteLine(
                    $"| {course.Id.ToString().PadRight(idWidth)} " +
                    $"| {course.Name.PadRight(nameWidth)} " +
                    $"| {GetDepartment(course.DeptId).PadRight(deptWidth)} " +
                    $"| {course.Credits.ToString().PadRight(creditsWidth)} " +
                    $"| {course.DoctorId.ToString().PadRight(doctorIdWidth)} |"
                );
            }

            Console.WriteLine(separator);
            Helper.ShowInfo($"Total Courses: {courses.Count}");
        }

        public static void ShowAllDoctors()
        {
            var doctors = context.Doctors.ToList();
            if (doctors.Count == 0)
            {
                Helper.ShowInfo("No doctors found.");
                return;
            }

           
            int idWidth = Helper.GetMaxWidth(doctors, d => d.Id.ToString(), "ID");
            int nameWidth = Helper.GetMaxWidth(doctors, d => d.FullName, "Name");
            int deptWidth = Helper.GetMaxWidth(doctors, d => GetDepartment(d.DeptId), "Department");
            int emailWidth = Helper.GetMaxWidth(doctors, d => d.Email, "Email");

            string separator = Helper.GenerateSeparator(idWidth, nameWidth, deptWidth, emailWidth);

            Console.WriteLine("\n--- All Doctors ---");
            Console.WriteLine(separator);
            Console.WriteLine($"| {"ID".PadRight(idWidth)} | {"Name".PadRight(nameWidth)} | {"Department".PadRight(deptWidth)} | {"Email".PadRight(emailWidth)} |");
            Console.WriteLine(separator);

            foreach (var doctor in doctors)
            {
                Console.WriteLine(
                    $"| {doctor.Id.ToString().PadRight(idWidth)} " +
                    $"| {doctor.FullName.PadRight(nameWidth)} " +
                    $"| {GetDepartment(doctor.DeptId).PadRight(deptWidth)} " +
                    $"| {doctor.Email.PadRight(emailWidth)} |"
                );
            }

            Console.WriteLine(separator);
            Helper.ShowInfo($"Total Doctors: {doctors.Count}");
        }

        public static void ShowAllTA()
        {
            var assistants = context.TeacherAssistants.ToList();
            if (assistants.Count == 0)
            {
                Helper.ShowInfo("No teacher assistants found.");
                return;
            }

            int idWidth = Helper.GetMaxWidth(assistants, a => a.Id.ToString(), "ID");
            int nameWidth = Helper.GetMaxWidth(assistants, a => a.FullName, "Name");
            int deptWidth = Helper.GetMaxWidth(assistants, a => GetDepartment(a.DeptId), "Department");
            int emailWidth = Helper.GetMaxWidth(assistants, a => a.Email, "Email");

            string separator = Helper.GenerateSeparator(idWidth, nameWidth, deptWidth, emailWidth);

            Console.WriteLine("\n--- All Teacher Assistants ---");
            Console.WriteLine(separator);
            Console.WriteLine($"| {"ID".PadRight(idWidth)} | {"Name".PadRight(nameWidth)} | {"Department".PadRight(deptWidth)} | {"Email".PadRight(emailWidth)} |");
            Console.WriteLine(separator);

            foreach (var assistant in assistants)
            {
                Console.WriteLine(
                    $"| {assistant.Id.ToString().PadRight(idWidth)} " +
                    $"| {assistant.FullName.PadRight(nameWidth)} " +
                    $"| {GetDepartment(assistant.DeptId).PadRight(deptWidth)} " +
                    $"| {assistant.Email.PadRight(emailWidth)} |"
                );
            }

            Console.WriteLine(separator);
            Helper.ShowInfo($"Total Teacher Assistants: {assistants.Count}");
        }

        
        public static Student GetStudentData()
        {
            Console.WriteLine("\n--- New Student Registration --- (type 'back' to cancel)");
            Student student = new Student();

            string input = Helper.GetInputWithBack("Id: ", true);
            if (input == null) return null;
            int id = int.Parse(input);

            if (context.Students.Any(s => s.Id == id))
            {
                Helper.ShowError("ID already exists!");
                return null;
            }
            student.Id = id;

            student.FullName = Helper.GetInputWithBack("Full Name: ");
            if (student.FullName == null) return null;

            student.Password = Helper.GetInputWithBack("Password: ");
            if (student.Password == null) return null;

            student.Email = Helper.GetInputWithBack("Email: ");
            if (student.Email == null) return null;

            input = Helper.GetInputWithBack("GPA: ", true);
            if (input == null) return null;
            student.GPA = double.Parse(input);

            input = Helper.GetInputWithBack("Department Id: ", true, context.Departments.Select(d => d.Id.ToString()));
            if (input == null) return null;
            student.DeptId = int.Parse(input);

            input = Helper.GetInputWithBack("Level: ", true);
            if (input == null) return null;
            student.level = int.Parse(input);

            return student;
        }
        public static Doctor GetDoctorData()
        {
            Console.WriteLine("\n--- New Doctor Registration --- (type 'back' to cancel)");
            Doctor doctor = new Doctor();

            string input = Helper.GetInputWithBack("Id: ", true);
            if (input == null) return null;
            int id = int.Parse(input);

            if (context.Doctors.Any(d => d.Id == id))
            {
                Helper.ShowError("ID already exists!");
                return null;
            }
            doctor.Id = id;

            doctor.FullName = Helper.GetInputWithBack("Full Name: ");
            if (doctor.FullName == null) return null;

            doctor.Password = Helper.GetInputWithBack("Password: ");
            if (doctor.Password == null) return null;

            doctor.Email = Helper.GetInputWithBack("Email: ");
            if (doctor.Email == null) return null;

            input = Helper.GetInputWithBack("Department Id: ", true, context.Departments.Select(d => d.Id.ToString()));
            if (input == null) return null;
            doctor.DeptId = int.Parse(input);

            return doctor;
        }
        public static Course GetCourseData()
        {
            Console.WriteLine("\n--- New Course Registration --- (type 'back' to cancel)");
            Course course = new Course();

            string input = Helper.GetInputWithBack("Id: ", true);
            if (input == null) return null;
            int id = int.Parse(input);

            if (context.Courses.Any(c => c.Id == id))
            {
                Helper.ShowError("ID already exists!");
                return null;
            }
            course.Id = id;

            course.Name = Helper.GetInputWithBack("Name: ");
            if (course.Name == null) return null;

            input = Helper.GetInputWithBack("Department Id: ", true, context.Departments.Select(d => d.Id.ToString()));
            if (input == null) return null;
            course.DeptId = int.Parse(input);

            input = Helper.GetInputWithBack("Credits: ", true);
            if (input == null) return null;
            course.Credits = int.Parse(input);

            input = Helper.GetInputWithBack("Doctor Id: ", true, context.Doctors.Select(d => d.Id.ToString()));
            if (input == null) return null;
            course.DoctorId = int.Parse(input);

            return course;
        }
        public static User GetIdAndPassword(out int TakenId, out string password, string role)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"--- {role.ToUpper()} Login --- (type 'back' to return to the previous page)");
                Console.Write("Enter Your ID: ");
                string idInput = Console.ReadLine()?.Trim();

                
                if (idInput?.ToLower() == "back")
                {
                    TakenId = -1;
                    password = null;
                    return null; 
                }

                
                if (!int.TryParse(idInput, out TakenId))
                {
                    Helper.ShowError("Invalid ID! Please enter a valid number.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }

                Console.Write("Enter Your Password: ");
                password = Console.ReadLine()?.Trim();

                
                if (password?.ToLower() == "back")
                {
                    TakenId = -1;
                    password = null;
                    return null;
                }

                bool isValid = false;
                int id = TakenId;
                switch (role.ToLower())
                {
                    case "admin":
                        var admin = context.Admins.SingleOrDefault(a => a.Id == id);
                        isValid = admin != null && admin.Password == password;
                        if (isValid) return admin;
                        break;
                    case "student":
                        var student = context.Students.SingleOrDefault(s => s.Id == id);
                        isValid = student != null && student.Password == password;
                         if(isValid) return student;
                        break;
                    case "doctor":
                        var doctor = context.Doctors.SingleOrDefault(d => d.Id == id);
                        isValid = doctor != null && doctor.Password == password;
                        if (isValid) return doctor;
                        break;
                }

                if (!isValid)
                {
                    Helper.ShowError("Invalid ID or Password!");
                    Console.WriteLine("1. Try Again");
                    Console.WriteLine("2. Back to Previous Page");
                    Console.Write("Enter your choice (1-2): ");

                    string choice = Console.ReadLine()?.Trim();
                    if (choice == "2")
                    {
                        TakenId = -1;
                        password = null;
                        return null; 
                    }
                }
            }
        }
        public static string GetDepartment(int ForiegnId)
        {
            var department = context.Departments
                .Where(dep => dep.Id ==ForiegnId)
                .Select(dep => dep.Name)
                .SingleOrDefault();
            return department;
        }
        public static List<string> GetDoctorAssignedCourses(Doctor doctor)
        {
            var result = context.Courses
                .Where(course => course.DoctorId ==doctor.Id)
                .Select(course => course.Name).ToList();
            return result;
        } 
    }
}
