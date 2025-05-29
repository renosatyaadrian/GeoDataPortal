```markdown
# 🌍 GeoDataPortal

A 3-tier .NET web application for managing geospatial data, time series records, and user management.

## 📦 Features

- **User Management**: Create, update, delete, and list system users.
- **GeoData Management**: CRUD operations for geospatial data with embedded GeoJSON support.
- **TimeSeries Data**: Manage time-based data points linked to GeoData, such as temperature, rainfall, or pollution.
- **Clean Architecture**: Layered structure using Domain, Application, Infrastructure, and UI projects.
- **Database Integration**:
  - MSSQL for user data
  - PostgreSQL for geospatial (GeoData)
  - MySQL for timeseries data

## 🧱 Technologies

- .NET 8 / ASP.NET Core Web API
- Blazor WebAssembly (UI)
- Entity Framework Core
- SQL Server / PostgreSQL / MySQL
- Swagger for API testing
- CORS & HttpClient for inter-layer communication

## 🗂️ Project Structure

GeoDataPortal/
│
├── GeoDataPortal.Domain        # Entities and base interfaces
├── GeoDataPortal.Application   # Interfaces, DTOs, and business logic
├── GeoDataPortal.Infrastructure# Database contexts and service implementations
├── GeoDataPortal.API           # Web API entry point
└── GeoDataPortal.UI            # Blazor WASM front-end

````

## 🚀 Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/GeoDataPortal.git
cd GeoDataPortal
````

### 2. Run the Backend API

Make sure to update connection strings in `appsettings.json` and run the backend:

```bash
cd GeoDataPortal.API
dotnet run
```

By default it will run at:

```
http://localhost:5096
https://localhost:7020
```

### 3. Run the Front-End (Blazor UI)

```bash
cd GeoDataPortal.UI
dotnet run
```

Visit `http://localhost:5000` (or your configured port).

## 🧪 Testing

Unit tests can be found in the `GeoPortal.Tests` project. Run tests via:

```bash
cd GeoDataPortal.Tests
dotnet test
```

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

## 📌 Notes

* Backend and UI must run simultaneously for the full app to function.
* You can modify GeoData to include additional attributes like "type" or "unit" in time series.

## 📃 License

MIT License – feel free to use and modify as needed.

---

Made with 💻 by \[Your Name]

```

---

Jika kamu sudah punya nama repo GitHub, aku bisa bantu menyesuaikan bagian URL atau badge-nya juga.

Perlu ditambahkan badges seperti build status, .NET version, atau lain-lain juga?
```
