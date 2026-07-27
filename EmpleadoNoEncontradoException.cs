using System;

namespace GestionEmpleados
{
    public class EmpleadoNoEncontradoException : Exception
    {
        public EmpleadoNoEncontradoException(string id)
            : base($"No se encontró el empleado con ID: {id}")
        {
        }
    }
}
