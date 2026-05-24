# Setup Instructions

## Prerequisites
- .NET 7.0 or higher
- SQL Server 2019 or higher (or SQL Server Express)
- Visual Studio Code or Visual Studio 2022 (optional)

## Quick Setup (Windows)

### Option 1: Automated Setup (Recommended)
1. **Navigate to project directory** in Command Prompt
2. **Run the setup script:**
   ```bash
   setup.bat
   ```
   This will automatically:
   - Restore NuGet packages
   - Build the project
   - Install Entity Framework tools
   - Create database and migrations
   - Start the application

### Option 2: Manual Setup

#### Step 1: Restore Dependencies
```bash
dotnet restore
```

#### Step 2: Build Project
```bash
dotnet build
```

#### Step 3: Install EF Tools (if not installed)
```bash
dotnet tool install --global dotnet-ef
```

#### Step 4: Configure Database Connection
Edit `appsettings.json` and set your SQL Server connection string:

**For Local SQL Server Express:**
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=CrudDbNew;Trusted_Connection=true;TrustServerCertificate=true;"
}
```

**For Named Instance:**
```json
"DefaultConnection": "Server=YOUR_SERVER_NAME;Database=CrudDbNew;Integrated Security=true;TrustServerCertificate=true;"
```

**For Remote Server:**
```json
"DefaultConnection": "Server=YOUR_SERVER_IP;Database=CrudDbNew;User Id=sa;Password=YOUR_PASSWORD;TrustServerCertificate=true;"
```

#### Step 5: Create Database
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

#### Step 6: Run Application
```bash
dotnet run
```

## Accessing the Application

Once running, the application will be available at:

- **API Base URL:** `https://localhost:5001/api/products`
- **Swagger UI:** `https://localhost:5001/swagger/index.html`
- **HTTP:** `http://localhost:5000`

## Testing the API

### Using Swagger UI (Easiest)
1. Go to `https://localhost:5001/swagger/index.html`
2. Click on endpoint and click "Try it out"
3. Execute requests directly from the browser

### Using cURL

**Get All Products:**
```bash
curl https://localhost:5001/api/products
```

**Get Product by ID:**
```bash
curl https://localhost:5001/api/products/1
```

**Create Product:**
```bash
curl -X POST https://localhost:5001/api/products \
  -H "Content-Type: application/json" \
  -d "{\"name\":\"Laptop\",\"description\":\"High Performance\",\"price\":999.99,\"quantity\":5}"
```

**Update Product:**
```bash
curl -X PUT https://localhost:5001/api/products/1 \
  -H "Content-Type: application/json" \
  -d "{\"name\":\"Updated Laptop\",\"description\":\"Ultra Performance\",\"price\":1299.99,\"quantity\":3}"
```

**Delete Product:**
```bash
curl -X DELETE https://localhost:5001/api/products/1
```

### Using Postman
1. Download and install Postman
2. Create requests to `https://localhost:5001/api/products`
3. Set appropriate HTTP methods (GET, POST, PUT, DELETE)
4. Add JSON body for POST and PUT requests

## Troubleshooting

### Issue: "localhost refused to connect"
**Solution:**
- Make sure the app is running with `dotnet run`
- Check if port 5001 is already in use
- Try running on different port: `dotnet run --urls "http://localhost:3000"`

### Issue: "Database connection failed"
**Solution:**
- Verify SQL Server is installed and running
- Check connection string in `appsettings.json`
- Verify database server name and credentials
- Run `sqlcmd -S .` to test local connection

### Issue: "Migration already exists"
**Solution:**
- This is normal if you've run setup before
- Just continue, the database will be updated

### Issue: "Port 5001 already in use"
**Solution:**
```bash
# Kill process on port 5001 (Windows)
netstat -ano | findstr :5001
taskkill /PID <PID> /F

# Or run on different port
dotnet run --urls "https://localhost:5002"
```

### Issue: ".NET version mismatch"
**Solution:**
```bash
# Check installed .NET versions
dotnet --list-sdks

# Check project requires .NET 7.0
# If you have .NET 6.0, update project file to net6.0
```

## Environment-Specific Settings

### Development
- Edit `appsettings.Development.json` for development settings
- Run with: `dotnet run`

### Production
- Edit `appsettings.json` with production database
- Run with: `dotnet run --configuration Release`

## Stopping the Application
- Press `Ctrl + C` in the terminal

## Next Steps
- Explore the Swagger UI to understand all endpoints
- Review the code in `Controllers/ProductsController.cs`
- Check `Services/ProductService.cs` for business logic
- Modify the `Product` model for your needs

For issues or questions, check the README.md file or review the source code comments.
