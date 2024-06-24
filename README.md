# SegEmpleadosBack
# Proyecto de Autenticación con JWT

Este proyecto es una implementación de un sistema de autenticación basado en JSON Web Tokens (JWT) usando .NET v6 para el backend  

## Descripción

El objetivo de este proyecto es un examen el cual Incluye:

- **Backend**: Implementado en .NET, gestiona la creación y validación de tokens JWT.

## Requisitos

### Backend

- .NET SDK 6.0 o superior
- SQL Server (o cualquier otra base de datos compatible con EF Core)

### Clonar el repositorio

 git clone https://github.com/damiancn/SegEmpleadosBack.git
### Procedimiento
 Actualiza el archivo appsettings.json con la cadena de conexión de tu base de datos:

  "ConnectionStrings": {
        "DefaultConnection": "Server=tu_servidor;Database=tu_base_de_datos;User Id=tu_usuario;Password=tu_contraseña;"
    },

Aplicar las migraciones no va a ser necesario, debido a que estas se ejecutan cuando se pone en marcha el proyecto,
solo asegurate que SeguimientoEmpleadosAPI tenga la opción seleccionada como "Set as startu project"

Con eso las migraciones se estaran preparando y cargando datos previos para la base de datos.
