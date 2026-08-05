using System;

namespace AlgoritmosBusqueda
{
    /// <summary>
    /// Representa un estudiante universitario dentro del sistema de control escolar.
    /// </summary>
    public class Estudiante : IComparable<Estudiante>
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; }

        public Estudiante(int matricula, string nombre)
        {
            Matricula = matricula;
            Nombre = nombre;
        }

        /// <summary>
        /// Permite comparar dos objetos Estudiante en función de su Matrícula.
        /// </summary>
        public int CompareTo(Estudiante otro)
        {
            if (otro == null) return 1;
            return Matricula.CompareTo(otro.Matricula);
        }

        public override string ToString()
        {
            return $"[Matrícula: {Matricula} | Nombre: {Nombre}]";
        }
    }
}