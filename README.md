# Ecommerce API (.NET Core)

RESTful API built with ASP.NET Core implementing a layered architecture pattern to ensure clean separation of concerns, scalability, and maintainability.

##  Architecture

The project follows a layered architecture:

- **Presentation Layer** → ASP.NET Core Web API (Controllers)
- **Business Logic Layer** → Services (DTOs, Validation, Business Rules)
- **Data Access Layer** → Entity Framework Core (Repositories, DbContext)

##  Features

- User Authentication & Authorization (JWT)
- Role-based access control
- Product management (CRUD operations)
- Category management
- Cart system
- Payment handling integration
- Logging system
- Global exception handling
- FluentValidation for input validation

##  Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- AutoMapper
- FluentValidation
- Serilog
- Stripe (Payments)

## 📦 Project Structure
