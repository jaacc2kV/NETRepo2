//Console.WriteLine("Hello, World!");

using System.Reflection;

//String pruebavariable = "Soy Variable";

Assembly assembly = Assembly.GetExecutingAssembly();
Version? version = assembly.GetName().Version;

//Manejando argumentos
if(args.Length > 0)
{
    switch (args[0].ToLower())
    {
        case "--help":
            MostrarAyuda();
            Environment.Exit(0);
            break;
        case "--version":
            Console.WriteLine($"InventarioApp v[{version}]");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine($"Error: Comando desconocido '{args[0]}");
            Console.WriteLine("use --help para ver los comandos disponnibles.");
            Environment.Exit(2);
            break;
    }
}

//------------
int cantidadProductos = 0;
decimal valorTotalDelInventario = 0.00m;
bool sistemaActivo = true;
string nombreSistema = "Sistema de Gestión de Inventario";
decimal precio = 19.99m;



Console.WriteLine("Estado del Sistema");
Console.WriteLine($" Nombre: {nombreSistema}");
Console.WriteLine($" Productos registrados: {cantidadProductos}");
Console.WriteLine($" Valor total del inventario: ${valorTotalDelInventario:N2}");
Console.WriteLine($" Sistema activo: {(sistemaActivo ? "Sí" : "No")}");

Console.Write("Ingrese una cantidad: ");
string? entradaCantidad = Console.ReadLine();
string? comando;

///////////////////////////
// Loop de NULLABILIDAD
///////////////////////////

while (sistemaActivo)
{
    Console.Write("Inventario: ");
    string? entrada3 = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(entrada3))
    {
        entrada3 = "salir";
        comando = "salir";
        //Console.WriteLine("Soy NULO");
    }
    else
    {
        comando = entrada3?.Trim().ToLower();
    }


   // string comando = entrada3?.Trim().ToLower() ?? "salir";

    //Console.WriteLine("Soy NULO 2");

    //Aplicamos el manejador seguro
    //string comando = entrada3?.Trim().ToLower() ?? "salir";
    
    /*if (comando is null)
    {
        Console.WriteLine("Soy NULO");
    }
    */
    switch(comando)
    {
        case "salir":
            sistemaActivo = false;
            Console.WriteLine("Hasta luego");
            break;
        case "listar":
            Console.WriteLine($"Productos de inventario: {cantidadProductos}");
            break;
        case "":
            break;
        default:
            Console.WriteLine($"Comando '{comando}' no reconocido.");
            Console.WriteLine("Comandos disponibles: listar, agregar, buscar, salir");
            break;
    }
    
}

//Conversion segura Tryparse
if (int.TryParse(entradaCantidad, out int cantidad))
{
    Console.Write($"Cantidad valida: {cantidad}\n");
    cantidadProductos = cantidad;
}
else
{
    Console.WriteLine("Error: debe ingresar un número entero");
}

Console.Write("Ingrese un precio: ");
string? entradaPrecio = Console.ReadLine();

//Conversión segura TryParse
if (decimal.TryParse(entradaPrecio, out decimal precio2))
{
    Console.Write($"Precio valido: {precio2:N2}\n");
    valorTotalDelInventario = cantidadProductos * precio2;
    Console.WriteLine($"Valor total del inventario actualizado: ${valorTotalDelInventario:N2}");
}
else
{
    Console.WriteLine("Error: debe ingresar un número decimal");
}

//------------
MostrarBanner();

Console.Write("Ingrese un valor: ");
string? entrada2 = Console.ReadLine();
int? longitud = entrada2.Length;

Console.WriteLine($"Longitud: {longitud ?? 0:N2}");

//Modo interactivo si no hay argumentos
Console.Write("Ingrese un comando (o 'salir' para terminar): ");
string? entrada = Console.ReadLine();

//validando lo ingresado por el usuario
if (string.IsNullOrWhiteSpace(entrada) || entrada.ToLower() == "salir")
{
    Console.WriteLine("Hasta luego");
    Environment.Exit(0);
}

/*
Console.WriteLine($"Prueba Variable: {pruebavariable}");        //INTERPOLACION: $"....{variable}"
Console.WriteLine("Estructura del proyecto");
Console.WriteLine("     InventarioApp");
Console.WriteLine("     |-- Program.cs");
Console.WriteLine("     |-- InventarioApp.csproj");
Console.WriteLine("     |--gitignore");
Console.WriteLine("     |--README.md");
Console.WriteLine("     |--src/");
Console.WriteLine("         |--Models/ (Próxima clase)");
Console.WriteLine("Configuración .csproj");
Console.WriteLine("Carpeta src/ creada");
Console.WriteLine("Metadatos configurados");
Console.WriteLine();
Console.WriteLine("Estado: Proyecto inicializado");
*/

void MostrarBanner()
{
    Console.WriteLine("=========================================");
    Console.WriteLine("     SISTEMA DE GESTIÓN DE INVENTARIO    ");
    Console.WriteLine("=========================================");
    Console.WriteLine();
    Console.WriteLine($"Versión: {version}]");
    Console.WriteLine($"Plataforma: {Environment.OSVersion}");      //INTERPOLACION: $"....{variable}"
    Console.WriteLine($".NET Versión: {Environment.Version}");
    Console.WriteLine();
}

void MostrarAyuda()
{
    Console.WriteLine("USO: InventarioApp [comando] [opciones]");
    Console.WriteLine();
    Console.WriteLine("COMANDOS");
    Console.WriteLine("  --help, -h     Muestra esta ayuda");
    Console.WriteLine("  --version, v   Muestra la versión");
    Console.WriteLine();
    Console.WriteLine("EJEMPLOS:");
    Console.WriteLine("  dotnet run -- --help");
    Console.WriteLine("  dotnet run -- --version");
}