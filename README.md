
# 📦 SimpleRestfulWebAPI (.NET 8)

A RESTful Web API built with **.NET 8** that integrates with the public mock API at [restful-api.dev](https://restful-api.dev). It extends functionality with filtering, pagination, Redis caching, validation, and error handling.

---

## 🚀 Features

- 🔗 Integration with [https://restful-api.dev](https://restful-api.dev)
- 🔍 Filter products by name substring
- 📃 Pagination support for product listing
- ➕ Add new product to the mock API
- ❌ Remove a product by ID
- 🧠 Redis caching using `Microsoft.Extensions.Caching.StackExchangeRedis`
- ✅ Model validation using data annotations
- 🛡️ Global error handling middleware
- 🧪 Swagger UI for API testing

---

## 🧰 Technologies Used

- [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- ASP.NET Core Web API
- StackExchange.Redis
- Microsoft.Extensions.Caching.StackExchangeRedis
- Swagger (Swashbuckle)
- DataAnnotations for validation

---

## ⚙️ Getting Started

### ✅ Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Redis server running locally or remotely

---

### 🛠️ Setup

1. **Clone the Repository**
   ```bash
   git clone https://github.com/your-username/SimpleRestfulWebAPI.git
   cd SimpleRestfulWebAPI
   ```

2. **Set up Redis**

   Make sure Redis is running. The app expects it on:
   ```
   localhost:6379
   ```

3. **Configure `appsettings.json`**

   Update the `Redis` section if needed:

   ```json
   "Redis": {
     "ConnectionString": "localhost:6379",
     "InstanceName": "SimpleRestfulWebAPI_"
   }
   ```

4. **Run the API**
   ```bash
   dotnet run
   ```

5. **Open Swagger**
   ```
   https://localhost:<port>/swagger
   ```

---

## 📡 API Endpoints

### 🔍 GET `/api/products`

Fetch products with optional filtering and pagination.

**Query Parameters:**
- `name` (optional): Filter products containing the substring
- `page` (default: 1)
- `pageSize` (default: 10)

---

### ➕ POST `/api/products`

Add a new product.

**Sample Request:**
```json
{
  "name": "Apple iPhone 15",
  "data": {
    "color": "Black",
    "capacity": "256 GB"
  }
}
```

---

### ❌ DELETE `/api/products/{id}`

Delete a product by its `id`.

---

## 🧠 Redis Caching

- All product list queries are cached based on their filter and paging parameters.
- Configurable via `appsettings.json`.

---

## ✅ Validation

- All input is validated using `[Required]`, `[MaxLength]`, etc.
- Invalid input returns `400 Bad Request` with details.

---

## 🛡️ Error Handling

- Global error handler captures unhandled exceptions
- Returns consistent error format

---

## 📁 Project Structure

```
SimpleRestfulWebAPI/
├── Controllers/
├── Services/
├── Caching/
├── Middleware/
├── Models/
├── Program.cs
├── appsettings.json
└── README.md
```

---

## 📄 License

MIT License. See [LICENSE](LICENSE) for details.

---

## 🤝 Contributing

Pull requests are welcome! Feel free to open issues or suggest features.

---

## 🙋‍♀️ Author

**Neha Shah**  
👩‍💻 .NET Developer | 17+ Years Experience  
📫 [Your contact or GitHub profile link here]
