using System;

namespace SistemaContable
{
    // Clase abstracta que representa un movimiento contable
    public abstract class MovimientoContable
    {
        public int Numero { get; set; }              // Número único de transacción
        public string Descripcion { get; set; }      // Descripción del movimiento
        public decimal Monto { get; set; }           // Valor monetario de la transacción
        public DateTime Fecha { get; set; }          // Fecha del movimiento
        public bool AplicaIVA { get; set; }          // Indica si se aplica IVA

        public abstract string Tipo { get; }         // Propiedad que indica si es "Ingreso" o "Egreso"
        public abstract decimal CalcularTotal();     // Método abstracto que calcula el total (con IVA si aplica)

        // Método común para mostrar información básica del movimiento
        public virtual void Mostrar()
        {
            Console.WriteLine($"#{Numero} | {Fecha.ToShortDateString()} | {Tipo} | {Descripcion} | Monto: {Monto:C2} | IVA: {(AplicaIVA ? "Sí" : "No")}");
        }
    }
}
