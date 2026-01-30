# EcoCheck API

EcoCheck es una API RESTful desarrollada en .NET 8 que permite evaluar y gestionar productos desde una perspectiva ecológica y de sostenibilidad.

## Características

- **Gestión de Productos**: CRUD completo de productos con puntuación ecológica (EcoScore)
- **Gestión de Marcas**: Administración de marcas y empresas
- **Sistema de Certificaciones**: Gestión de certificaciones ambientales y empresas certificadoras
- **Materiales**: Catálogo de materiales con información de sostenibilidad
- **Sistema de Puntuación**: Evaluación ecológica de productos
- **Traducción**: Servicio de traducción de contenido

## Tecnologías

- **Framework**: .NET 8
- **Arquitectura**: Clean Architecture
- **Base de Datos**: MySQL con Entity Framework Core
- **Autenticación**: JWT (JSON Web Tokens) con ASP.NET Core Identity
- **ORM**: Entity Framework Core 8.0.11
- **Mapper**: AutoMapper 12.0.1
- **Documentación**: Swagger/OpenAPI
- **Servidor Web**: Kestrel

## Estructura del Proyecto

```
EcoCheckBack/
├── EcoCheck.API/              # Punto de entrada de la API
├── EcoCheck.Application/      # Lógica de negocio y servicios
├── EcoCheck.Domain/           # Entidades y reglas de dominio
├── EcoCheck.Infrastructure/   # Acceso a datos e implementaciones
└── EcoCheck.sln              # Solución Visual Studio
```

## Requisitos

- .NET 8 SDK
- MySQL 8.0 o superior
- Visual Studio 2022 / VS Code

## Configuración

1. Clonar el repositorio
2. Configurar la cadena de conexión en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EcoCheck;User=root;Password=tu_password;"
  }
}
```

3. Configurar JWT en `appsettings.json`:

```json
{
  "Jwt": {
    "Key": "tu_clave_secreta_muy_larga",
    "Issuer": "EcoCheck",
    "Audience": "EcoCheckUsers"
  }
}
```

## Instalación

```bash
# Restaurar dependencias
dotnet restore

# Aplicar migraciones
dotnet ef database update

# Ejecutar la aplicación
dotnet run
```

La API estará disponible en `https://localhost:7000` y la documentación Swagger en `https://localhost:7000/swagger`

## Endpoints Principales

| Recurso | Descripción |
|---------|-------------|
| `/api/Auth` | Autenticación y registro de usuarios |
| `/api/Producto` | Gestión de productos |
| `/api/Marca` | Gestión de marcas |
| `/api/Material` | Catálogo de materiales |
| `/api/Certificacion` | Certificaciones ambientales |
| `/api/EmpresaCertificacion` | Empresas certificadoras |
| `/api/Puntuacion` | Puntuaciones ecológicas |
| `/api/Traducir` | Servicio de traducción |
| `/api/Profile` | Perfil de usuario |

## CORS

La API está configurada para permitir solicitudes desde `http://localhost:4200` (Angular).

## Licencia

Este proyecto está bajo desarrollo.
