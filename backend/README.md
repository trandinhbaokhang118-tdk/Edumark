# EduMark Catalog Service

Demo-ready ASP.NET Core 9 microservice: layered architecture, EF Core, SQLite, validation, standard errors, Swagger and seed data.

## Run

```powershell
cd backend
dotnet run --project src/EduMark.Api --urls http://localhost:5080
```

Open `http://localhost:5080/swagger`. The database and sample courses are created automatically.

Endpoints: `GET /health`, `GET|POST /api/v1/courses`, `GET|PUT|DELETE /api/v1/courses/{id}`, `GET|POST /api/v1/courses/{courseId}/enrollments`.

```json
{ "title": "C# Clean Architecture", "description": "A practical course about maintaining boundaries in .NET services.", "price": 29.99, "isPublished": true }
```

`Api` owns HTTP, `Application` use-case contracts, `Domain` business entities, and `Infrastructure` EF Core/persistence. This service can be deployed separately from future Identity, Payment and Learning services.
