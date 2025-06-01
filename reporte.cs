using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SistemaContable
{
    public class Reporte
    {
        public void ExportarAJson(List<MovimientoContable> transacciones, string rutaArchivo) //Este metodo permite Gestionar la exportacion de la informacion de la lista en formato JSON
        {
            var json = JsonConvert.SerializeObject(transacciones, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            File.WriteAllText(rutaArchivo, json);
            Console.WriteLine($"\n Reporte exportado exitosamente a: {rutaArchivo}\n");
        }
        
         public void MostrarEnConsola(List<MovimientoContable> transacciones)
        {
            Console.WriteLine("\n=== Reporte de Transacciones ===");

            if (transacciones == null || transacciones.Count == 0)
            {
                Console.WriteLine("No hay transacciones registradas.\n");
                return;
            }

            // Encabezados
            Console.WriteLine(new string('-', 80));
            Console.WriteLine($"{"#", -5} {"Fecha", -12} {"Tipo", -10} {"Descripción", -30} {"Monto", 12} {"IVA", 5}");
            Console.WriteLine(new string('-', 80));

            // Detalles
            foreach (var t in transacciones)
            {
                string descripcion = t.Descripcion?.Length > 28 ? t.Descripcion.Substring(0, 27) + "…" : t.Descripcion;
                Console.WriteLine($"{t.Numero, -5} {t.Fecha.ToShortDateString(), -12} {t.Tipo, -10} {descripcion, -30} {t.Monto,12:C2} {(t.AplicaIVA ? "Sí" : "No"),5}");
            }

            Console.WriteLine(new string('-', 80));
            Console.WriteLine();
        }
    }
}