using GestionEmpleados;

// ====================================================================
// ESTE ARCHIVO ES SOLO UNA PRUEBA TEMPORAL DE PERSONA A.
// Verifica que las 4 clases y la excepción compilan e instancian bien.
// BÓRRALO (o vacíalo) antes de mandar el proyecto a Persona B:
// el menú real de consola lo construye Persona C al final de la cadena.
// ====================================================================

List<Empleado> empleados = new List<Empleado>
{
    new EmpleadoPorHora("Ana Gómez", "E001", 5.50m, 160),
    new EmpleadoAsalariado("Luis Pérez", "E002", 900),
    new EmpleadoComisionista("Marta Ruiz", "E003", 400, 3000, 0.05m)
};

foreach (var emp in empleados)
{
    Console.WriteLine(emp);
}

// Prueba de la excepción personalizada
try
{
    string idBuscado = "E999";
    Empleado? encontrado = empleados.Find(e => e.Id == idBuscado);
    if (encontrado is null)
        throw new EmpleadoNoEncontradoException(idBuscado);
}
catch (EmpleadoNoEncontradoException ex)
{
    Console.WriteLine($"Excepción capturada correctamente: {ex.Message}");
}
