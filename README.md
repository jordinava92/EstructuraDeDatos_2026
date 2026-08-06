# DataCore - Sistema de Gestión de Datos en Memoria

* **Institución:** Universidad Tecnológica de México (UNITEC)
* **Asignatura:** Estructura de Datos
* **Estudiante:** Nava
* **Fase:** Entrega Final (Fases 1 a 4 Integradas)
* **Plataforma / Entorno:** .NET 8.0 (C#)

---

## Descripción General

**DataCore** es una aplicación de consola desarrollada en C# que demuestra la integración de estructuras de datos dinámicas y algoritmos eficientes de ordenamiento y búsqueda. El sistema gestiona registros de datos mediante una Lista Enlazada Simple en memoria ($O(1)$ en inserción), la cual se extrae y ordena dinámicamente utilizando el algoritmo **QuickSort** ($O(n \log n)$) para habilitar búsquedas indexadas ultra rápidas mediante **Búsqueda Binaria** ($O(\log n)$).

---

## Requisitos y Ejecución

* **SDK Requerido:** [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
* **Control de Versiones:** Git

### Instrucciones para clonar y ejecutar desde cero:

```bash
# 1. Clonar el repositorio
git clone [https://github.com/tu-usuario/DataCore.git](https://github.com/tu-usuario/DataCore.git)

# 2. Entrar al directorio del proyecto
cd DataCore

# 3. Compilar y verificar 0 errores
dotnet build

# 4. Ejecutar la aplicación
dotnet run --project DataCore
```

---

## Estructura del Proyecto

```text
DataCore/
├── DataCore/
│   ├── Program.cs                 # Menú maestro CLI interactivo (do-while, 6 opciones)
│   ├── Logger.cs                  # Sistema persistente de registro de excepciones (log.txt)
│   ├── RegistroDatos.cs           # Modelo de entidad de datos (ID, Nombre, Dato)
│   ├── TablaDinamica.cs           # Implementación de Lista Enlazada y extracción a arreglo
│   └── Fase4/
│       └── BusquedaIndexada.cs    # Algoritmo de Búsqueda Binaria O(log n)
├── DataCore.Tests/
│   └── BusquedaBinariaTests.cs    # Suite de 8 Pruebas Unitarias MSTest
├── .gitignore                     # Exclusión de carpetas bin/, obj/ y logs
└── README.md                      # Documentación oficial del proyecto
```

---

## Funcionalidades Implementadas

- [x] **Fase 1 - Inserción Dinámica:** Inserción de nodos al inicio de la Lista Enlazada Simple ($O(1)$).
- [x] **Fase 2 - Gestión y Eliminación:** Eliminación segura de nodos por ID con desconexión de punteros ($O(n)$).
- [x] **Fase 3 - Extracción y Ordenamiento:** Copiado de lista a arreglo e implementación de QuickSort ($O(n \log n)$).
- [x] **Fase 4 - Búsqueda Binaria Indexada:** Algoritmo logarítmico con contador de comparaciones ($O(\log n)$).
- [x] **Menú Maestro CLI:** Interfaz iterativa con 6 opciones, validación `int.TryParse` y manejo de excepciones encadenado.
- [x] **Logging de Errores Persistente:** Captura de excepciones con timestamp y StackTrace en archivo log.
- [x] **Pruebas Unitarias MSTest:** Cobertura total de 8 casos borde de la Búsqueda Binaria.

---

## Anexo Térico: Resumen de Complejidades y Trade-offs

### Complejidad Temporal

| Operación | Estructura | Complejidad | Fase |
| :--- | :--- | :--- | :--- |
| Inserción de nodo | Lista Enlazada | $O(1)$ | Fase 1 |
| Eliminación por ID | Lista Enlazada | $O(n)$ | Fase 2 |
| Recorrido completo | Lista Enlazada | $O(n)$ | Fase 1–4 |
| Ordenado (QuickSort) | Arreglo | $O(n \log n)$ | Fase 3 |
| Ordenado (SelectionSort) | Arreglo | $O(n^2)$ | Fase 3 |
| Copia de lista a arreglo | Lista $\rightarrow$ Arreglo | $O(n)$ | Fase 3–4 |
| **Búsqueda Binaria Indexada** | **Arreglo Ordenado** | **$O(\log n)$** | **Fase 4** |

### Complejidad Espacial

| Componente | Espacio Adicional | Tipo | Observación |
| :--- | :--- | :--- | :--- |
| Lista Enlazada | $O(n)$ | Estructural | Cada nodo almacena datos + puntero `Siguiente` |
| Arreglo auxiliar | $O(n)$ | Auxiliar | Duplica datos en memoria para ordenamiento |
| QuickSort | $O(\log n)$ prom. | Implícita | Pila de recursión |
| Búsqueda Binaria | $O(1)$ | In-place | Usa punteros `izq`, `der`, `medio` |

### Justificación de Trade-offs y Comparación con la Industria

1. **QuickSort vs. TimSort (NET `Array.Sort`):** Se eligió QuickSort en memoria por su excelente rendimiento promedio $O(n \log n)$ sin requerir asignación de memoria adicional de arreglos auxiliares (a diferencia de MergeSort).
2. **Lista Enlazada vs. Doblemente Enlazada:** La lista simple minimiza el consumo de punteros por nodo (sola referencia `Siguiente`).
3. **Búsqueda Binaria Indexada vs. Hash Tables (`Dictionary<K,V>`):** La búsqueda binaria logra $O(\log n)$ sobre arreglos ordenados manteniendo bajo consumo de memoria, mientras que las tablas Hash ofrecen $O(1)$ a costa de mayor overhead de memoria y posible manejo de colisiones.

---

## Referencias y Créditos

* **Documentación Oficial de .NET:** Microsoft Learn (C# Guide & MSTest Framework).
* **Material del Curso:** Apuntes y guías del laboratorio de Estructura de Datos (UNITEC).
* **Uso Asistido de Inteligencia Artificial:** Se utilizaron modelos de IA (Gemini / ChatGPT) bajo principios éticos académicos como copiloto de desarrollo para:
  - Formulación de arquitectura y revisión del manejo de excepciones encadenadas.
  - Generación de estructura de pruebas unitarias en MSTest.
  - Plantilla de comandos Git Flow y estructuración del documento README.md.
  *(Todo el código fue revisado, depurado y validado manualmente).*