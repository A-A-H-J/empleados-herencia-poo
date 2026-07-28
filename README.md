# Sistema de Gestión de Empleados con Herencia y Clases Abstractas

Aplicación de consola en C# que gestiona empleados de una empresa, aplicando herencia, clases abstractas, métodos virtuales/override y manejo de excepciones.

## Integrantes del equipo

- Gloria Belen Santos Lazo SL262479 
- Moisés Rafael Martínez Sosa MS260964
- Alexander Antonio Hernández Juárez HJ262340

## Diagrama de clases UML

<img width="752" height="402" alt="imagen" src="https://github.com/user-attachments/assets/5feafe82-9d60-4fda-baf6-44faa4e94018" />

## Explicación de la jerarquía de clases y uso de herencia

El sistema se organiza alrededor de una clase abstracta `Empleado`, que define lo que todo empleado tiene en común:

- **Atributos privados**: `nombre` e `id`, accesibles mediante propiedades públicas que validan que no estén vacíos.
- **Constructor**: recibe nombre e id y los asigna a través de las propiedades (por lo que la validación se aplica automáticamente).
- **Método abstracto `CalcularSalario()`**: no tiene implementación en `Empleado`, porque cada tipo de empleado calcula su salario de forma distinta. Obliga a que toda clase derivada lo implemente.
- **Método virtual `ToString()`**: tiene una implementación por defecto, pero cada clase derivada la sobrescribe (`override`) para mostrar también sus datos específicos.

De `Empleado` heredan tres clases concretas:

- **`EmpleadoPorHora`**: agrega `SueldoPorHora` y `HorasTrabajadas`. Calcula el salario como `SueldoPorHora * HorasTrabajadas`.
- **`EmpleadoAsalariado`**: agrega `SueldoMensual`. Su salario es ese valor fijo.
- **`EmpleadoComisionista`**: agrega `SueldoBase`, `VentasRealizadas` y `PorcentajeComision`. Calcula el salario como `SueldoBase + (VentasRealizadas * PorcentajeComision)`.

Todos los empleados se almacenan en una única `List<Empleado>`, sin importar su tipo concreto. Gracias al polimorfismo, al recorrer la lista y llamar a `CalcularSalario()` o `ToString()`, cada objeto ejecuta automáticamente la versión correspondiente a su clase real, sin necesidad de preguntar de qué tipo es cada empleado.

Para el manejo de errores, se creó la excepción personalizada `EmpleadoNoEncontradoException`, que se lanza cuando se busca o elimina un empleado con un ID que no existe. El programa la captura con `try-catch` y muestra el mensaje de error sin detenerse.

## Instrucciones para ejecutar el programa

### Requisitos previos

- .NET SDK 8.0 o superior instalado.

### Pasos

1. Clona el repositorio

2. Ejecuta el programa

3. Usa el menú interactivo para:
   - Agregar empleados (elige el tipo: por hora, asalariado o comisionista)
   - Mostrar todos los empleados con su salario calculado
   - Buscar un empleado por ID
   - Eliminar un empleado
   - Salir del programa

## Capturas de pantalla

### Agregar empleados y Calcular y mostrar salarios
<img width="365" height="313" alt="imagen" src="https://github.com/user-attachments/assets/6ac87fab-9a04-4f70-b3c9-e3aa74e3ed00" />
<img width="280" height="168" alt="imagen" src="https://github.com/user-attachments/assets/1974e16f-4d28-4287-8ddd-39b5573f012f" />
<img width="333" height="203" alt="imagen" src="https://github.com/user-attachments/assets/2a105376-58a3-412f-8cf3-355b0d1b3e04" />

### Buscar empleado por ID
<img width="819" height="169" alt="imagen" src="https://github.com/user-attachments/assets/b2fae7b1-7560-449a-b8e3-fc74ce2a8aed" />

### Intentar eliminar un empleado inexistente (manejo de excepción)
<img width="401" height="161" alt="imagen" src="https://github.com/user-attachments/assets/8f35393a-9426-46fc-8418-8bce7f370407" />
