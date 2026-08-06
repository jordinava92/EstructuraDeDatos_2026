# DataCore v4.0 — Motor de Base de Datos en Memoria

## Descripción del Proyecto
DataCore v4.0 es la versión definitiva de un motor de gestión de datos dinámico en memoria desarrollado en C# para la asignatura de Estructuras de Datos (UNITEC). Integra listas simplemente enlazadas en el Heap, algoritmos de ordenamiento (QuickSort) y búsquedas indexadas de alta eficiencia $O(\log n)$, operadas a través de una interfaz interactiva de consola (CLI).

## Arquitectura del Sistema
El sistema está dividido en 4 capas fundamentales:
1. **Capa de Almacenamiento:** Gestión dinámica de memoria en Heap mediante `TablaDinamica` y `NodoRegistro`.
2. **Capa de Procesamiento:** Búsqueda Binaria Indexada $O(\log n)$ y QuickSort $O(n \log n)$.
3. **Capa de Presentación (CLI):** Menú maestro con validación robusta de excepciones (`FormatException`).
4. **Capa de Control de Versiones:** Implementación bajo la metodología **Git Flow Enterprise**.

## Tabla de Complejidad Computacional
| Operación | Método | Complejidad Temporal |
| :--- | :--- | :--- |
| Inserción al Inicio | `InsertarInicio()` | $O(1)$ |
| Inserción al Final | `InsertarFinal()` | $O(n)$ |
| Eliminación por ID | `EliminarPorId()` | $O(n)$ |
| Búsqueda Lineal | `BuscarRegistroLineal()` | $O(n)$ |
| Búsqueda Binaria Indexada | `BuscarRegistroIndexado()` | $O(\log n)$ |
| Ordenamiento | `QuickSort` | $O(n \log n)$ |

## Instrucciones de Compilación y Ejecución
1. Clonar el repositorio y posicionarse en la rama `main` o `release/v4.0`.
2. Ejecutar los siguientes comandos en la terminal:
   ```bash
   dotnet build
   dotnet run