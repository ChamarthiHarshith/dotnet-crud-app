# .NET CRUD Application

A simple and comprehensive CRUD (Create, Read, Update, Delete) application built with .NET 6/7 and C#, using Entity Framework Core for database operations.

## Features

- ✅ Create new records
- ✅ Read/Retrieve records
- ✅ Update existing records
- ✅ Delete records
- ✅ RESTful API endpoints
- ✅ Entity Framework Core integration
- ✅ SQL Server database support
- ✅ Input validation
- ✅ Error handling

## Prerequisites

- .NET 6.0 or higher
- SQL Server (local or cloud)
- Visual Studio 2022 or VS Code

## Project Structure

```
dotnet-crud-app/
├── Models/
│   ├── Product.cs
│   └── DTOs/
│       ├── CreateProductDto.cs
│       └── UpdateProductDto.cs
├── Data/
│   └── ApplicationDbContext.cs
├── Controllers/
│   └── ProductsController.cs
├── Services/
│   ├── IProductService.cs
│   └── ProductService.cs
├── appsettings.json
├── Program.cs
└── dotnet-crud-app.csproj
```

## Setup Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/ChamarthiHarshith/dotnet-crud-app.git
cd dotnet-crud-app
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Update Connection String
Edit `appsettings.json` and update the connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=CrudDbNew;Trusted_Connection=true;TrustServerCertificate=true;"
}
```

### 4. Create Database
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5. Run the Application
```bash
dotnet run
```

The API will be available at `https://localhost:5001` (or `http://localhost:5000`)

## API Endpoints

### Get All Products
```
GET /api/products
```

### Get Product by ID
```
GET /api/products/{id}
```

### Create Product
```
POST /api/products
Content-Type: application/json

{
  "name": "Product Name",
  "description": "Product Description",
  "price": 29.99,
  "quantity": 10
}
```

### Update Product
```
PUT /api/products/{id}
Content-Type: application/json

{
  "name": "Updated Name",
  "description": "Updated Description",
  "price": 39.99,
  "quantity": 20
}
```

### Delete Product
```
DELETE /api/products/{id}
```

## Technologies Used

- **.NET 6/7** - Framework
- **C#** - Programming Language
- **Entity Framework Core** - ORM
- **SQL Server** - Database
- **ASP.NET Core** - Web Framework

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Author

Created by ChamarthiHarshith
