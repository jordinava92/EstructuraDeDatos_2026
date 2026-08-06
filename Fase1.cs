using System;
using System.Diagnostics;

namespace DataCore
{
    /// <summary>
    /// Representa un registro de datos inmutable utilizado por el motor DataCore.
    /// </summary>
    public readonly struct RegistroDatos : IEquatable<RegistroDatos>
    {
        public int Id { get; }
        public long HashValidacion { get; }
        public int PesoBytes { get; }

        /// <summary>
        /// Constructor primario con validación de contrato.
        /// </summary>
        public RegistroDatos(int id, long hashValidacion, int pesoBytes)
        {
            // Contrato de integridad: el peso en bytes debe ser estrictamente mayor a 0.
            if (pesoBytes <= 0)
            {
                throw new ArgumentException(
                    "PesoBytes debe ser mayor a 0. Un registro no puede tener tamaño nulo o negativo.",
                    nameof(pesoBytes));
            }

            Id = id;
            HashValidacion = hashValidacion;
            PesoBytes = pesoBytes;
        }

        public bool Equals(RegistroDatos other)
        {
            return Id == other.Id && HashValidacion == other.HashValidacion && PesoBytes == other.PesoBytes;
        }

        public override bool Equals(object? obj)
        {
            return obj is RegistroDatos other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, HashValidacion, PesoBytes);
        }

        public static bool operator ==(RegistroDatos left, RegistroDatos right) => left.Equals(right);
        public static bool operator !=(RegistroDatos left, RegistroDatos right) => !left.Equals(right);

        public override string ToString()
        {
            return $"Id: {Id,4} | Hash: {HashValidacion,20} | Peso: {PesoBytes} bytes";
        }
    }

    class Program
    {
        /// <summary>
        /// Ordena un arreglo de RegistroDatos en orden ascendente por Id utilizando Selection Sort.
        /// </summary>
        static void OrdenarPorSeleccion(RegistroDatos[] arr)
        {
            int comparaciones = 0;
            int intercambios = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int indiceMinimo = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    comparaciones++;
                    if (arr[j].Id < arr[indiceMinimo].Id)
                    {
                        indiceMinimo = j;
                    }
                }

                if (indiceMinimo != i)
                {
                    // Intercambio mediante la sintaxis moderna de tuplas de C# 7.0+
                    (arr[i], arr[indiceMinimo]) = (arr[indiceMinimo], arr[i]);
                    intercambios++;
                }
            }

            Console.WriteLine($"\n--- MÉTRICAS DE EJECUCIÓN ---");
            Console.WriteLine($"Comparaciones realizadas : {comparaciones}");
            Console.WriteLine($"Intercambios reales     : {intercambios}");
        }

        static void Main(string[] args)
        {
            var rng = new Random();
            var arreglo = new RegistroDatos[40];

            // Generación de 40 registros aleatorios con try-catch
            try
            {
                for (int i = 0; i < arreglo.Length; i++)
                {
                    arreglo[i] = new RegistroDatos(
                        id: rng.Next(1, 1001),
                        hashValidacion: rng.NextInt64(),
                        pesoBytes: rng.Next(10, 5001)
                    );
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error al crear registro: {ex.Message}");
                return;
            }

            // Impresión del estado inicial
            Console.WriteLine("=== ESTADO INICIAL ===");
            foreach (var r in arreglo)
            {
                Console.WriteLine(r.ToString());
            }

            // Algoritmo de Ordenamiento
            OrdenarPorSeleccion(arreglo);

            // Impresión del estado final ordenado
            Console.WriteLine("\n=== ESTADO FINAL ORDENADO ===");
            foreach (var r in arreglo)
            {
                Console.WriteLine(r.ToString());
            }
        }
    }
}