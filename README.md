# FridgePalBE 🧊📲

**FridgePalBE** is the backend API for FridgePal — a web application designed to help users keep track of items in their fridge or freezer. The application will support both manual and AI-assisted item entry, notification scheduling for expiring items, and optional barcode scanning for food recognition. This README outlines the architectural principles, technologies used, and MVP goals for backend development.

---

## 🧩 MVP User Stories

- ✅ As a user, I want to manually add an item to my list
- ✅ As a user, I want to remove an item from my list
- ⌛ As a user, I want to scan a product barcode to automatically get the product name and category
- ⌛ As a user, I want to scan an item (e.g., fruit/vegetable) to auto-extract name and category
- ⌛ As a user, I want to scan and auto-extract expiration date
- ⌛ As a user, I want to get notified when an item is about to expire
- ⌛ As a user, I want to choose whether I get notified or not
- ⌛ As a user, I want to choose *how* I get notified
- ⌛ As a user, I want to set custom notification timing
- 🚫 As a new user, I want to register a new account *(Not in MVP)*
- 🚫 As a user, I want to log in to my account *(Not in MVP)*

---

## 🏗️ Technologies & Architecture

FridgePalBE follows **Clean Architecture** and uses:

- **.NET 8** – Web API
- **CQRS** with [MediatR](https://github.com/jbogard/MediatR)
- **Entity Framework Core**
- **FluentValidation** (via MediatR Pipeline Behaviors)
- **AutoMapper** – DTO to Entity mapping
- **OperationResult** – Consistent API response wrapping
- **Modular structure** – With clear separation of:
  - `API` (Controllers, DI)
  - `Application` (CQRS logic, DTOs, interfaces)
  - `Infrastructure` (EF Core, persistence, services)
  - `Domain` (Entities, business rules)

---

## 📂 Project Structure

```
FridgePalBE/
│
├── FridgePalBE.API/            → Web API entry point
│   ├── Controllers/
│   └── Program.cs, DI setup
│
├── FridgePalBE.Application/    → CQRS, Validators, DTOs, Interfaces
│   ├── Items/
│   └── Common/
│
├── FridgePalBE.Domain/         → Core business entities & logic
│   └── Entities/
│
├── FridgePalBE.Infrastructure/ → Data persistence, services
│   └── Repositories, EF Core DbContext
│
└── FridgePalBE.sln             → Solution file
```

---

## 🚧 Development Focus

For the MVP, the backend team is focusing on:

- CRUD operations for fridge items
- Integration points for image & barcode scanning (placeholder for now)
- Notification preference and logic structure (to be implemented)
- Building out a flexible, testable, and maintainable backend

---

## 👤 Author

**Mohanad Al-Daghestani**  
.NET Developer | Gothenburg, Sweden  
📫 [mohanad.aldaghestani@gmail.com](mailto:mohanad.aldaghestani@gmail.com)  
🔗 [LinkedIn](https://www.linkedin.com/in/al-daghestani)  
💻 [GitHub](https://github.com/mohald-3)