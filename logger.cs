using System;
using System.IO;

namespace DataCore
{
    public static class Logger
    {
        private static readonly string RutaLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "errores_datacore.log");

        /// <summary>
        /// Escribe el detalle de una excepción en un archivo persistente sin interrumpir el flujo.
        /// </summary>
        public static void RegistrarExcepcion(Exception ex, string operacionContexto)
        {
            try
            {
                string mensajeLog = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR en {operacionContexto}:\n" +
                                   $"Tipo: {ex.GetType().Name}\n" +
                                   $"Mensaje: {ex.Message}\n" +
                                   $"Stack Trace:\n{ex.StackTrace}\n" +
                                   new string('-', 60) + "\n";

                File.AppendAllText(RutaLog, mensajeLog);
            }
            catch (Exception exLog)
            {
                // Fallback en consola estándar si falla el disco/escritura
                Console.Error.WriteLine($"[FALLO CRÍTICO DE LOGGING] No se pudo escribir en el log: {exLog.Message}");
            }
        }
    }
}