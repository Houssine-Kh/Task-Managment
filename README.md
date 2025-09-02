
````markdown
# Task Management App

A full-stack task management application built with:

- **Backend**: ASP.NET Core 9.0 (Clean Architecture: Api, Application, Domain, Infrastructure)
- **Frontend**: Angular (served via Nginx in production)
- **Database**: SQL Server 2022 (Docker container)

## Features

- Create and manage projects
- Add, assign, and complete tasks
- Backend tested with **xUnit**, **Moq**, and **FluentAssertions**
- Dockerized for easy deployment

---

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet)  
- [Node.js 20+](https://nodejs.org/) and npm  
- [Docker Desktop](https://www.docker.com/products/docker-desktop)  

---

## Running Locally (without Docker)

### Backend
```bash
cd src/Api
dotnet run
````

Backend will start on **[http://localhost:5000](http://localhost:5000)**

### Frontend

```bash
cd frontend
npm install
npm start
```

Frontend will start on **[http://localhost:4200](http://localhost:4200)**

---

## Running with Docker

The project includes a `docker-compose.yml` that runs:

* **SQL Server** (`sqlserver`) on port **1433**
* **Backend API** (`backend`) on port **5000**
* **Frontend (Angular + Nginx)** (`frontend`) on port **4200**

### Build & Run

```bash
docker-compose up --build
```

Now:

* Frontend → [http://localhost:4200](http://localhost:4200)
* Backend API → [http://localhost:5000](http://localhost:5000)
* SQL Server → `localhost,1433` (User: `sa`, Password: `MyPassword123!`)

---

## Testing

Run backend unit tests:

```bash
dotnet test
```

---

## Project Structure

```

- `/frontend` → Angular frontend (UI for users).  
- `/src` → Backend application using **Clean Architecture** principles.  
- `/tests` → Automated tests for backend components (xUnit, Moq, FluentAssertions).  
- `docker-compose.yml` → Runs **frontend, backend, and SQL Server** together in containers.  

---

## Notes

* Default SQL Server password is **`MyPassword123!`** (change in `docker-compose.yml` for production).
* Frontend uses Nginx in production, and proxies API requests to the backend.

---
