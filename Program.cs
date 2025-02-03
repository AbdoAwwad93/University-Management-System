using University_Managment_system.Entity;
namespace University_Managment_system
{
    internal class Program
    {
        public static void MainMenuOperations(out int choice)
        {
            bool flag = true;
            Console.Write("Loading");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
            do
            {
                Thread.Sleep(500);
                ShowMainMenu();
                if (int.TryParse(Console.ReadLine(), out choice) && (choice > 0 && choice <= 4))
                {
                    switch (choice)
                    {
                        case 1:
                            if (AuthAdmin() != null)
                            {
                                ShowAdminMenu();
                                flag = false;
                            }
                            else
                            {
                                Console.WriteLine("\nPress any key to go to the Home Page...");
                                Console.ReadKey();
                            }
                            break;
                        case 2:
                            if (AuthStudent() != null)
                            {
                                ShowStudentMenu();
                                flag = false;
                            }
                            else
                            {
                                Console.WriteLine("\nPress any key to go to the Home Page...");
                                Console.ReadKey();
                            }
                            break;
                        case 3:
                            if (AuthDoctor() != null)
                            {
                                ShowDoctorMenu();
                                flag = false;
                            }
                            else
                            {
                                Console.WriteLine("\nPress any key to go to the Home Page...");
                                Console.ReadKey();
                            }
                            break;
                        case 4:
                            return;
                    }
                }
                else
                {
                    Helper.ShowError("Please enter a valid choice (1-4).");
                }
            } while (flag);
        }

        
        public static void AdminOperations()
        {
            int choice;
            int x;
            do
            {
                ShowAdminMenu();
                if (int.TryParse(Console.ReadLine(), out choice) && (choice >= 0 && choice <= 10))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            AddStudent();
                            Helper.ShowInfo("(PRESS ANY key to go to previous page)");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            AddCourse();
                            Helper.ShowInfo("(PRESS ANY key to go to previous page)");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            AddDoctor();
                            Helper.ShowInfo("(PRESS ANY key to go to previous page)");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            RemoveStudent();
                            Helper.ShowInfo("(PRESS ANY key to go to previous page)");
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            RemoveCourse();
                            Helper.ShowInfo("(PRESS ANY key to go to previous page)");
                            Console.ReadKey();
                            break;
                        case 6:
                            Console.Clear();
                            RemoveDoctor();
                            Helper.ShowInfo("(PRESS ANY key to go to previous page)");
                            Console.ReadKey();
                            break;
                        case 7:
                            Console.Clear();
                            Helper.ShowInfo("(PRESS ANY key to go to previous page)");
                            DatabaseHelper.ShowAllStudents();
                            Console.ReadKey();
                            break;
                        case 8:
                            Console.Clear();
                            Helper.ShowInfo("(PRESS ANY key to go to previous page)");
                            DatabaseHelper.ShowAllCourses();
                            Console.ReadKey();
                            break;
                        case 9:
                            Console.Clear();
                            Helper.ShowInfo("(PRESS ANY key to go to previous page)");
                            DatabaseHelper.ShowAllDoctors();
                            Console.ReadKey();
                            break;
                        case 10:
                            Console.Clear();
                            Helper.ShowInfo("(PRESS ANY key to go to previous page)");
                            DatabaseHelper.ShowAllTA();
                            Console.ReadKey();
                            break;
                        case 0:
                            return;
                    }
                }
               
            } while (true);
        }


        private static void EnrollCourse(Student student)
        {
            Console.Clear();
            Console.WriteLine("\n--- Enroll course --- (type 'back' to cancel)");
            string input = Helper.GetInputWithBack("Enter Course ID: ", true);
            if (input == null) return; // User typed 'back'
            int CourseId = int.Parse(input);
            DatabaseHelper.EnrollCourse(student, CourseId);
        }
        private static void RemoveDoctor()
        {
            int takenid;
            bool IsDone = false;
            while (!IsDone)
            {
                Console.Clear();
                Console.WriteLine("\n--- Doctor Deletion --- (type 'back' to cancel)");
                Console.Write("Enter the Doctor Id: ");
                string input = Console.ReadLine()?.ToLower();
                if (input=="back") return;
                if (!(int.TryParse(input, out takenid)))
                {
                    Helper.ShowError("Please enter a valid number.\nPRESS ANY key to try again.");
                    Console.ReadKey();
                    continue;
                }
                if (DatabaseHelper.RemoveDoctor(takenid))
                {
                    Helper.ShowSuccess("Doctor Deleted Successfully.");
                    IsDone = true;
                }
                else
                    Helper.ShowError("Operation Falied !\nPRESS ANY key to try again.");
            }
        }

        private static void RemoveCourse()
        {
            int takenid;
            bool IsDone = false;
            while (!IsDone)
            {
                Console.Clear();
                Console.WriteLine("\n--- Course Deletion --- (type 'back' to cancel)");
                Console.Write("Enter the Course Id: ");
                string input = Console.ReadLine()?.ToLower();
                if (input == "back") return;
                if (!(int.TryParse(input, out takenid)))
                {
                    Helper.ShowError("Please enter a valid number.\nPRESS ANY key to try again.");
                    Console.ReadKey();
                    continue;
                }
                if (DatabaseHelper.RemoveCourse(takenid))
                {
                    Helper.ShowSuccess("Course Deleted Successfully.");
                    IsDone = true;
                }
                else
                    Helper.ShowError("Operation Falied !\nPRESS ANY key to try again.");
            }
        }

        private static void RemoveStudent()
        {
            int takenid;
            bool IsDone = false;
            while (!IsDone)
            {
                Console.Clear();
                Console.WriteLine("\n--- Student Deletion --- (type 'back' to cancel)");
                Console.Write("Enter the student Id: ");
                string input = Console.ReadLine()?.ToLower();
                if (input=="back") return;

                if (!(int.TryParse(input, out takenid)))
                {
                    Helper.ShowError("Please enter a valid number.\nPRESS ANY key to try again.");
                    Console.ReadKey();
                    continue;
                }

                if (DatabaseHelper.RemoveStudent(takenid))
                {
                    Helper.ShowSuccess("Student Deleted Successfully.");
                    IsDone = true;
                }
                else
                    Helper.ShowError("Operation Falied !\nPRESS ANY key to try again.");
            }
        }
        private static void AddDoctor()
        {
            if (DatabaseHelper.AddDoctor())
            {
                Helper.ShowSuccess("Doctor added successfully!");
            }
            else 
            { 
            Helper.ShowError("Failed to add the doctor. Invalid data.");
            }
        }

        private static void AddCourse()
        {
            if (DatabaseHelper.AddCourse())
            {
                Helper.ShowSuccess("Course added successfully!");
            }
            else
            {
                Helper.ShowError("Failed to add the course. Invalid data.");
            }
        }

        private static void AddStudent()
        {
            if (DatabaseHelper.AddStudent())
            {
                Helper.ShowSuccess("Student added successfully!");
            }
            else
            { 
            Helper.ShowError("Failed to add the student. Invalid data.");
            }
        }

        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=== University Management System ===");
            Console.ResetColor();
            Console.WriteLine("\n1. Admin\n2. Student\n3. Doctor\n4. Exit");
        }

        public static void ShowAdminMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== ADMIN MENU ===");
            Console.ResetColor();
            Console.WriteLine("1. Add New Student\n2. Add New Course\n3. Add New Doctor" +
                "\n4. Remove Student\n5. Remove Course\n6. Remove Doctor" +
                "\n7. Show All Students\n8. Show All Courses\n9. Show All Doctors" +
                "\n10. Show All TAs\n0. Back to Main Menu");
            Console.Write("\nEnter choice (0-10): ");
        }

       
        public static void ShowStudentMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== STUDENT MENU ===");
            Console.ResetColor();
            Console.WriteLine("1. Enroll in a Course\n2. View Personal Data\n3. My GPA\n4. View Enrolled Courses\n5. Back to Main Menu");
            Console.Write("\nEnter choice (1-5): ");
        }

        public static void ShowDoctorMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=== DOCTOR MENU ===");
            Console.ResetColor();
            Console.WriteLine("1. View Personal Data\n2. View Assigned Courses\n3. Back to Main Menu");
            Console.Write("\nEnter choice (1-3): ");
        }

       
        public static Admin AuthAdmin()
        {
            int Takenid;
            string password;
            return (Admin) DatabaseHelper.GetIdAndPassword(out Takenid, out password, "admin");
        }

        public static Student AuthStudent()
        {
            int Takenid;
            string password;
            return (Student) DatabaseHelper.GetIdAndPassword(out Takenid, out password, "student");
        }

       
        public static Doctor AuthDoctor()
        {
            int Takenid;
            string password;
            return (Doctor)DatabaseHelper.GetIdAndPassword(out Takenid, out password, "doctor");
        }
      
        static void Main(string[] args)
        {
            Console.Title = "University Management System";
            while (true)
            {
                ShowMainMenu();
                string input = Helper.GetInputWithBack("\nEnter choice (1-4): ", true, new[] { "1", "2", "3", "4" });
                if (input == null) continue;
                if (input == "4") Environment.Exit(0);

                if (!int.TryParse(input, out int choice) || choice < 1 || choice > 3)
                {
                    Helper.ShowError("Invalid selection!");
                    Thread.Sleep(1000);
                    continue;
                }
                //try
                //{
                    switch (choice)
                    {
                        case 1:
                            if (AuthAdmin()!=null) AdminOperations();
                            break;
                        case 2:
                            var student = AuthStudent();
                            if (student != null) StudentOperations(student);
                            break;
                        case 3:
                            var doctor = AuthDoctor();
                            if (doctor != null) DoctorOperations(doctor);
                            break;
                    }
                //?
                //catch (Exception ex)
                //{
                //    Helper.ShowError($"Error: {ex.Message}");
                //    Console.ReadKey();
                //}
            }
        }

        private static void DoctorOperations(Doctor doctor)
        {
            int choice;
            do
            {
                ShowDoctorMenu();
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Helper.ShowError("Invalid input!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        doctor.ViewPersonalData();
                        break;
                    case 2:
                        Console.Clear();
                        DisplayDoctorAssignedCourses(doctor);
                        break;
                    case 3:
                        return;
                    default:
                        Helper.ShowError("Invalid choice!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            } while (true);
        }

       
        private static void StudentOperations(Student student)
        {
            int choice;
            do
            {
                ShowStudentMenu();
                string input = Console.ReadLine()?.ToLower();
                if (input == "back") return;
                if (!(int.TryParse(input, out choice))||choice<1||choice>5)
                {
                    Helper.ShowError("Please enter a valid choice.\nPRESS ANY key to try again.");
                    Console.ReadKey();
                    continue;
                }
                
                switch (choice)
                {
                    case 1:
                        EnrollCourse(student);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("--- Personal Data (PRESS ANY key to back to the previous page)---");
                        student.ViewPersonalData();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine($"Your current GPA = {student.GPA}");
                        Helper.ShowInfo("\n(PRESS ANY key to back to the previous page)");
                        break;
                    case 4:
                        Console.Clear();
                        Helper.ShowInfo("\n(PRESS ANY key to back to the previous page)");
                        DatabaseHelper.ShowStudentEnrolledCourses(student);
                        break;
                    case 5:
                        return;
                    default:
                        Helper.ShowError("Invalid choice!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            } while (true);
        }
        public static void DisplayDoctorAssignedCourses(Doctor doctor)
        {
            var courses = DatabaseHelper.GetDoctorAssignedCourses(doctor);
            var department = DatabaseHelper.GetDepartment(doctor.DeptId);

            Console.WriteLine("\n==============================================");
            Console.WriteLine($"   COURSES ASSIGNED TO DR. {doctor.FullName.ToUpper()}");
            Console.WriteLine("==============================================");
            Console.WriteLine($" Department: {department}");
            Console.WriteLine("==============================================");

            if (courses.Any())
            {
                
                int maxCourseWidth = Math.Max(
                    courses.Max(c => c.Length),
                    "Course Name".Length
                );

               
                string separator = $"+-{new string('-', maxCourseWidth + 2)}-+";
                Console.WriteLine(separator);
                Console.WriteLine($"| #  | {Helper.PadCenter("Course Name", maxCourseWidth)} |");
                Console.WriteLine(separator);

               
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"| {i + 1,-2} | {courses[i].PadRight(maxCourseWidth)} |");
                }

                Console.WriteLine(separator);
                Console.WriteLine($" Total Courses: {courses.Count}");
            }
            else
            {
                Console.WriteLine(" No courses currently assigned");
                Console.WriteLine("----------------------------------------------");
            }
        }
    }
}
