using System;

namespace GestionEmpleados
{
    public class EmpleadoPorHora : Empleado
    {
        private decimal sueldoPorHora;
        private decimal horasTrabajadas;

        public decimal SueldoPorHora
        {
            get => sueldoPorHora;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("El sueldo por hora debe ser positivo.");
                sueldoPorHora = value;
            }
        }

        public decimal HorasTrabajadas
        {
            get => horasTrabajadas;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Las horas trabajadas deben ser positivas.");
                horasTrabajadas = value;
            }
        }

        public EmpleadoPorHora(string nombre, string id, decimal sueldoPorHora, decimal horasTrabajadas)
            : base(nombre, id)
        {
            SueldoPorHora = sueldoPorHora;
            HorasTrabajadas = horasTrabajadas;
        }

        public override decimal CalcularSalario()
        {
            return SueldoPorHora * HorasTrabajadas;
        }

        public override string ToString()
        {
            return $"[Por Hora] {base.ToString()} | Horas trabajadas: {HorasTrabajadas} | Tarifa/hora: {SueldoPorHora:C}";
        }
    }
}
