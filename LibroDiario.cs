using System;
using System.Collections.Generic;
using System.Globalization;

namespace SistemaContable
{
    public class LibroDiario
    {
        private List<MovimientoContable> transacciones = new(); // Lista que almacena todas las transacciones
        private int contador = 1; // Número consecutivo para las transacciones

        // Método para ingresar una nueva transacción
        public void AgregarTransaccion()
        {
            Console.WriteLine("\n--- Nueva Transacción ---");

            MovimientoContable transaccion;

            // Pedir al usuario el tipo de transacción
            Console.Write("¿Es ingreso (I) o egreso (E)? ");
            string tipo = Console.ReadLine().Trim().ToUpper();

            // Crear la instancia correspondiente
            if (tipo == "I")
                transaccion = new Ingreso();
            else if (tipo == "E")
                transaccion = new Egreso();
            else
            {
                Console.WriteLine("Tipo inválido. Debe ser I o E.");
                return;
            }

            transaccion.Numero = contador++; // Asignar número único

            // Solicitar descripción del movimiento
            Console.Write("Descripción: ");
            transaccion.Descripcion = Console.ReadLine();

            // Solicitar el monto, validando la entrada
            Console.Write("Monto: ");
            decimal monto;
            while (!decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.InvariantCulture, out monto))
            {
                Console.Write("Ingrese un número válido: ");
            }
            transaccion.Monto = monto;

            // Consultar si aplica IVA
            Console.Write("¿Aplica IVA? (s/n): ");
            string ivaInput = Console.ReadLine().Trim().ToLower();
            transaccion.AplicaIVA = ivaInput == "s";

            transaccion.Fecha = DateTime.Now; // Asignar fecha actual

            transacciones.Add(transaccion); // Agregar a la lista
            Console.WriteLine("✅ Transacción registrada con éxito.\n");
        }

        // Mostrar todas las transacciones registradas
        public void VerTransacciones()
        {
            Console.WriteLine("\n--- Libro Diario ---");
            if (transacciones.Count == 0)
            {
                Console.WriteLine("No hay transacciones registradas.\n");
                return;
            }

            foreach (var t in transacciones)
            {
                t.Mostrar(); // Mostrar cada transacción
            }

            Console.WriteLine();
        }

        // Mostrar resumen financiero (ingresos, egresos, IVA, balance)
        public void VerResumen()
        {
            Console.WriteLine("\n--- Resumen Financiero ---");

            decimal totalIngresos = 0;
            decimal totalEgresos = 0;
            decimal ivaTotal = 0;

            foreach (var t in transacciones)
            {
                if (t is Ingreso)
                {
                    totalIngresos += t.CalcularTotal();

                    if (t.AplicaIVA)
                        ivaTotal += t.Monto * 0.15m;
                }
                else if (t is Egreso)
                {
                    totalEgresos += t.Monto;
                }
            }

            decimal balance = totalIngresos - totalEgresos;

            Console.WriteLine($"Total Ingresos: {totalIngresos:C2}");
            Console.WriteLine($"Total Egresos:  {totalEgresos:C2}");
            Console.WriteLine($"IVA Calculado:  {ivaTotal:C2}");
            Console.WriteLine($"Balance Neto:   {balance:C2}\n");
        }

        public List<MovimientoContable> ObtenerTransacciones() // Metodo para obtener los datos de las transacciones que se guarda en al lista
        {
            return transacciones;
        }
    }
}
