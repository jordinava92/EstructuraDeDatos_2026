using System;

namespace DataCoreEngine
{
    /// <summary>
    /// Struct inmutable que representa la unidad fundamental de datos.
    /// Reside en el Stack del hilo de ejecución.
    /// </summary>
    public readonly struct RegistroDatos
    {
        public int Id { get; }
        public string Nombre { get; }
        public double Valor { get; }

        public RegistroDatos(int id, string nombre, double valor)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "El ID debe ser mayor que cero.");
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentNullException(nameof(nombre), "El nombre no puede ser vacío.");
            }

            Id = id;
            Nombre = nombre.Trim();
            Valor = valor;
        }

        public override string ToString()
        {
            return $"ID: {Id,-6} | Nombre: {Nombre,-15} | Valor: {Valor,8:F2}";
        }
    }
}