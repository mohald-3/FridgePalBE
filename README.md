
# FridgePalBE 🧊📲

**FridgePalBE** is a .NET 8 Web API built using Clean Architecture principles, enabling a secure and structured personal safety check-in system. Users can register, log in, check in once per day, add friends, and view check-in history — all supported by a modular, maintainable backend design.

---

## 🧩 Project Features

- ✅ User Registration & JWT-based Authentication
- 📍 Daily Check-in System (one per day)
- 👥 Friend Management (Add / Remove)
- 📅 View Check-in History (own and friends’)
- 📦 Clean Architecture with strong separation of concerns
- 🧪 FluentValidation via MediatR pipeline behaviors
- 🔁 Consistent `OperationResult<T>` API response pattern
- 📘 API documentation via Swagger & Postman collection

---

## 📁 Folder Structure

```
FridgePalBE/
│
├── FridgePalBE.API/            → API layer (controllers, DI setup)
├── FridgePalBE.Application/    → CQRS, DTOs, handlers, validators, interfaces
├── FridgePalBE.Domain/         → Entities and enums
├── FridgePalBE.Infrastructure/ → EF Core, DbContext, repositories, auth
└── FridgePalBE.Persistence/    → Seed data, migrations
```

---

## 🔧 Technologies Used

- **.NET 8** (ASP.NET Core Web API)
- **Clean Architecture**
- **CQRS** with [MediatR](https://github.com/jbogard/MediatR)
- **Entity Framework Core**
- **AutoMapper** for DTO mapping
- **FluentValidation** integrated via pipeline behaviors
- **JWT Authentication**
- **Swagger/OpenAPI** for API documentation
- **Postman** collection for testing and sharing

---

## ⚙️ Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/mohald-3/FridgePalBE.git
cd FridgePalBE
```

### 2. Update the Database Connection

In `appsettings.Development.json` (under `FridgePalBE.API`), update your connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=FridgePal;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## 🛠️ Run Migrations & Seed Data

### 1. Apply EF Core Migrations

```bash
cd FridgePalBE.API
dotnet ef database update
```

> Make sure the `FridgePalBE.Infrastructure` project is correctly referenced.

### 2. Seed Initial Data (if applicable)

Seed logic runs automatically on application startup if configured. See `DbInitializer` under `Infrastructure/Persistence`.

---

## 🚀 Running the API

```bash
cd FridgePalBE.API
dotnet run
```

The API will launch at `https://localhost:5001` (or port configured in `launchSettings.json`).

---

## 📬 Example API Usage

### 📌 1. Register

```http
POST /api/auth/register
Content-Type: application/json

{
  "username": "jane_doe",
  "email": "jane@example.com",
  "password": "SecurePass123!"
}
```

### 🔐 2. Login

```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "jane@example.com",
  "password": "SecurePass123!"
}
```

Returns a JWT token to use for authenticated requests.

### ✅ 3. Check-In

```http
POST /api/checkin
Authorization: Bearer {token}
```

### 👀 4. Get My Check-In History

```http
GET /api/checkin/history
Authorization: Bearer {token}
```

---

## 📨 Using the Postman Collection

1. Open [Postman](https://www.postman.com/)
2. Import the included collection:  
   `FridgePalBE.postman_collection.json`
3. Use the **environment** variables (`baseUrl`, `token`) for convenience
4. Explore and test endpoints like:
   - `/api/auth/register`
   - `/api/auth/login`
   - `/api/checkin`
   - `/api/friends`

---

## 👤 Author

**Mohanad Al-Daghestani**  
.NET Developer | Gothenburg, Sweden  
📫 [mohanad.aldaghestani@gmail.com](mailto:mohanad.aldaghestani@gmail.com)  
🔗 [LinkedIn](https://www.linkedin.com/in/al-daghestani)  
💻 [GitHub](https://github.com/mohald-3)

---

## 📃 License

This project is open source and available under the [MIT License](LICENSE).
