using System;

namespace GestionEmpleados
{
    /// <summary>
    /// Se lanza cuando se intenta buscar o eliminar un empleado cuyo ID
    /// no existe en la lista.
    /// PERSONA C: captúrala con try-catch en Buscar() y Eliminar(),
    /// mostrando ex.Message sin que el programa colapse.
    /// </summary>
    public class EmpleadoNoEncontradoException : Exception
    {
        public EmpleadoNoEncontradoException(string id)
            : base($"No se encontró el empleado con ID: {id}")
        {
        }
    }
}
