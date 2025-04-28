This project is a video streaming application developed with **ASP.NET Core MVC** .NET 8, designed for educational purposes.
## 📖 About ITLA TV+

ITLA TV+ is a streaming video application built using ASP.NET Core MVC.

It includes the following key functionalities:

- **Home**: Main screen displaying a list of all series with options for search, filtering, and sorting.
- **Series Management**: Create, edit, and delete series, including details like name, cover image, YouTube link, primary and secondary genres, and production company.
- **Producer Management**: Manage production companies by creating, editing, and deleting records.
- **Genre Management**: Manage genres by creating, editing, and deleting records.

## 🖥️ Technologies Used

### Frontend
- HTML
- CSS
- Bootstrap
- ASP.NET Razor Pages

### Backend
- C# with ASP.NET Core MVC 8
- Microsoft Entity Framework Core
- Microsoft Entity Framework Core Relational
- Microsoft Entity Framework Core SQL Server
- Microsoft Entity Framework Core Tools
- Microsoft Entity Framework Core Design
- Entity Framework Code First

### ORM
- Entity Framework

### Database
- SQL Server

## 🖼️ Project Image

### Home Screen
![Home Screen](https://github.com/Jaqz23/Itla-Tv-Plus/blob/3cc07a56e37fff02b242012e36e5daae1675dd41/Home.png)

## 📋 Prerequisites

Before running ITLA TV+, make sure you have the following installed:

- Visual Studio 2022 or later
- ASP.NET Core SDK (8.0 onwards)
- SQL Server (local or remote)

## 🚀 Installation

1. **Download** the project or clone it.

2. **Open** the project in Visual Studio 2022.

3. **Configure** the database connection:
   - Open the `appsettings.Development.json` file.
   - Update the `Server` name to match your local environment, for example:

     ```json
     {
       "ConnectionStrings": {
         "DefaultConnection": "Server=YourServerName;"
       }
       // other configurations...
     }
     ```

4. In Visual Studio, go to:

   - **Tools > NuGet Package Manager > Package Manager Console**

5. In the **Package Manager Console**:
   - Ensure that the Web Application project is selected as the **Default Project**.
   - You can select the default project using the dropdown menu in the Package Manager Console toolbar.

6. In the console, run the following command to apply migrations and create the database:

   ```bash
   Update-Database

7. Run the project:

    - Press F5 or click the Run button.

    -The application will launch automatically in your default web browser.
