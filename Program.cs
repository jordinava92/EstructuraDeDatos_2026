private static void SubmenuBusqueda()
{
    Console.Clear();
    Console.WriteLine("--- MÓDULO DE BÚSQUEDA ---");
    Console.WriteLine("2.1 Búsqueda Lineal O(n)");
    Console.WriteLine("2.2 Búsqueda Binaria Indexada O(log n)");
    Console.Write("Seleccione una opción: ");

    int subOpcion = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Ingrese el ID a buscar: ");
    int idTarget = int.Parse(Console.ReadLine() ?? "0");

    // Extraer arreglo auxiliar para indexación
    RegistroDatos[] arregloAuxiliar = baseDeDatos.ObtenerComoArreglo();

    RegistroDatos? resultado = null;
    int comparaciones = 0;

    if (subOpcion == 1)
    {
        (resultado, comparaciones) = BusquedaIndexada.BuscarRegistroLineal(arregloAuxiliar, idTarget);
        Console.WriteLine("\n--- RESULTADO DE BÚSQUEDA LINEAL O(n) ---");
    }
    else if (subOpcion == 2)
    {
        // Precondición 1: El arreglo debe estar ordenado para la búsqueda binaria
        Array.Sort(arregloAuxiliar, (a, b) => a.Id.CompareTo(b.Id));
        (resultado, comparaciones) = BusquedaIndexada.BuscarRegistroIndexado(arregloAuxiliar, idTarget);
        Console.WriteLine("\n--- RESULTADO DE BÚSQUEDA BINARIA INDEXADA O(log n) ---");
    }

    if (resultado != null)
    {
        Console.WriteLine($"[ENCONTRADO] ID: {resultado.Id} | Nombre: {resultado.Nombre} | Monto: {resultado.Monto:C}");
    }
    else
    {
        Console.WriteLine($"[NO ENCONTRADO] El ID {idTarget} no existe en la colección.");
    }

    Console.WriteLine($"[MÉTRICA DE RENDIMIENTO] Comparaciones realizadas: {comparaciones}");
    PausarPantalla();
}