# AppBooking

**AppBooking** es una aplicación de gestión de reservas desarrollada en C#, con una arquitectura en capas que sigue buenas prácticas de diseño para una mayor escalabilidad, mantenibilidad y seguridad.

## 🚀 Descripción

Este proyecto está diseñado para gestionar reservas en una plataforma utilizando una arquitectura dividida en diferentes capas. La solución se divide en múltiples proyectos, cada uno con una responsabilidad específica, lo que facilita su mantenimiento y evolución.

## 📂 Estructura del Proyecto

1. **App.Booking.Api**  
   La capa de la API que expone las funcionalidades del sistema. Gestiona las solicitudes HTTP y es responsable de recibir y responder peticiones externas, como las realizadas desde el frontend o clientes.

2. **App.Booking.Common**  
   Contiene clases, enumeraciones y utilidades comunes utilizadas en todas las capas. Es la capa que abstrae los elementos reutilizables a lo largo de la aplicación, evitando la duplicación de código.

3. **App.Booking.Application**  
   Esta capa gestiona la lógica de negocio y los casos de uso. Actúa como un puente entre la API y el dominio, orquestando las operaciones necesarias y haciendo uso de los datos y servicios de otras capas.

4. **App.Booking.Domain**  
   Contiene las entidades del modelo de datos y las reglas de negocio fundamentales. Representa la lógica y el comportamiento del dominio, siendo la capa central sobre la que se construyen las demás.

5. **App.Booking.External**  
   Gestiona las integraciones con servicios externos. Aquí se encuentran los componentes responsables de interactuar con APIs de terceros, servicios de correo electrónico, autenticación externa y otros servicios externos que no forman parte del núcleo del sistema.

6. **App.Booking.Persistence**  
   Encargada de interactuar con la base de datos y almacenar los datos persistentes. Usa tecnologías como Entity Framework para la comunicación con la base de datos y maneja las operaciones de lectura y escritura.

## 🛠️ Funcionalidades

- **Autenticación y autorización** mediante **JWT (JSON Web Tokens)**.
- **Integración con Azure KeyVault** para la gestión segura de secretos y configuraciones sensibles.
- **Documentación automática de la API** a través de **Swagger**.
- **Servicio de correo** para notificaciones y comunicaciones.
- **Validación de datos** con validadores personalizados.

## 📦 Dependencias

- **.NET 6+**
- **Application Insights** (para monitoreo y análisis de rendimiento)
- **Swagger** (para la documentación de la API)
- **JWT Bearer Tokens** (para autenticación)
- **Azure KeyVault** (para la gestión de secretos)
