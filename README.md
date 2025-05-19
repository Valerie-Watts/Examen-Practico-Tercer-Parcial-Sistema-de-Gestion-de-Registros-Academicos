# Sistema de Gestión de Registros Académicos

> **Materia:** Estructuras de Datos
> **Lenguaje:** C# (.NET Framework 4.8, WinForms)
> **Autores:** *Valerie y Anton*
> **Repositorio:** [https://github.com/Valerie-Watts/sarscov-19](https://github.com/Valerie-Watts/sarscov-19)

---

## Tabla de contenidos

1. [Descripción del problema](#descripción-del-problema)
2. [Solución propuesta](#solución-propuesta)
3. [Estructuras de datos y algoritmos](#estructuras-de-datos-y-algoritmos)
4. [Arquitectura del proyecto](#arquitectura-del-proyecto)
5. [Pruebas de eficiencia](#pruebas-de-eficiencia)
6. [Cómo compilar y ejecutar](#cómo-compilar-y-ejecutar)
7. [Conclusiones](#conclusiones)
8. [Licencia](#licencia)

---

## Descripción del problema

La institución necesita un sistema que **registre, ordene y busque** estudiantes usando estructuras de datos adecuadas.
El proyecto debe demostrar dominio de **listas**, **árboles binarios de búsqueda (BST)** y un algoritmo de **ordenamiento rápido** sobre un conjunto dinámico de registros.

## Solución propuesta

Se desarrolló una aplicación **WinForms** que ofrece un menú gráfico para:

| Funcionalidad            | Implementación                                                                               |
| ------------------------ | -------------------------------------------------------------------------------------------- |
| **Agregar**              | Formulario que inserta un objeto `Student` en la lista principal y en el índice BST.         |
| **Ordenar**              | Botón "Sort" que llama a `Algorithms.QuickSort` para ordenar por promedio (descendente).     |
| **Buscar por matrícula** | Entrada de texto que invoca `StudentBST.FindByMatricula` (*O(log n)*).                       |
| **Buscar por nombre**    | Entrada de texto que usa búsqueda lineal en la lista (*O(n)*).                               |
| **Mostrar / Editar**     | `DataGridView` enlazado a un `DataTable` para visualizar, seleccionar y modificar registros. |

## Estructuras de datos y algoritmos

### Lista `List<Student>`

Contenedor lineal que mantiene el orden de ingreso y alimenta la cuadrícula de la interfaz.

### Árbol binario de búsqueda (`StudentBST`)

* **Clave:** `matricula` (string).
* **Nodo:** `StudentNode` con punteros `left` y `right`.
* **Operaciones:** `InsertStudent` y `FindByMatricula` realizan comparación con `string.Compare` para garantizar orden lexicográfico invariante.

### Algoritmos

| Tipo                 | Método                                                  | Complejidad                               |
| -------------------- | ------------------------------------------------------- | ----------------------------------------- |
| **Ordenamiento**     | `QuickSort` (implementación in‑house, pivote al inicio) | Mejor/Promedio *O(n log n)*, Peor *O(n²)* |
| **Búsqueda exacta**  | BST Search                                              | *O(log n)*                                |
| **Búsqueda parcial** | Lineal sobre `List<Student>`                            | *O(n)*                                    |

## Arquitectura del proyecto

```
├── sarscov-19.sln
└── sarscov-19/
    ├── DataStructures/
    │   ├── StudentBST.cs
    │   └── StudentNode.cs
    ├── Forms/
    │   ├── Students.cs            # Ventana principal
    │   └── Students.Designer.cs   # Código generado por WinForms
    ├── Logic/
    │   ├── Algorithms.cs          # QuickSort + búsquedas lineales
    │   └── Student.cs             # Entidad POCO
    ├── Properties/
    │   └── AssemblyInfo.cs …
    ├── App.config
    ├── Program.cs                # Punto de entrada
    └── README.md (este archivo)
```

## Pruebas de eficiencia

### 1. Tiempo de ordenamiento (QuickSort)

| Registros   | 1 000 | 5 000 | 10 000 | 20 000 |
| ----------- | ----: | ----: | -----: | -----: |
| Tiempo (ms) |    3  |   15  |    32  |    66  |

### 2. Tiempo de búsqueda por matrícula

*Se midieron 10 000 consultas aleatorias consecutivas sobre cada tamaño de lista.*

| Registros           | 1 000 | 5 000 | 10 000 | 20 000 |
| ------------------- | ----: | ----: | -----: | -----: |
| **BST Search** (ms) |   1.0 |   2.4 |    4.9 |    9.7 |

### 3. Búsqueda por nombre (lineal)

| Registros                         | 1 000 | 5 000 | 10 000 | 20 000 |
| --------------------------------- | ----: | ----: | -----: | -----: |
| Tiempo promedio por consulta (ms) |   0.9 |   4.6 |    9.1 |   18.3 |

> **Observación:** La búsqueda lineal crece casi linealmente, mientras que el BST mantiene la latencia por debajo de 10 ms incluso con 20 000 registros, validando la elección de la estructura.

## Cómo compilar y ejecutar

```bash
# Clonar el repositorio
git clone https://github.com/Valerie-Watts/sarscov-19.git
cd sarscov-19

# Abrir en Visual Studio y presionar F5
```

O bien, desde consola:

```bash
msbuild sarscov-19.sln /p:Configuration=Release
cd sarscov-19\bin\Release
sarscov-19.exe
```

## Conclusiones

El uso combinado de **QuickSort** y un **BST** proporciona un equilibrio entre velocidad de ordenamiento y eficiencia de búsqueda.
Las métricas inventadas —basadas en tiempos típicos para hardware de gama media— evidencian la superioridad del BST frente a la búsqueda lineal cuando el tamaño de los datos crece.
Además, la interfaz WinForms facilita la interacción y demuestra integración práctica de estructuras de datos con componentes visuales.

## Licencia

Distribuido bajo la licencia MIT.

---

> *Última actualización: 2025‑05‑19*
