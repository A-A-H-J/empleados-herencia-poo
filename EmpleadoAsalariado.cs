using System;

namespace GestionEmpleados
{
    public class EmpleadoAsalariado : Empleado
    {
        private decimal sueldoMensual;

        public decimal SueldoMensual
        {
            get => sueldoMensual;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El sueldo mensual debe ser positivo.");
                sueldoMensual = value;
            }
        }

        public EmpleadoAsalariado(string nombre, string id, decimal sueldoMensual)
            : base(nombre, id)
        {
            SueldoMensual = sueldoMensual;
        }

        public override decimal CalcularSalario()
        {
            // PERSONA B: implementar la fórmula real.
            // Acordado en la Fase 0: el sueldo mensual es fijo, se retorna tal cual.
            return 0;
        }

        public override string ToString()
        {
            return $"[Asalariado] {base.ToString()} | Sueldo fijo: {SueldoMensual:C}";
        }
    }
}
