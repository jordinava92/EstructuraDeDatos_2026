using System;

namespace EstructuraDeDatos_2026
{
    public struct RegistroDatos
    {
        public int Id { get; }
        public string HashValidacion { get; }
        public double PesoBytes { get; }

        public RegistroDatos(int id, string hashValidacion, double pesoBytes)
        {
            if (id <= 0)
                throw new ArgumentException("El Id debe ser un entero positivo mayor que cero.", nameof(id));

            if (string.IsNullOrEmpty(hashValidacion))
                throw new ArgumentNullException(nameof(hashValidacion), "HashValidacion no puede ser null ni una cadena vacía.");

            if (pesoBytes <= 0.0)
                throw new ArgumentOutOfRangeException(nameof(pesoBytes), "PesoBytes debe ser un valor numérico positivo mayor que cero.");

            Id = id;
            HashValidacion = hashValidacion;
            PesoBytes = pesoBytes;
        }

        public override string ToString() => $"[Id={Id}, Hash={HashValidacion[..8]}..., Peso={PesoBytes:F2}B]";
    }
}