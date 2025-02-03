# 🎓 University Management System

A comprehensive console-based application for managing university operations, built with C# and Entity Framework Core. This project was developed as a learning exercise to practice clean architecture, SOLID principles, and design patterns.

## 🌟 Features

### Administrative Functions
- Student Management
  - Add/Remove students
  - View all students
  - Track student enrollment
  - Manage student GPA and level

- Course Management
  - Add/Remove courses
  - Assign doctors (professors) to courses
  - Track course credits
  - Department-based course organization

- Faculty Management
  - Add/Remove doctors (professors)
  - Manage teaching assistants
  - Department assignments
  - Course assignments

### Student Portal
- Personal dashboard
- Course enrollment system
- GPA tracking
- View enrolled courses
- Personal data management

### Doctor (Professor) Portal
- View assigned courses
- Personal information management
- Department affiliation

## 🛠 Technical Stack

- **Framework**: .NET Core
- **Language**: C# 
- **Database**: Microsoft SQL Server
- **ORM**: Entity Framework Core
- **Configuration**: JSON-based settings
- **Architecture**: N-tier Architecture

## 🏗 Design Patterns Used

1. **Repository Pattern**
   - Implemented through DatabaseHelper class
   - Centralizes data access logic
   - Provides abstraction over data persistence

2. **Singleton Pattern**
   - Used in DatabaseHelper and Helper classes
   - Ensures single instance for database operations
   - Manages shared resources efficiently

3. **Factory Method Pattern**
   - User authentication implementation
   - Creates different types of users (Admin, Student, Doctor)

## 📐 SOLID Principles Implementation

1. **Single Responsibility Principle (SRP)**
   - Helper class for UI operations
   - DatabaseHelper for data operations
   - Separate entity classes for different domain objects

2. **Open/Closed Principle (OCP)**
   - User class hierarchy allows extension
   - New user types can be added without modifying existing code

3. **Liskov Substitution Principle (LSP)**
   - Proper inheritance hierarchy with User as base class
   - Derived classes (Student, Doctor, Admin) maintain base class contracts

4. **Interface Segregation Principle (ISP)**
   - Focused entity classes
   - Specific functionality for each user type

5. **Dependency Inversion Principle (DIP)**
   - Database context abstraction
   - Configuration management through interfaces

## 🏃‍♂️ Getting Started

1. Clone the repository
2. Update the connection string in `Appsettings.json`
3. Run Entity Framework migrations
4. Build and run the application

## 🎯 Learning Outcomes

- Implementation of N-tier Architecture
- Working with Entity Framework Core
- Database relationship management
- User authentication and authorization
- Clean code principles
- Console application UI/UX design

## 📝 Note

This is a learning project developed to understand and implement various software development concepts, patterns, and principles. It's not intended for production use but serves as a demonstration of software development best practices.

## 📜 License

This project is open source and available under the MIT License.
