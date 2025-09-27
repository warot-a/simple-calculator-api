# SimpleCalc

A demonstration calculator API developed using ASP.NET Core 8.0, designed to showcase end-to-end testing capabilities with Postman

## API Endpoints

All endpoints are available under `/api/calc`:

- `GET /api/calc/add?a={number}&b={number}` - Add two numbers
- `GET /api/calc/subtract?a={number}&b={number}` - Subtract second number from first
- `GET /api/calc/multiply?a={number}&b={number}` - Multiply two numbers
- `GET /api/calc/divide?a={number}&b={number}` - Divide first number by second

## Technology Stack

- **Framework**: ASP.NET Core 8.0
- **Language**: C# 12.0
- **Documentation**: Swagger/OpenAPI 3.0
- **Testing**: xUnit with ASP.NET Core Test Host
- **Target Framework**: .NET 8.0

## Dependencies

### Main Project
- `Microsoft.AspNetCore.OpenApi` (8.0.20)
- `Swashbuckle.AspNetCore` (6.6.2)

### Test Project
- `Microsoft.AspNetCore.Mvc.Testing` (8.0.20)
- `Microsoft.NET.Test.Sdk` (17.12.0)
- `xunit` (2.9.2)
- `xunit.runner.visualstudio` (2.8.2)
- `coverlet.collector` (6.0.2)

## Getting Started

### Prerequisites
- .NET 8.0 SDK
- Visual Studio 2022 or VS Code (optional)

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
```

### Expected Response Format
```json
{
  "result": 15.0
}
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

The test project includes:
- **Integration tests** using `Microsoft.AspNetCore.Mvc.Testing`
- **Unit tests** for controller methods
- **Test coverage** with Coverlet
- **xUnit** as the testing framework

## API Documentation

When running in development mode, Swagger UI is available at `/swagger` providing:
- Interactive API documentation
- Request/response examples
- Parameter descriptions
- Try-it-out functionality

## License

This project is provided as-is for educational and demonstration purposes.
