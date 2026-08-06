namespace DataCore.Fase3
{
    /// <summary>
    /// Representa un nodo individual en la lista simplemente enlazada.
    /// Almacena un objeto RegistroDatos y una referencia al siguiente nodo.
    /// </summary>
    public class NodoRegistro
    {
        // El dato que este nodo almacena (Reference Type)
        public RegistroDatos Dato { get; set; }

        // Referencia al siguiente nodo. Es nullable (?) para indicar el fin de la cadena.
        public NodoRegistro? Siguiente { get; set; }

        /// <summary>
        /// Constructor para inicializar un nodo con su información.
        /// </summary>
        /// <param name="dato">Objeto de tipo RegistroDatos a almacenar.</param>
        public NodoRegistro(RegistroDatos dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}