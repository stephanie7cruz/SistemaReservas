Instrucciones en el README para configurar y ejecutar el backend
A continuación, muestro las instrucciones detalladas que incluí en el archivo README.md para que otros puedan configurar y ejecutar el backend sin problemas:

markdown
Copiar código
# Sistema de Reservas - Backend

Este es el backend para el sistema de reservas, desarrollado con ASP.NET Core Web API.

## Requisitos

- .NET 8 SDK o superior
- SQL Server (local o remoto) configurado y accesible

## Configuración del Backend

1. **Clonar el repositorio**:
   ```bash
   git clone https://github.com/tu-usuario/sistema-reservas-backend.git
   cd sistema-reservas-backend
Restaurar dependencias: Asegúrate de tener todas las dependencias necesarias ejecutando:

bash
Copiar código
dotnet restore
Configurar la cadena de conexión a la base de datos:

En el archivo appsettings.json, configura la cadena de conexión a tu base de datos SQL Server:
json
Copiar código
"ConnectionStrings": {
    "AppDbContext": "Server=localhost;Database=SistemaReservas;Trusted_Connection=True;"
}
Ejecutar migraciones de la base de datos (si estás usando Entity Framework): Si es necesario, ejecuta las migraciones para crear las tablas en la base de datos:

bash
Copiar código
dotnet ef database update
Ejecutar la aplicación: Para iniciar el backend, ejecuta el siguiente comando:

bash
Copiar código
dotnet run
Acceder a la documentación de la API: Una vez que la aplicación esté en ejecución, abre tu navegador y ve a la URL:

text
Copiar código
https://localhost:7139/swagger
Allí podrás ver la documentación interactiva de todos los endpoints de la API.

Endpoints principales
GET /reservas: Obtiene todas las reservas.
POST /reservas: Crea una nueva reserva.
PUT /reservas/{id}: Actualiza una reserva existente.
DELETE /reservas/{id}: Elimina una reserva.
Para más detalles, consulta la documentación generada automáticamente por Swagger en la URL mencionada anteriormente.

Contribuciones
Las contribuciones son bienvenidas. Si tienes alguna sugerencia o corrección, abre un issue o realiza un pull request.

yaml
Copiar código

---

### **Pruebas y ejecución de la API**

Con Swagger habilitado, pude probar y documentar cada uno de los endpoints directamente desde el navegador sin necesidad de herramientas adicionales como Postman, aunque también se puede exportar la colección de Swagger a Postman si prefieres utilizar esa herramienta.


