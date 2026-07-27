using System;

namespace GestionEmpleados
{
    public abstract class Empleado
    {
        private string nombre;
        private string id;

        public string Nombre
        {
            get => nombre;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre no puede estar vacío.");
                nombre = value;
            }
        }

        public string Id
        {
            get => id;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El ID no puede estar vacío.");
                id = value;
            }
        }

        protected Empleado(string nombre, string id)
        {
            Nombre = nombre;
            Id = id;
        }

        public abstract decimal CalcularSalario();

        public override string ToString()
        {
            return $"ID: {Id} | Nombre: {Nombre} | Salario: {CalcularSalario():C}";
        }
    }
}
