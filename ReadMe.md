# Task Management API (.net C#)

This is a simple Task Management API built with **.NET Core** and **Hangfire** for scheduling background tasks. It provides functionality for managing tasks, such as adding, viewing, and deleting tasks. The API is designed to be consumed by a frontend application and also includes a background job scheduler for performing periodic upserts.

> ## Project Requirements

#### 1. Create a .NET Solution:
- Use the latest .NET Framework version.
- Implement the solution using C#.
#### 2. Project Structure:
- Include two hosts in your solution, each in a separate .csproj file:
- One host as a WebAPI.
- One host as a WorkerService.
#### 3. Architecture:
- Develop the solution based on the Clean Architecture combined with the DDD pattern.
- Use a Class Library for each layer to implement the DDD pattern.
- The compontents of the project should comply to the SOLID principle
#### 4. Data Storage:
- Store data using the Repository Pattern with the latest version of Entity Framework Core (EF Core).
#### 5. Data Upsert:
- Implement data upsert functionality using a Hangfire Job.
- Host the Hangfire Job in the WorkerService host.
- Place the jobs in a separate Class Library.
- Schedule the job to run every hour.
#### 6. Data Source:
- Use a data source of your choice from here: https://github.com/public-api-lists/public-api-lists
#### 7. Database:
- Use MSSQL for data storage.
#### 8. Frontend:
- Add a Vue.js frontend written in Typescript.
- Display the data in a filterable grid.  

> ## Technologies

- **.NET solutions**
- **Entity Framework Core** for ORM
- **MSSQL Server** for data storage
- **MSSN** for DB test
- **Hangfire** for background job scheduling

> ## Setup

### Prerequisites

Ensure that you have the following installed:

- **.NET SDK** 6.0 or higher
- use **SQL Server Express**
- **Hangfire** for background job processing

### Clone the Repository

```bash
git clone "https://github.com/Lucas2006-work/taskmg-backend-dotnet.git"
cd task-management-api
```

> ## License

- This repository was created by **Lucas Campos**
- Copyright 2025