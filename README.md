# FridgePalBE 🧊📲

**FridgePalBE** is the backend API for **FridgePal** — a web application that helps users track food items in their fridge or freezer. Users can add items manually or via AI-powered image recognition, receive notifications before items expire, and optionally scan expiration dates using OCR.

This README outlines the architecture, tech stack, project structure, and MVP development goals.

---

## 🏗️ Technologies & Architecture

FridgePalBE is built using **Clean Architecture** and applies modern .NET best practices:

- **.NET 8** – ASP.NET Core Web API
- **CQRS** with [MediatR](https://github.com/jbogard/MediatR)
- **Entity Framework Core** – Data persistence
- **FluentValidation** – Request validation via MediatR pipeline behaviors
- **OperationResult** – Unified response wrapper for success/failure states
- **Cloudinary API** – For storing images and returning secure URLs
- **OpenAI GPT-4o Vision** – For analyzing uploaded images
- **Modular project structure** – with strict separation of concerns:
  - `API` – Controllers, dependency injection setup
  - `Application` – CQRS logic, DTOs, validators, interfaces
  - `Domain` – Business entities and core rules
  - `Infrastructure` – EF Core, repositories, external services

---

## 📂 Project Structure

```
FridgePalBE/
│
├── FridgePalBE.API/              → Web API entry point
│   ├── Controllers/              → MediatR endpoints
│   └── Program.cs                → DI, CORS, Swagger, middleware
│
├── FridgePalBE.Application/      → CQRS, DTOs, Validators, Interfaces
│   ├── Items/                    → Commands, Queries, Handlers
│   ├── ImageAnalysis/            → GPT-4 Vision integration
│   └── Common/                   → Shared models & contracts
│
├── FridgePalBE.Domain/           → Entities, Enums, ValueObjects
│   └── Entities/
│
├── FridgePalBE.Infrastructure/   → EF Core, Cloudinary, GPT API integration
│   └── DbContext, Services, Repositories
│
└── FridgePalBE.sln               → Solution file
```

---

## ✅ Current Features (MVP Scope)

- ✅ **Manual item entry** – Add fridge/freezer items via DTOs
- ✅ **Update & delete items** – With support for `PATCH` partial updates
- ✅ **Get all items** – Retrieve all items or by filter
- ✅ **Image analysis with GPT-4 Vision** – Extract item name, category, and estimated shelf life
- ✅ **Cloudinary integration** – Upload and serve fridge images securely
- ⏳ **OCR expiration date extraction** – Placeholder for text-based expiry scanning
- ⏳ **Notification scheduling logic** – Planned for later
- ⏳ **Barcode scanning** – Placeholder feature

---

## 📌 Notes

- Categories are fixed and shared with the frontend for consistent mapping
- Shelf life is inferred via GPT and used to calculate expiration dates
- Error handling and validation follow a centralized pipeline approach
- Database uses EF Core with a `DbContext` per bounded context

---

## 👤 Author

**Mohanad Al-Daghestani**  
.NET Developer | Gothenburg, Sweden  
📫 [mohanad.aldaghestani@gmail.com](mailto:mohanad.aldaghestani@gmail.com)  
🔗 [LinkedIn](https://www.linkedin.com/in/al-daghestani)  
💻 [GitHub](https://github.com/mohald-3)
