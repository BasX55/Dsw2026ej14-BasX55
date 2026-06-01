# Desarrollo de Software
## Ejercicio N° 14
### Arquitectura, Principios y Patrones

A partir de la solución del `Ejercicio N° 5 - Empresa de Transporte`, resolver.


## 🛠️ Tareas
- Organizar las capas con la ayuda de librerías de clase
- Separar las funcionalidades (incluido el Menú) en múltiples clases (vistas)
- Manejar cada vista con un presentador (controlador) independiente
- Conectar presentadores y vistas siguiendo el patrón MVP (Model-View-Presenter)
- Desacoplar la clase persistencia
- Implementar `Dependency Injection`

## 📁 Estructura de la solución

```
Dsw2026Ej14/ (solución)
├── Dsw2026Ej14/ (proyecto)
│   ├── Presenters/
│   ├── Interfaces/
│   ├── Models/
│   └── Views/
├── Dsw2026Ej14.Domain/ (proyecto)
│   ├── Entities/
│   └── Interfaces/
└── Dsw2026Ej14.Data/ (proyecto)
    ├── Dtos/
    └── Sources/

```
### Características de la Solución

- Lenguaje: C# 14.0
- Plataforma: .NET 10