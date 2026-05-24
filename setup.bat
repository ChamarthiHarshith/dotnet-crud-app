@echo off
REM Setup and Run .NET CRUD Application

echo.
echo ========================================
echo .NET CRUD Application Setup Script
echo ========================================
echo.

REM Step 1: Restore Dependencies
echo [1/5] Restoring NuGet packages...
dotnet restore
if %errorlevel% neq 0 (
    echo Error: Failed to restore packages
    pause
    exit /b 1
)
echo ✓ Packages restored successfully
echo.

REM Step 2: Build Project
echo [2/5] Building project...
dotnet build
if %errorlevel% neq 0 (
    echo Error: Build failed
    pause
    exit /b 1
)
echo ✓ Project built successfully
echo.

REM Step 3: Install EF Tools
echo [3/5] Installing Entity Framework Tools...
dotnet tool install --global dotnet-ef
echo ✓ EF Tools installed
echo.

REM Step 4: Create Database
echo [4/5] Creating database and running migrations...
dotnet ef migrations add InitialCreate
if %errorlevel% neq 0 (
    echo Note: Migration might already exist, continuing...
)
dotnet ef database update
if %errorlevel% neq 0 (
    echo Error: Database update failed
    echo Check your connection string in appsettings.json
    pause
    exit /b 1
)
echo ✓ Database created successfully
echo.

REM Step 5: Run Application
echo [5/5] Starting the application...
echo.
echo ========================================
echo Application is starting...
echo Open your browser at: https://localhost:5001
echo Swagger UI: https://localhost:5001/swagger/index.html
echo ========================================
echo.

dotnet run

pause
