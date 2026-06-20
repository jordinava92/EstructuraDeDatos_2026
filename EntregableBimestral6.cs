using System;

namespace RetoMemoria
{
    // --- MÓDULO 3: Clase Alumno ---
    public class Alumno
    {
        public string Nombre { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ==========================================
            // PRUEBA MÓDULO 1: Intercambiar con 'ref'
            // ==========================================
            Console.WriteLine("--- Módulo 1: Intercambiar con ref ---");
            int x = 5;
            int y = 10;
            Console.WriteLine($"Antes del intercambio -> x: {x}, y: {y}");
            
            Intercambiar(ref x, ref y);
            Console.WriteLine($"Después del intercambio -> x: {x}, y: {y}\n");


            // ==========================================
            // PRUEBA MÓDULO 2: CalcularYValidar con 'out'
            // ==========================================
            Console.WriteLine("--- Módulo 2: Calcular y Validar con out ---");
            int dividendo = 23;
            int divisor = 4;
            
            int cociente = CalcularYValidar(dividendo, divisor, out int residuo);
            Console.WriteLine($"Dividendo: {dividendo}, Divisor: {divisor}");
            Console.WriteLine($"Cociente (retorno): {cociente}");
            Console.WriteLine($"Residuo (parámetro out): {residuo}\n");


            // ==========================================
            // PRUEBA MÓDULO 3: Demostración de Referencias
            // ==========================================
            Console.WriteLine("--- Módulo 3: Referencias de Objetos ---");
            
            // Instancia original
            Alumno alumno1 = new Alumno { Nombre = "Dany" };
            Console.WriteLine($"alumno1 (original): {alumno1.Nombre}");

            // Asignación de la referencia a una segunda variable
            Alumno alumno2 = alumno1;
            Console.WriteLine($"alumno2 (copia de referencia): {alumno2.Nombre}");

            // Cambiando el nombre a través de la segunda variable
            alumno2.Nombre = "3Treum";
            Console.WriteLine("\n[!] Modificando alumno2.Nombre a '3Treum'...");
            
            // Verificación del comportamiento
            Console.WriteLine($"alumno1 (luego del cambio): {alumno1.Nombre}");
            Console.WriteLine($"alumno2 (luego del cambio): {alumno2.Nombre}");
            
            Console.WriteLine("\nExplicación: Ambas variables apuntan a la misma dirección de memoria en el Heap.");
        }

        // --- MÓDULO 1: Intercambio sin variable auxiliar (usando aritmética) ---
        public static void Intercambiar(ref int a, ref int b)
        {
            // Al usar 'ref' operamos directamente sobre las variables originales.
            // Intercambio mediante sumas y restas para evitar la variable temporal:
            a = a + b; // 'a' ahora contiene la suma de ambos
            b = a - b; // 'b' obtiene el valor original de 'a'
            a = a - b; // 'a' obtiene el valor original de 'b'
        }

        // --- MÓDULO 2: Retorno múltiple usando el modificador 'out' ---
        public static int CalcularYValidar(int dividendo, int divisor, out int residuo)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("El divisor no puede ser cero.");
            }

            // El compilador exige que 'residuo' sea asignado obligatoriamente antes de salir
            residuo = dividendo % divisor; 
            
            return dividendo / divisor;
        }
    }
}