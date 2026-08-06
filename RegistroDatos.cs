namespace EstructuraDeDatos_2026
{
    public class RegistroDatos
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Valor { get; set; } = string.Empty;

        public RegistroDatos() { }

        public RegistroDatos(int id, string nombre, string valor)
        {
            Id = id;
            Nombre = nombre;
            Valor = valor;
        }

        public override string ToString()
        {
            return $"[ID: {Id}] Nombre: {Nombre} | Valor: {Valor}";
        }
    }
}