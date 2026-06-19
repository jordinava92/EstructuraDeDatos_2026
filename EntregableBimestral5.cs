// 1. TUS TOP-LEVEL STATEMENTS (El código que ya tienes)
var arbol = new ArbolBinarioBusqueda();

arbol.Insertar(4);
arbol.Insertar(2);
arbol.Insertar(6);
arbol.Insertar(1);
arbol.Insertar(3);
arbol.Insertar(5);
arbol.Insertar(7);

int idABuscar = 7;
Nodo? resultado = arbol.BuscarNodo(idABuscar);

if (resultado != null)
{
    Console.WriteLine($"¡Nodo con ID {resultado.Id} encontrado con éxito!");
}
else
{
    Console.WriteLine($"El nodo con ID {idABuscar} no existe en el árbol.");
}


// 2. LAS CLASES DEBEN IR AQUÍ ABAJO, AL FINAL DEL ARCHIVO

public class Nodo
{
    public int Id { get; set; }
    public Nodo? Izquierdo { get; set; }
    public Nodo? Derecho { get; set; }

    public Nodo(int id)
    {
        Id = id;
    }
}

public class ArbolBinarioBusqueda
{
    public Nodo? Raiz { get; private set; }

    public Nodo? BuscarNodo(int idTarget)
    {
        return BuscarRecursivo(Raiz, idTarget);
    }

    private Nodo? BuscarRecursivo(Nodo? nodoActual, int idTarget) => nodoActual switch
    {
        null => null,
        { Id: var id } when id == idTarget => nodoActual,
        { Id: var id } when idTarget < id => BuscarRecursivo(nodoActual.Izquierdo, idTarget),
        _ => BuscarRecursivo(nodoActual.Derecho, idTarget)
    };

    public void Insertar(int id)
    {
        Raiz = InsertarRecursivo(Raiz, id);
    }

    private Nodo InsertarRecursivo(Nodo? actual, int id)
    {
        if (actual == null) return new Nodo(id);

        if (id < actual.Id)
            actual.Izquierdo = InsertarRecursivo(actual.Izquierdo, id);
        else if (id > actual.Id)
            actual.Derecho = InsertarRecursivo(actual.Derecho, id);

        return actual;
    }
}