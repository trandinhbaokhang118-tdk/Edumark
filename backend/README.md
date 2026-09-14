# EduMark Catalog Service

Demo-ready .NET 9 microservice system. Catalog uses layered architecture, EF Core, SQLite, validation, standard errors, Swagger and seed data. Notification is an independent service receiving enrollment events over HTTP.

## Run

```powershell
cd backend
dotnet run --project src/EduMark.Api --urls http://localhost:5080
```

Open `http://localhost:5080/swagger`. The database and sample courses are created automatically.

## Run both microservices with Docker

```powershell
docker compose up --build
```

- Catalog Swagger: `http://localhost:5080/swagger`
- Notification Swagger: `http://localhost:5090/swagger`

An enrollment is persisted before Notification is called. Therefore Notification being offline does not undo the enrollment; in production, this boundary evolves to an Outbox pattern and message broker.

Endpoints: `GET /health`, `GET|POST /api/v1/courses`, `GET|PUT|DELETE /api/v1/courses/{id}`, `GET|POST /api/v1/courses/{courseId}/enrollments`.

```json
{ "title": "C# Clean Architecture", "description": "A practical course about maintaining boundaries in .NET services.", "price": 29.99, "isPublished": true }
```

`Api` owns HTTP, `Application` use-case contracts, `Domain` business entities, and `Infrastructure` EF Core/persistence. This service can be deployed separately from future Identity, Payment and Learning services.
