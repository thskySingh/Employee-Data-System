# Employee Data System

A web application for managing employee information — built with **ASP.NET Core MVC** and **Entity Framework Core** using the **Code‑First** approach and **MS SQL Server** database.

## 🧠 Overview

Employee Data System is a role‑based web application that allows users to **register, log in, and securely manage employee records**. The system supports full **CRUD (Create, Read, Update, Delete)** operations on employee data and follows the MVC architectural pattern.

This project demonstrates real‑world backend concepts such as authentication, database design using Entity Framework Core, and LINQ‑based data querying.

## 🚀 Features

* 🔐 User Registration & Login
* 👤 Authentication‑based access
* ✅ Create new employee records
* 📋 View employee list
* ✏️ Edit employee details
* 🗑️ Delete employee records
* 📦 ASP.NET Core MVC architecture
* 🧠 Entity Framework Core (Code‑First approach)
* 🔍 LINQ for database queries
* 🗄️ MS SQL Server database

## 🛠 Tech Stack

| Technology | Details                            |
| ---------- | ---------------------------------- |
| Framework  | ASP.NET Core MVC                   |
| ORM        | Entity Framework Core (Code‑First) |
| Language   | C#                                 |
| Database   | MS SQL Server                      |
| Querying   | LINQ                               |
| Frontend   | Razor Views, HTML, CSS             |

## 🔐 Authentication Module

The application includes **user authentication** with the following capabilities:

* User Registration page to create an account
* Login page for authenticated access
* Validation for user credentials
* Restricted access to employee operations for logged‑in users

This ensures that only authorized users can manage employee data.

## 🚧 Getting Started

### Prerequisites

* .NET SDK installed
* Visual Studio / VS Code
* SQL Server (LocalDB or full version)

### Installation Steps

1. Clone the repository

   ```bash
   git clone https://github.com/thskySingh/Employee-Data-System.git
   ```

2. Open the solution file in Visual Studio

3. Configure the database connection string in `appsettings.json`

4. Apply migrations and create database

   ```bash
   dotnet ef database update
   ```

5. Run the application

   ```bash
   dotnet run
   ```

6. Open browser and navigate to the local URL shown in the console

## 📁 Project Structure

```
Employee-Data-System
│
├── Controllers
├── Models
├── Views
├── Migrations
├── Data
├── wwwroot
├── appsettings.json
├── Program.cs
└── README.md
```

## ⚙️ How It Works

* Models define database schema using Code‑First approach
* Entity Framework Core handles database operations
* LINQ is used for querying employee data
* Controllers process requests and manage logic
* Razor Views render dynamic UI
* Authentication controls access to CRUD features

## 🧪 Usage

1. Register a new user account
2. Login with credentials
3. Perform CRUD operations on employee data
4. Logout securely after use

## 📌 Future Enhancements

* Role‑based authorization (Admin/User)
* Search and filter employees
* Pagination
* UI improvements
* Password hashing and security enhancements

## 🤝 Contribution

Contributions are welcome!

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push and open a Pull Request

## 📄 License

This project is open‑source and free to use for learning and development purposes.
