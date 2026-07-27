using System;

namespace GestionEmpleados
{
    public class EmpleadoComisionista : Empleado
    {
        private decimal sueldoBase;
        private decimal ventasRealizadas;
        private decimal porcentajeComision;

        public decimal SueldoBase
        {
            get => sueldoBase;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El sueldo base debe ser positivo.");
                sueldoBase = value;
            }
        }

        public decimal VentasRealizadas
        {
            get => ventasRealizadas;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Las ventas realizadas deben ser positivas.");
                ventasRealizadas = value;
            }
        }

        public decimal PorcentajeComision
        {
            get => porcentajeComision;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El porcentaje de comisión debe ser positivo.");
                porcentajeComision = value;
            }
        }

        public EmpleadoComisionista(string nombre, string id, decimal sueldoBase, decimal ventasRealizadas, decimal porcentajeComision)
            : base(nombre, id)
        {
            SueldoBase = sueldoBase;
            VentasRealizadas = ventasRealizadas;
            PorcentajeComision = porcentajeComision;
        }

        public override decimal CalcularSalario()
        {
            // PERSONA B: implementar la fórmula real.
            // Acordado en la Fase 0: sueldoBase + (ventasRealizadas * porcentajeComision)
            return 0;
        }

        public override string ToString()
        {
            return $"[Comisionista] {base.ToString()} | Base: {SueldoBase:C} | Ventas: {VentasRealizadas:C} | Comisión: {PorcentajeComision:P}";
        }
    }
}
