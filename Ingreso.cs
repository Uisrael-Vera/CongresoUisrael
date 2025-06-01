namespace SistemaContable
{
    // Clase concreta para ingresos
    public class Ingreso : MovimientoContable
    {
        public override string Tipo => "Ingreso";  // Define el tipo como "Ingreso"

        // Si aplica IVA, lo suma al monto total
        public override decimal CalcularTotal()
        {
            return AplicaIVA ? Monto * 1.15m : Monto;
        }
    }
}
