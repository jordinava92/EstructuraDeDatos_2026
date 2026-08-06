using System;

namespace InsertionSortPractica
{
    // Estructura que representa una transacción financiera
    struct Transaccion
    {
        public int Id;            // Identificador único
        public double Monto;      // Importe en moneda local
        public long Timestamp;    // Marca de tiempo en milisegundos (epoch)

        public Transaccion(int id, double monto, long timestamp)
        {
            Id = id;
            Monto = monto;
            Timestamp = timestamp;
        }

        public override string ToString()
        {
            return $"ID: {Id,-4} | Monto: {Monto,10:F2} | Timestamp: {Timestamp}";
        }
    }

    class Program
    {
        // Algoritmo Insertion Sort instrumentado
        static int OrdenarPorInsercion(Transaccion[] arr)
        {
            int contadorDesplazamientos = 0;
            int n = arr.Length;

            for (int i = 1; i < n; i++)
            {
                Transaccion clave = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j].Id > clave.Id)
                {
                    arr[j + 1] = arr[j];
                    contadorDesplazamientos++;
                    j--;
                }
                arr[j + 1] = clave;
            }

            return contadorDesplazamientos;
        }

        static void Main(string[] args)
        {
            try
            {
                // Se crea la bitácora con capacidad para 50 transacciones
                Transaccion[] bitacora = new Transaccion[50];
                Random rng = new Random();

                // Primeros 45 elementos: IDs en orden ascendente (1 a 45)
                for (int i = 0; i < 45; i++)
                {
                    bitacora[i] = new Transaccion(
                        i + 1,
                        Math.Round(rng.NextDouble() * 9999.99 + 0.01, 2),
                        DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - i * 100
                    );
                }

                // Últimos 5 elementos: IDs aleatorios fuera de orden
                int[] idsAleatorios = { 78, 3, 59, 12, 55 };
                for (int i = 0; i < 5; i++)
                {
                    bitacora[45 + i] = new Transaccion(
                        idsAleatorios[i],
                        Math.Round(rng.NextDouble() * 9999.99 + 0.01, 2),
                        DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - (45 + i) * 100
                    );
                }

                Console.WriteLine("=== OPTIMIZADOR DE BITÁCORAS DE TRANSACCIONES ===\n");

                // Ejecución e instrumentación del algoritmo
                int totalDesplazamientos = OrdenarPorInsercion(bitacora);

                Console.WriteLine("Transacciones ordenadas por ID:");
                foreach (var t in bitacora)
                {
                    Console.WriteLine(t);
                }

                Console.WriteLine($"\nTotal de desplazamientos realizados: {totalDesplazamientos}");

                // Cálculo del porcentaje de eficiencia frente al peor caso teórico n(n-1)/2 = 1225
                double peorCaso = (50 * 49) / 2.0;
                double eficiencia = (1.0 - ((double)totalDesplazamientos / peorCaso)) * 100.0;

                Console.WriteLine($"Eficiencia: {eficiencia:F1}% mejor que el peor caso.");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"[ERROR] Desbordamiento de datos: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"[ERROR] Formato de entrada inválido: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Excepción inesperada: {ex.Message}");
            }
        }
    }
}

