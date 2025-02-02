# 🎓 University Management System

A console-based university management system built with C# and Entity Framework Core, demonstrating clean architecture and object-oriented programming principles.

## 📋 Overview

This learning project implements a comprehensive university management system that handles the core operations of a university, including student enrollment, course management, and faculty administration.

## ✨ Features

### User Management
- Multi-user authentication system (Admin, Student, Doctor)
- Secure password-based login
- Role-based access control

### Admin Features
- Add/Remove students, doctors, and courses
- View comprehensive lists of all university members
- Manage teacher assistants
- Department management

### Student Features
- Course enrollment system
- Personal data viewing
- GPA tracking
- View enrolled courses

### Doctor Features
- Course assignment management
- Personal information management
- View assigned courses
- Department affiliation

## 🛠 Technical Stack

- **Language**: C# (.NET Core)
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Configuration**: JSON-based settings
- **Architecture**: N-tier Architecture

## 🏗 Project Structure

```
University_Management_System/
├── Entity/
│   ├── User.cs             # Base user class
│   ├── Student.cs          # Student entity
│   ├── Doctor.cs           # Doctor entity
│   ├── Admin.cs            # Admin entity
│   ├── Course.cs           # Course management
│   ├── Department.cs       # Department structure
│   ├── TeacherAssistant.cs # TA management
│   └── Enrollment.cs       # Course enrollment
├── Data/
│   └── AppDbContext.cs     # EF Core context
└── Helper.cs               # Utility functions
```

## 🚀 Getting Started

### Prerequisites
- .NET Core SDK (6.0 or later)
- SQL Server
- Visual Studio 2019 or later (recommended)

### Installation

1. Clone the repository
```bash
git clone [repository-url]
```

2. Update the connection string in `Appsettings.json`
```json
{
  "constr": "your-connection-string-here"
}
```

3. Run Entity Framework migrations
```bash
dotnet ef database update
```

4. Build and run the application
```bash
dotnet run
```

## 💡 Usage

1. Launch the application
2. Select your role (Admin/Student/Doctor)
3. Log in with your credentials
4. Navigate through the menu options using the provided interface

## 🎯 Learning Objectives

This project serves as a practical implementation of:
- Object-Oriented Programming principles
- Database design and management
- User authentication and authorization
- Console application UI/UX
- Clean code practices

## 👥 Contributing

This is a learning project, but contributions are welcome! Please feel free to submit a pull request.

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

## 🙏 Acknowledgments

This project was created as a learning exercise to demonstrate C# programming concepts and database management skills.
