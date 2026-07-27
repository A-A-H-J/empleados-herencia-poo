using GestionEmpleados;

List<Empleado> empleados = new List<Empleado>();

bool continuar = true;

while (continuar)
{
    Console.WriteLine();
    Console.WriteLine("===== Sistema de Gestión de Empleados =====");
    Console.WriteLine("1. Agregar empleado");
    Console.WriteLine("2. Mostrar todos los empleados");
    Console.WriteLine("3. Buscar empleado por ID");
    Console.WriteLine("4. Eliminar empleado");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");

    string? opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            AgregarEmpleado();
            break;
        case "2":
            MostrarEmpleados();
            break;
        case "3":
            BuscarEmpleado();
            break;
        case "4":
            EliminarEmpleado();
            break;
        case "5":
            continuar = false;
            break;
        default:
            Console.WriteLine("Opción inválida.");
            break;
    }
}

void AgregarEmpleado()
{
    Console.WriteLine();
    Console.WriteLine("Tipo de empleado:");
    Console.WriteLine("1. Por hora");
    Console.WriteLine("2. Asalariado");
    Console.WriteLine("3. Comisionista");
    Console.Write("Seleccione: ");
    string? tipo = Console.ReadLine();

    try
    {
        string nombre = LeerTexto("Nombre: ");
        string id = LeerId();

        Empleado nuevoEmpleado;

        switch (tipo)
        {
            case "1":
                decimal sueldoPorHora = LeerDecimalPositivo("Sueldo por hora: ");
                decimal horasTrabajadas = LeerDecimalPositivo("Horas trabajadas: ");
                nuevoEmpleado = new EmpleadoPorHora(nombre, id, sueldoPorHora, horasTrabajadas);
                break;
            case "2":
                decimal sueldoMensual = LeerDecimalPositivo("Sueldo mensual: ");
                nuevoEmpleado = new EmpleadoAsalariado(nombre, id, sueldoMensual);
                break;
            case "3":
                decimal sueldoBase = LeerDecimalPositivo("Sueldo base: ");
                decimal ventasRealizadas = LeerDecimalPositivo("Ventas realizadas: ");
                decimal porcentajeComision = LeerDecimalPositivo("Porcentaje de comisión (ej. 0.05): ");
                nuevoEmpleado = new EmpleadoComisionista(nombre, id, sueldoBase, ventasRealizadas, porcentajeComision);
                break;
            default:
                Console.WriteLine("Tipo inválido.");
                return;
        }

        empleados.Add(nuevoEmpleado);
        Console.WriteLine("Empleado agregado correctamente.");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void MostrarEmpleados()
{
    Console.WriteLine();
    if (empleados.Count == 0)
    {
        Console.WriteLine("No hay empleados registrados.");
        return;
    }

    foreach (Empleado emp in empleados)
    {
        Console.WriteLine(emp);
    }
}

void BuscarEmpleado()
{
    Console.Write("ID a buscar: ");
    string? id = Console.ReadLine();

    try
    {
        Empleado empleado = ObtenerEmpleadoPorId(id ?? string.Empty);
        Console.WriteLine(empleado);
    }
    catch (EmpleadoNoEncontradoException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

void EliminarEmpleado()
{
    Console.Write("ID a eliminar: ");
    string? id = Console.ReadLine();

    try
    {
        Empleado empleado = ObtenerEmpleadoPorId(id ?? string.Empty);
        empleados.Remove(empleado);
        Console.WriteLine("Empleado eliminado correctamente.");
    }
    catch (EmpleadoNoEncontradoException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

Empleado ObtenerEmpleadoPorId(string id)
{
    Empleado? encontrado = empleados.Find(e => e.Id == id);
    if (encontrado is null)
        throw new EmpleadoNoEncontradoException(id);
    return encontrado;
}

string LeerTexto(string mensaje)
{
    string? valor;
    do
    {
        Console.Write(mensaje);
        valor = Console.ReadLine();
    } while (string.IsNullOrWhiteSpace(valor));
    return valor;
}

string LeerId()
{
    string id;
    while (true)
    {
        id = LeerTexto("ID: ");
        if (empleados.Any(e => e.Id == id))
        {
            Console.WriteLine("Ese ID ya existe. Ingrese uno diferente.");
            continue;
        }
        return id;
    }
}

decimal LeerDecimalPositivo(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        string? entrada = Console.ReadLine();
        if (decimal.TryParse(entrada, out decimal valor) && valor > 0)
            return valor;
        Console.WriteLine("Ingrese un valor numérico positivo.");
    }
}
