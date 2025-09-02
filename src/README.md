# Task Management Backend (ASP.NET Core 9)

This is the **backend API** for the Task Management application.  
It is built using **.NET 9**, following **Clean Architecture**, **CQRS**, and **DDD** principles.

---

## Architecture Overview

The backend is organized into four main projects:

### 1. **Domain**
- Contains core business logic and entities (Projects, Tasks, Users, etc.).
- Defines domain events (e.g., `TaskCompletedEvent`).
- Contains value objects and aggregates.
- No external dependencies.

### 2. **Application**
- Implements **CQRS** (Commands & Queries).
- Application services (use cases).
- Validation using **FluentValidation**.
- Handlers for domain events.
- Interfaces that are implemented by Infrastructure.

### 3. **Infrastructure**
- Database access via **Entity Framework Core**.
- Migrations and repository implementations.
- Implements interfaces defined in Application.
- Handles persistence and external integrations.

### 4. **API**
- ASP.NET Core Web API.
- Controllers that expose endpoints to the frontend.
- Dependency injection setup.
- Swagger/OpenAPI documentation.
- Entry point for the application.

---

## Entities & Features

- **Projects**:  
  - Create, update, delete projects.  
  - Each project contains a collection of tasks.  

- **Tasks**:  
  - Add tasks to projects.  
  - Assign tasks to users.  
  - Mark tasks as complete.  
  - Delete tasks.  

- **Users** (basic):  
  - Used for task assignment.  
  - Can be extended with authentication/authorization.  

---

## Technologies & Patterns

- **ASP.NET Core 9**
- **Entity Framework Core** (Code First, Migrations)
- **FluentValidation** (validation rules)
- **CQRS** with MediatR
- **Domain Events**
- **xUnit** + **Moq** + **FluentAssertions** (tests)

---

## Running Locally

1. Update your connection string in `appsettings.Development.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost,1433;Database=TaskManagementDb;User Id=sa;Password=MyPassword123!;TrustServerCertificate=True"
   }
