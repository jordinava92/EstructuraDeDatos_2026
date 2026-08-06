namespace DataCore.Fase3
{
    public class RegistroDatos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Monto { get; set; }

        public RegistroDatos(int id, string nombre, decimal monto = 0m)
        {
            Id = id;
            Nombre = nombre;
            Monto = monto;
        }
    }
}