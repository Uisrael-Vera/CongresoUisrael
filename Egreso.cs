namespace SistemaContable
{
    // Clase concreta para egresos
    public class Egreso : MovimientoContable
    {
        public override string Tipo => "Egreso";  // Define el tipo como "Egreso"

        // Los egresos no tienen IVA adicional
        public override decimal CalcularTotal()
        {
            return Monto;
        }
    }
}
