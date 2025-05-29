---
# 🌍 GeoDataPortal

A 3-tier .NET web application for managing geospatial data, time series records, and user management.

---
## 📦 Features

* **User Management**: Create, update, delete, and list system users.
* **GeoData Management**: CRUD operations for geospatial data with embedded GeoJSON support.
* **TimeSeries Data**: Manage time-based data points linked to GeoData, such as temperature, rainfall, or pollution.
* **Clean Architecture**: Layered structure using Domain, Application, Infrastructure, and UI projects.
* **Database Integration**:
    * **MSSQL** for user data
    * **PostgreSQL** for geospatial (GeoData)
    * **MySQL** for timeseries data

---
## 🧱 Technologies

* .NET 8 / ASP.NET Core Web API
* Blazor WebAssembly (UI)
* Entity Framework Core
* SQL Server / PostgreSQL / MySQL
* Swagger for API testing
* CORS & HttpClient for inter-layer communication

---
## 🏛️ Architecture Design

This project adopts a **3-Layered Architecture** with a strong emphasis on **Separation of Concerns** and **Clean Architecture principles**.

### Why 3-Layered Architecture?

We chose this architectural pattern for its proven benefits in building robust, maintainable, and scalable enterprise applications:

* **Clear Separation of Concerns (SoC):** Each layer has a distinct responsibility, reducing complexity and making the codebase easier to understand and manage.
    * **Presentation Layer:** Handles user interaction and displays information.
    * **Business Logic Layer:** Contains core business rules and orchestrates operations.
    * **Data Layer:** Manages data persistence and retrieval.
* **Loose Coupling:** Changes in one layer have minimal impact on other layers. For instance, modifying the UI technology does not require changes to the core business logic or data access.
* **High Cohesion:** Components within each layer are closely related to their specific responsibility, leading to more focused and testable units of code.
* **Maintainability and Testability:** The layered structure facilitates easier debugging, maintenance, and allows for independent unit testing of business logic, contributing to higher code quality.
* **Scalability:** Each layer can potentially be scaled independently based on load, providing flexibility for future growth.
* **Flexibility for Technology Changes:** Allows for swapping out technologies in one layer (e.g., changing the UI framework or database) without drastically affecting other parts of the application.

### Architecture Implementation

The 3-layered architecture is implemented through the following project structure:

* **Presentation Layer (`GeoDataPortal.API` & `GeoDataPortal.UI`):**
    * **`GeoDataPortal.API` (Web API):** Serves as the primary entry point for client applications. It receives HTTP requests, performs initial input validation (using DTOs), delegates business logic to the `Application` layer, and returns appropriate HTTP responses.
    * **`GeoDataPortal.UI` (Blazor WASM):** Provides the single-page application (SPA) front-end, interacting with the `GeoDataPortal.API` to fetch and display data, and to send user commands.
* **Business Logic Layer (`GeoDataPortal.Application`):**
    * This layer is the heart of the application, containing the core business rules and use cases.
    * It defines **Application Services** (e.g., `UserService`, `GeoDataService`, `TimeseriesService`) that orchestrate operations, perform business validations, and manage transactions.
    * **Data Transfer Objects (DTOs)** are defined here to serve as the contract for data flowing between the Presentation and Business Logic layers, ensuring domain entities are not directly exposed.
    * It defines interfaces for repositories (e.g., `IUserRepository`), ensuring the `Infrastructure` layer only provides implementation details.
* **Data Layer (`GeoDataPortal.Infrastructure`):**
    * This layer is responsible for data persistence. It contains the concrete implementations of repository interfaces defined in the `Domain` or `Application` layer.
    * It includes **Database Contexts** (for MSSQL, PostgreSQL, and MySQL using Entity Framework Core) and specific repository implementations that interact with the respective databases.
    * It handles the mapping of domain entities to database schemas.

---
## 🗂️ Project Structure

```
GeoDataPortal/
│
├── GeoDataPortal.Domain        # Entities and base interfaces
├── GeoDataPortal.Application   # Interfaces, DTOs, and business logic
├── GeoDataPortal.Infrastructure# Database contexts and service implementations
├── GeoDataPortal.API           # Web API entry point
└── GeoDataPortal.UI            # Blazor WASM front-end
```

---
## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/GeoDataPortal.git
cd GeoDataPortal
```

### 2. Run the Backend API

Make sure to update connection strings in `appsettings.json` and run the backend:

```bash
cd GeoDataPortal.API
dotnet run
```

By default it will run at:

* `http://localhost:5096`
* `https://localhost:7020`

### 3. Run the Front-End (Blazor UI)

```bash
cd GeoDataPortal.UI
dotnet run
```

Visit `http://localhost:5000` (or your configured port).

---
## 🧪 Testing

Unit tests can be found in the `GeoPortal.Tests` project. Run tests via:

```bash
cd GeoDataPortal.Tests
dotnet test
```

---
## 📝 Example GeoJSON Input

```json
{
  "type": "Feature",
  "geometry": {
    "type": "Point",
    "coordinates": [110.414, -7.781]
  },
  "properties": {
    "name": "Sample Point"
  }
}
```

---
## 📌 Notes

* Backend and UI must run simultaneously for the full app to function.
* You can modify GeoData to include additional attributes like "type" or "unit" in time series.