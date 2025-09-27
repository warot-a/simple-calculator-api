# SimpleCalc

A demonstration calculator API developed using ASP.NET Core 8.0, designed to showcase end-to-end testing capabilities with Postman

## API Endpoints

All endpoints are available under `/api/calc`:

- `GET /api/calc/add?a={number}&b={number}` - Add two numbers
- `GET /api/calc/subtract?a={number}&b={number}` - Subtract second number from first
- `GET /api/calc/multiply?a={number}&b={number}` - Multiply two numbers
- `GET /api/calc/divide?a={number}&b={number}` - Divide first number by second
- `GET /api/calc/power?baseNumber={number}&exponent={number}` - Calculate power of a number
- `GET /api/calc/sqrt?number={number}` - Calculate square root of a number

## Technology Stack

- **Framework**: ASP.NET Core 8.0
- **Language**: C# 12.0
- **Documentation**: Swagger/OpenAPI 3.0
- **Testing**: xUnit with ASP.NET Core Test Host
- **E2E Testing**: Bun + Newman + Postman Collections
- **Target Framework**: .NET 8.0

## Dependencies

### Main Project
- `Microsoft.AspNetCore.OpenApi` (8.0.20)
- `Swashbuckle.AspNetCore` (6.6.2)

### Unit Test Project
- `Microsoft.AspNetCore.Mvc.Testing` (8.0.20)
- `Microsoft.NET.Test.Sdk` (17.12.0)
- `xunit` (2.9.2)
- `xunit.runner.visualstudio` (2.8.2)
- `coverlet.collector` (6.0.2)

### E2E Test Project
- `newman` (^6.0.0) - Postman collection runner
- `@types/newman` (5.3.6) - TypeScript types for Newman
- `@types/bun` (latest) - TypeScript types for Bun runtime

## Getting Started

### Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022 or VS Code (optional)
- Bun runtime (for e2e testing)

### Running the Application

1. **Clone or navigate to the project directory**
2. **Build the solution:**
   ```bash
   dotnet build
   ```

3. **Run the API:**
   ```bash
   cd SimpleCalc
   dotnet run
   ```

4. **Access the application:**
   - HTTPS: `https://localhost:7219`
   - HTTP: `http://localhost:5141`
   - Swagger UI: `https://localhost:7219/swagger`

### Running Tests

Execute all tests:
```bash
dotnet test
```

Run tests with coverage:
```bash
dotnet test --collect:"XPlat Code Coverage"
```

### Running E2E Tests

The project includes end-to-end tests using Postman collections executed via Newman and Bun.

1. **Navigate to the e2e directory:**
   ```bash
   cd e2e
   ```

2. **Install e2e dependencies:**
   ```bash
   bun install
   ```

3. **Ensure the API is running** (in another terminal):
   ```bash
   cd SimpleCalc
   dotnet run
   ```

4. **Run e2e tests:**
   ```bash
   bun start
   ```

The e2e tests will:
- Automatically set the `BASE_URL` environment variable to `http://localhost:5141`
- Discover and run all Postman collections in the `collections` directory
- Provide detailed test results with pass/fail status
- Exit with appropriate error codes for CI/CD integration

#### E2E Test Structure
```
e2e/
├── collections/
│   └── SimpleCalc.postman_collection.json  # Postman collection with API tests
├── index.ts                                # Test runner script
├── package.json                           # Bun dependencies
└── tsconfig.json                          # TypeScript configuration
```

## Example Usage

### Using cURL

```bash
# Add two numbers
curl "https://localhost:7219/api/calc/add?a=10&b=5"

# Subtract
curl "https://localhost:7219/api/calc/subtract?a=10&b=3"

# Multiply
curl "https://localhost:7219/api/calc/multiply?a=4&b=7"

# Divide
curl "https://localhost:7219/api/calc/divide?a=15&b=3"

# Power
curl "https://localhost:7219/api/calc/power?baseNumber=2&exponent=3"

# Square root
curl "https://localhost:7219/api/calc/sqrt?number=16"
```

### Expected Response Format
```json
15.0
```

### Error Response Format
For invalid operations (division by zero, negative square root):
```json
"Division by zero is not allowed"
```

## Development

### Project Configuration

The project uses:
- **Implicit usings** enabled
- **Nullable reference types** enabled
- **Development environment** with enhanced logging
- **HTTPS redirection** in production

### Launch Profiles

Two launch profiles are configured:
- **HTTP**: `http://localhost:5141`
- **HTTPS**: `https://localhost:7219` (default)

## Testing

The project includes comprehensive testing at multiple levels:

### Unit and Integration Tests
The test project includes:
- **Integration tests** using `Microsoft.AspNetCore.Mvc.Testing`
- **Unit tests** for controller methods
- **Test coverage** with Coverlet
- **xUnit** as the testing framework

### End-to-End Tests
The e2e project provides:
- **Postman collections** with comprehensive API tests
- **Newman integration** for programmatic test execution
- **Bun runtime** for fast TypeScript execution
- **Automated environment setup** with BASE_URL configuration
- **Error handling tests** for edge cases (division by zero, negative square root)
- **CI/CD ready** with proper exit codes and detailed logging

#### E2E Test Coverage
- ✅ Addition operations
- ✅ Multiplication operations  
- ✅ Division operations (including division by zero error handling)
- ✅ Power calculations
- ✅ Square root calculations (including negative number error handling)
- ✅ HTTP status code validation
- ✅ Response value validation
- ✅ Error message validation

## API Documentation

When running in development mode, Swagger UI is available at `/swagger` providing:
- Interactive API documentation
- Request/response examples
- Parameter descriptions
- Try-it-out functionality

## License

This project is provided as-is for educational and demonstration purposes.
