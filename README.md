# VeconinterTechnicalTest 🚀
Este proyecto es una aplicación de gestión de clientes y subclientes construida con ASP.NET Core 8. Presenta una arquitectura de cebolla (Onion Architecture) y combina dos interfaces de usuario: una tradicional con ASP.NET Core MVC y Blazor Server.   

## Estructura del Proyecto

```
VeconinterTechnicalTest/
├── VeconinterTechnicalTest.sln
├── docker-compose.yml
├── README.md
├── .gitignore
│
├── VeconinterTechnicalTest.Domain/
│   ├── VeconinterTechnicalTest.Domain.csproj
│   ├── Entities/
│   │   ├── Client.cs
│   │   ├── SubClient.cs
│   │   └── User.cs
│   ├── Interfaces/
│   │   ├── IClientRepository.cs
│   │   ├── ISubClientRepository.cs
│   │   ├── IUserRepository.cs
│   │   └── IUnitOfWork.cs
│   ├── ValueObjects/
│   │   ├── Email.cs
│   │   └── Phone.cs
│   └── Exceptions/
│       └── DomainException.cs
│
├── VeconinterTechnicalTest.Application/
│   ├── VeconinterTechnicalTest.Application.csproj
│   ├── DTOs/
│   │   ├── ClientDto.cs
│   │   ├── SubClientDto.cs
│   │   └── UserDto.cs
│   ├── Services/
│   │   ├── Interfaces/
│   │   │   ├── IClientService.cs
│   │   │   ├── ISubClientService.cs
│   │   │   ├── IAuthService.cs
│   │   │   └── IValidationStrategy.cs
│   │   └── Implementation/
│   │       ├── ClientService.cs
│   │       ├── SubClientService.cs
│   │       ├── AuthService.cs
│   │       ├── EmailValidationStrategy.cs
│   │       └── PhoneValidationStrategy.cs
│   ├── Factories/
│   │   └── ClientFactory.cs
│   └── Mappings/
│       └── AutoMapperProfile.cs
│
├── VeconinterTechnicalTest.Infrastructure/
│   ├── VeconinterTechnicalTest.Infrastructure.csproj
│   ├── Data/
│   │   ├── ApplicationDbContext.cs
│   │   ├── Configurations/
│   │   │   ├── ClientConfiguration.cs
│   │   │   ├── SubClientConfiguration.cs
│   │   │   └── UserConfiguration.cs
│   │   └── Migrations/
│   ├── Repositories/
│   │   ├── BaseRepository.cs
│   │   ├── ClientRepository.cs
│   │   ├── SubClientRepository.cs
│   │   ├── UserRepository.cs
│   │   └── UnitOfWork.cs
│   └── DependencyInjection.cs
│
└── VeconinterTechnicalTest.Web/
├── VeconinterTechnicalTest.Web.csproj
├── Program.cs
├── appsettings.json
├── appsettings.Development.json
├── Dockerfile
├── Controllers/
│   ├── HomeController.cs
│   ├── AuthController.cs
│   ├── ClientController.cs
│   └── SubClientController.cs
├── Views/
│   ├── _ViewImports.cshtml
│   ├── _ViewStart.cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   ├── _ValidationScriptsPartial.cshtml
│   │   └── Error.cshtml
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── Privacy.cshtml
│   ├── Auth/
│   │   └── Login.cshtml
│   ├── Client/
│   │   ├── Index.cshtml
│   │   ├── Details.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Delete.cshtml
│   └── SubClient/
│       ├── Create.cshtml
│       └── Edit.cshtml
├── Components/
│   ├── App.razor
│   ├── Routes.razor
│   ├── Pages/
│   │   ├── _Host.cshtml
│   │   ├── Index.razor
│   │   └── Clients/
│   │       ├── ClientList.razor
│   │       └── ClientDetail.razor
│   └── Shared/
│       ├── MainLayout.razor
│       ├── NavMenu.razor
│       └── _Imports.razor
└── wwwroot/
├── css/
│   └── site.css
├── js/
│   └── site.js
└── favicon.ico
```
## Requisitos

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- [Docker](https://www.docker.com/) (opcional)

## Configuración Inicial

1. Clona el repositorio:
```bash
  git clone git@github.com:Carlosx1/VeconinterTechnicalTest.git
  cd VeconinterTechnicalTest
```

2. Instala dependencias:
```bash
  dotnet restore 
```

3. Configura variables de entorno:
   - Copia `.env.example` a `.env` y completa los valores requeridos:
     - `ASPNETCORE_ENVIRONMENT`
     - `ConnectionStrings__DefaultConnection`

4. Aplica migraciones de la base de datos (opcional): 
```bash
  dotnet ef database update --project VeconinterTechnicalTest.Infrastructure\VeconinterTechnicalTest.Infrastructure.csproj --startup-project VeconinterTechnicalTest.Web\VeconinterTechnicalTest.Web.csproj --context VeconinterTechnicalTest.Infrastructure.Data.ApplicationDbContext --configuration Debug 20250904092802_Initial
```

## Ejecución de la Aplicación

- Backend:
```bash
  dotnet run --project VeconinterTechnicalTest.Web
```

## Acceso Inicial

- URL: https://localhost:7000
- Usuario: admin
- Contraseña: admin123

## Funcionalidades

### MVC (Razor)
- `/Home/Index` - Página principal
- `/Auth/Login` - Iniciar sesión
- `/Client` - Lista de clientes
- `/Client/Create` - Crear cliente
- `/Client/{id}/Details` - Detalles del cliente
- `/SubClient/Create/{clientId}` - Crear subcliente

## Características Implementadas

- Arquitectura de cebolla (Onion Architecture)
- Patrón Factory y Strategy
- CRUD de Clientes y SubClientes
- Autenticación con cookies
- Entity Framework Core + SQL Server
- AutoMapper para mapeo de DTOs
- Validación de datos
- Interfaces MVC y Blazor Server
- Contenedorización con Docker

## Patrones de Diseño

- Factory Pattern: `ClientFactory`
- Strategy Pattern: `EmailValidationStrategy`, `PhoneValidationStrategy`
- Repository Pattern
- Unit of Work Pattern
- Dependency Injection


## Seguridad

- Autenticación basada en cookies
- Validación de entrada de datos
- Protección contra CSRF
- Hash de contraseñas
- Autorización en controladores y componentes

## Docker
- Construir imagen:
```bash
  docker build -t clientmanagement-web -f VeconinterTechnicalTest.Web/Dockerfile .
```
- Ejecutar con Docker Compose:
```bash
  docker-compose up
```