using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=====================================================================");
        Console.WriteLine("            ENTREGABLE 10: PASO POR VALOR VS PASO POR REFERENCIA     ");
        Console.WriteLine("=====================================================================");

        // 1. Ciudad de México
        CoordenadaGPS c1 = new CoordenadaGPS(19.4326, -99.1332);
        
        // 2. Copia por valor en el Stack (Efecto de ser un 'struct')
        Console.WriteLine("\n[Acción]: Copiando c1 en c2...");
        CoordenadaGPS c2 = c1;
        
        // 3. Reasignamos c2 -> Berlín
        Console.WriteLine("[Acción]: Reasignando c2 a las coordenadas de Berlín...");
        c2 = new CoordenadaGPS(52.5200, 13.4050);
        
        // 4. Imprimimos ambas para demostrar la independencia de memoria
        Console.WriteLine("\n--- c1 (Original) ---");
        c1.ImprimirUbicacion();
        
        Console.WriteLine("--- c2 (Modificada) ---");
        c2.ImprimirUbicacion();

        Console.WriteLine("\n=====================================================================");
        Console.WriteLine("ANÁLISIS DE MEMORIA:");
        Console.WriteLine("Al definir 'CoordenadaGPS' como un STRUCT (Value Type), c2 nace como una");
        Console.WriteLine("copia idéntica pero INDEPENDIENTE en el Stack. Modificar c2 NO afecta a c1.");
    }
}

// =====================================================================
// DEFINICIÓN DEL TIPO: STRUCT (Para cumplir con la teoría del Stack)
// =====================================================================
public struct CoordenadaGPS
{
    public double Latitud { get; set; }
    public double Longitud { get; set; }

    // Constructor para inicializar los datos
    public CoordenadaGPS(double latitud, double longitud)
    {
        Latitud = latitud;
        Longitud = longitud;
    }

    // Método para imprimir en consola
    public void ImprimirUbicacion()
    {
        Console.WriteLine($"Ubicación: Latitud {Latitud}, Longitud {Longitud}");
    }
}