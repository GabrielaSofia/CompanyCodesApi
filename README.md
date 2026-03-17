# CompanyCodesApi

API REST desarrollada en .NET Core siguiendo principios de Clean Architecture y SOLID.

## 🚀 Tecnologías utilizadas

- .NET Core
- Entity Framework Core
- PostgreSQL
- AutoMapper
- Swagger

---

## 🧱 Arquitectura

El proyecto sigue Clean Architecture:

- Domain → Entities
- Application → DTOs, Servicios, Interfaces, Mappings
- Infrastructure → Repositorios, DbContext
- API → Controllers

---

## 📦 Funcionalidades

- Create y Update de Enterprise
- Create y Update de Code
- Relación Enterprise - Code (1:N)
- Endpoints adicionales:
  - Obtener códigos por empresa usando id
  - Obtener todas las empresas
  - Obtener empresa con codigos usando su nit
  - Obtener empresa usando id del código


---

## 🔗 Endpoints principales

### Codes

- GET /api/codes/{id}
- PATCH /api/codes/{id}
- GET /api/codes/{id}/enterprise
- POST /api/codes

### Enterprises

- GET /api/enterprises
- POST /api/enterprises
- GET /api/enterprises/{id}
- PATCH /api/enterprises/{id}
- GET /api/enterprises/nit/{nit}
- GET /api/enterprises/{id}/codes

---

## 🗄️ Base de datos

Motor: PostgreSQL

### Enterprise
- Id (PK)
- Name (Requerido)
- Nit (Opcional)
- Gln (Requerido)

### Code
- Id (PK)
- Name (Requerido)
- Description (Opcional)
- EnterpriseId (FK)

---

## ⚙️ Configuración

En `appsettings.json`:

{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=CompanyCodes;Username=***;Password=***"
  }
}

---

## ▶️ Ejecutar proyecto

dotnet restore
dotnet build
dotnet run

---

## 🧪 Pruebas

https://localhost:{port}/swagger

---

## 🧠 Buenas prácticas aplicadas

- Clean Architecture
- Principios SOLID
- Uso de DTOs
- AutoMapper
- Inyección de dependencias
- Manejo de relaciones con EF Core

---

## 👩‍💻 Autor

Gabriela Calpa
