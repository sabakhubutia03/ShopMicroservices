# ShopMicroservices

A scalable microservices-based E-commerce ecosystem built with .NET 9, utilizing Ocelot API Gateway, Docker, and Clean Architecture principles for modular and independent service deployment.

## Services

- **UserService** — Authentication, JWT, Refresh Tokens
- **ProductService** — Products & Categories management
- **OrderService** — Order management with service-to-service communication
- **ApiGateway** — Centralized routing via Ocelot

## Tech Stack

- C#, .NET 9, ASP.NET Core
- Docker, Docker Compose
- SQL Server, Entity Framework Core
- Ocelot API Gateway
- JWT Authentication
- Clean Architecture
- GitHub Actions (CI/CD)

## Run with Docker

```bash
docker-compose up --build
```

## Architecture

Each service has its own database (Database-per-service pattern) and communicates via HTTP through the API Gateway.
