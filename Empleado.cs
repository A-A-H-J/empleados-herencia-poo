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

        /// <summary>
        /// Calcula el salario del empleado. Cada clase derivada define su
        /// propia fórmula.
        /// PERSONA B: aquí va la lógica real en cada subclase, no en esta clase.
        /// </summary>
        public abstract decimal CalcularSalario();

        /// <summary>
        /// Representación en texto del empleado. Las subclases la sobrescriben
        /// para agregar sus datos específicos.
        /// </summary>
        public override string ToString()
        {
            return $"ID: {Id} | Nombre: {Nombre} | Salario: {CalcularSalario():C}";
        }
    }
}
