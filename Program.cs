using System;

namespace SistemaContable
{
    class Program
    {
        static void Main(string[] args)
        {
            LibroDiario libro = new LibroDiario(); // Crear instancia del libro contable
            int opcion;

            // Menú interactivo
            do
            {
                Console.WriteLine("=== Sistema de Gestión Contable ===");
                Console.WriteLine("1. Agregar Transacción");
                Console.WriteLine("2. Ver Libro Diario");
                Console.WriteLine("3. Ver Resumen Financiero");
                Console.WriteLine("4. Reporte");
                Console.WriteLine("5. Exportar Reporte a JSON");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                string entrada = Console.ReadLine();
                int.TryParse(entrada, out opcion); // Validación básica

                switch (opcion)
                {
                    case 1:
                        {
                            libro.AgregarTransaccion();
                            break;
                        }
                    case 2:
                        {
                            libro.VerTransacciones();
                            break;
                        }
                    case 3:
                        {
                            libro.VerResumen();
                            break;
                        }
                    case 4:
                        {
                            Reporte reporte = new Reporte();
                            var transacciones = libro.ObtenerTransacciones();
                            reporte.MostrarEnConsola(transacciones);
                            break;
                        }   
                    case 5:
                        {
                            Reporte reporte = new Reporte();
                            string ruta = "reporte_transacciones.json";
                            reporte.ExportarAJson(libro.ObtenerTransacciones(), ruta);
                            break;
                        }

                    case 0:
                        {
                            Console.WriteLine("Saliendo del sistema...");
                            break;
                        }
                    default:
                        Console.WriteLine("Opción inválida.\n");
                        break;
                }

            } while (opcion != 0); // El bucle termina al seleccionar "0"
        }
    }
}
