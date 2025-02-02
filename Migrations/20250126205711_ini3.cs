using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace University_Managment_system.Migrations
{
    /// <inheritdoc />
    public partial class ini3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DeptCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "Varchar(50)", nullable: false),
                    FullName = table.Column<string>(name: "Full Name", type: "Varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "Varchar(50)", nullable: false),
                    FullName = table.Column<string>(name: "Full Name", type: "Varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(50)", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(name: "Full Name", type: "Varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Password = table.Column<string>(type: "Varchar(50)", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false),
                    GPA = table.Column<double>(type: "float", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Credits = table.Column<double>(type: "float", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Courses_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAssistants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(name: "Full Name", type: "Varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "Varchar(50)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAssistants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherAssistants_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TeacherAssistants_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DeptCode", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "CS", "Department of Computer Science", "Computer Science" },
                    { 2, "IT", "Department of Information Technology", "Information Technology" },
                    { 3, "IS", "Department of Information Systems", "Information Systems" },
                    { 4, "AI", "Department of Artificial Intelligence", "Artificial Intelligence" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "DeptId", "Email", "Full Name", "Password" },
                values: new object[,]
                {
                    { 101, 1, "ahmed.mohamed@university.edu.eg", "Ahmed Mohamed", "admin123" },
                    { 102, 2, "mona.ali@university.edu.eg", "Mona Ali", "admin456" },
                    { 103, 3, "youssef.hassan@university.edu.eg", "Youssef Hassan", "admin789" },
                    { 104, 4, "fatma.mahmoud@university.edu.eg", "Fatma Mahmoud", "admin101" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DeptId", "Email", "Full Name", "Password" },
                values: new object[,]
                {
                    { 201, 1, "ahmed.elsayed@university.edu.eg", "Dr. Ahmed El-Sayed", "doctor123" },
                    { 202, 2, "mona.hassan@university.edu.eg", "Dr. Mona Hassan", "doctor456" },
                    { 203, 3, "youssef.ali@university.edu.eg", "Dr. Youssef Ali", "doctor789" },
                    { 204, 4, "fatma.mahmoud@university.edu.eg", "Dr. Fatma Mahmoud", "doctor101" },
                    { 205, 1, "omar.ibrahim@university.edu.eg", "Dr. Omar Ibrahim", "doctor202" },
                    { 206, 2, "nada.samir@university.edu.eg", "Dr. Nada Samir", "doctor303" },
                    { 207, 3, "karim.adel@university.edu.eg", "Dr. Karim Adel", "doctor404" },
                    { 208, 4, "hana.tarek@university.edu.eg", "Dr. Hana Tarek", "doctor505" },
                    { 209, 1, "ali.khaled@university.edu.eg", "Dr. Ali Khaled", "doctor606" },
                    { 210, 2, "rana.sherif@university.edu.eg", "Dr. Rana Sherif", "doctor707" },
                    { 211, 3, "tamer.nabil@university.edu.eg", "Dr. Tamer Nabil", "doctor808" },
                    { 212, 4, "dina.hossam@university.edu.eg", "Dr. Dina Hossam", "doctor909" },
                    { 213, 1, "sherif.omar@university.edu.eg", "Dr. Sherif Omar", "doctor1010" },
                    { 214, 2, "laila.ahmed@university.edu.eg", "Dr. Laila Ahmed", "doctor1111" },
                    { 215, 3, "hassan.mohamed@university.edu.eg", "Dr. Hassan Mohamed", "doctor1212" },
                    { 216, 4, "nour.ali@university.edu.eg", "Dr. Nour Ali", "doctor1313" },
                    { 217, 1, "amr.tarek@university.edu.eg", "Dr. Amr Tarek", "doctor1414" },
                    { 218, 2, "sara.khaled@university.edu.eg", "Dr. Sara Khaled", "doctor1515" },
                    { 219, 3, "kareem.samir@university.edu.eg", "Dr. Kareem Samir", "doctor1616" },
                    { 220, 4, "dalia.adel@university.edu.eg", "Dr. Dalia Adel", "doctor1717" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "DeptId", "Email", "Full Name", "GPA", "Password", "level" },
                values: new object[,]
                {
                    { 401, 1, "mohamed.ahmed@university.edu.eg", "Mohamed Ahmed", 3.5, "student123", 1 },
                    { 402, 2, "ali.hassan@university.edu.eg", "Ali Hassan", 3.7999999999999998, "student456", 2 },
                    { 403, 3, "fatma.mahmoud@university.edu.eg", "Fatma Mahmoud", 3.6000000000000001, "student789", 1 },
                    { 404, 4, "youssef.ali@university.edu.eg", "Youssef Ali", 3.8999999999999999, "student101", 2 },
                    { 405, 1, "nada.samir@university.edu.eg", "Nada Samir", 3.7000000000000002, "student202", 3 },
                    { 406, 2, "karim.adel@university.edu.eg", "Karim Adel", 3.3999999999999999, "student303", 4 },
                    { 407, 3, "hana.tarek@university.edu.eg", "Hana Tarek", 3.7999999999999998, "student404", 3 },
                    { 408, 4, "omar.ibrahim@university.edu.eg", "Omar Ibrahim", 3.6000000000000001, "student505", 4 },
                    { 409, 1, "rana.sherif@university.edu.eg", "Rana Sherif", 3.8999999999999999, "student606", 1 },
                    { 410, 2, "tamer.nabil@university.edu.eg", "Tamer Nabil", 3.5, "student707", 2 },
                    { 411, 3, "dina.hossam@university.edu.eg", "Dina Hossam", 3.7000000000000002, "student808", 1 },
                    { 412, 4, "sherif.omar@university.edu.eg", "Sherif Omar", 3.7999999999999998, "student909", 2 },
                    { 413, 1, "laila.ahmed@university.edu.eg", "Laila Ahmed", 3.6000000000000001, "student1010", 3 },
                    { 414, 2, "hassan.mohamed@university.edu.eg", "Hassan Mohamed", 3.8999999999999999, "student1111", 4 },
                    { 415, 3, "nour.ali@university.edu.eg", "Nour Ali", 3.5, "student1212", 3 },
                    { 416, 4, "amr.tarek@university.edu.eg", "Amr Tarek", 3.7000000000000002, "student1313", 4 },
                    { 417, 1, "sara.khaled@university.edu.eg", "Sara Khaled", 3.7999999999999998, "student1414", 1 },
                    { 418, 2, "kareem.samir@university.edu.eg", "Kareem Samir", 3.6000000000000001, "student1515", 2 },
                    { 419, 3, "dalia.adel@university.edu.eg", "Dalia Adel", 3.8999999999999999, "student1616", 1 },
                    { 420, 4, "ahmed.youssef@university.edu.eg", "Ahmed Youssef", 3.7000000000000002, "student1717", 2 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Credits", "DeptId", "DoctorId", "Name" },
                values: new object[,]
                {
                    { 301, 3.0, 1, 201, "Programming Fundamentals" },
                    { 302, 4.0, 1, 205, "Data Structures" },
                    { 303, 3.0, 2, 202, "Database Systems" },
                    { 304, 3.0, 2, 206, "Web Development" },
                    { 305, 4.0, 4, 204, "Artificial Intelligence" },
                    { 306, 4.0, 4, 208, "Machine Learning" },
                    { 307, 3.0, 1, 209, "Software Engineering" },
                    { 308, 3.0, 1, 213, "Operating Systems" },
                    { 309, 3.0, 2, 210, "Network Security" },
                    { 310, 4.0, 2, 214, "Cloud Computing" },
                    { 311, 4.0, 4, 212, "Data Mining" },
                    { 312, 4.0, 4, 216, "Natural Language Processing" },
                    { 313, 3.0, 1, 217, "Mobile Application Development" },
                    { 314, 3.0, 1, 201, "Computer Graphics" },
                    { 315, 3.0, 2, 202, "Information Security" },
                    { 316, 4.0, 2, 206, "Big Data Analytics" },
                    { 317, 4.0, 4, 204, "Deep Learning" },
                    { 318, 4.0, 4, 208, "Computer Vision" },
                    { 319, 3.0, 1, 209, "Human-Computer Interaction" },
                    { 320, 3.0, 1, 213, "Distributed Systems" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[,]
                {
                    { 301, 401 },
                    { 303, 402 },
                    { 305, 403 },
                    { 307, 404 },
                    { 309, 405 },
                    { 311, 406 },
                    { 313, 407 },
                    { 315, 408 },
                    { 317, 409 },
                    { 319, 410 },
                    { 301, 411 },
                    { 303, 412 },
                    { 305, 413 },
                    { 307, 414 },
                    { 309, 415 },
                    { 311, 416 },
                    { 313, 417 },
                    { 315, 418 },
                    { 317, 419 },
                    { 319, 420 }
                });

            migrationBuilder.InsertData(
                table: "TeacherAssistants",
                columns: new[] { "Id", "CourseId", "DeptId", "Email", "Full Name" },
                values: new object[,]
                {
                    { 501, 301, 1, "ahmed.samir@university.edu.eg", "Ahmed Samir" },
                    { 502, 303, 2, "mona.adel@university.edu.eg", "Mona Adel" },
                    { 503, 305, 3, "youssef.tarek@university.edu.eg", "Youssef Tarek" },
                    { 504, 307, 4, "fatma.sherif@university.edu.eg", "Fatma Sherif" },
                    { 505, 309, 1, "omar.hossam@university.edu.eg", "Omar Hossam" },
                    { 506, 311, 2, "nada.khaled@university.edu.eg", "Nada Khaled" },
                    { 507, 313, 3, "karim.nabil@university.edu.eg", "Karim Nabil" },
                    { 508, 315, 4, "hana.ali@university.edu.eg", "Hana Ali" },
                    { 509, 317, 1, "ali.mahmoud@university.edu.eg", "Ali Mahmoud" },
                    { 510, 319, 2, "rana.ibrahim@university.edu.eg", "Rana Ibrahim" },
                    { 511, 301, 3, "tamer.mohamed@university.edu.eg", "Tamer Mohamed" },
                    { 512, 303, 4, "dina.hassan@university.edu.eg", "Dina Hassan" },
                    { 513, 305, 1, "sherif.samir@university.edu.eg", "Sherif Samir" },
                    { 514, 307, 2, "laila.adel@university.edu.eg", "Laila Adel" },
                    { 515, 309, 3, "hassan.tarek@university.edu.eg", "Hassan Tarek" },
                    { 516, 311, 4, "nour.sherif@university.edu.eg", "Nour Sherif" },
                    { 517, 313, 1, "amr.hossam@university.edu.eg", "Amr Hossam" },
                    { 518, 315, 2, "sara.khaled@university.edu.eg", "Sara Khaled" },
                    { 519, 317, 3, "kareem.nabil@university.edu.eg", "Kareem Nabil" },
                    { 520, 319, 4, "dalia.ali@university.edu.eg", "Dalia Ali" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_DeptId",
                table: "Admins",
                column: "DeptId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DeptId",
                table: "Courses",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DoctorId",
                table: "Courses",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DeptId",
                table: "Doctors",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DeptId",
                table: "Students",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAssistants_CourseId",
                table: "TeacherAssistants",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAssistants_DeptId",
                table: "TeacherAssistants",
                column: "DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "TeacherAssistants");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
