using InventarioApp.Factories;
using InventarioApp.Repositories;
using InventarioApp.Models;
using InventarioApp.Infraestructure;

//Consumiendo
Console.WriteLine("=== Prueba Integración JSON ===");

var almacenamiento = new JsonInventarioStorage();

var productos = new List<Producto>
{
    new Producto
    {
        Id = 1, 
        Nombre = "Laptop", 
        Precio = 999.99m,
        Cantidad = 10, 
        Categoria = CategoriaProducto.Electronica, 
        Estado = EstadoProducto.Activo
    }, 
    new Producto
    {
        Id = 2, 
        Nombre = "Camiseta", 
        Precio = 19.99m,
        Cantidad = 50, 
        Categoria = CategoriaProducto.Ropa,
        Estado = EstadoProducto.Activo
    }
};

string ruta = "inventario_test.json";

almacenamiento.CrearBackup(ruta);
almacenamiento.Guardar(productos, ruta);

Console.WriteLine("Inventario guardado correctamente");

List<Producto> productosCargados = almacenamiento.Cargar(ruta);

Console.WriteLine("Inventario cargado correctamente");

foreach(Producto p in productosCargados)
{
    Console.WriteLine($"ID: {p.Id}, Nombre:{p.Nombre}, Precio: {p.Precio}, Cantidad: {p.Cantidad}, Categoria: {p.Categoria}, Estado: {p.Estado}");
}
 


//==================================EJERCICIO 2
/*
Console.WriteLine("=== InventarioApp ===");

var fileManager = new Filemanager();    //creando una INSTANCIA (Objeto) de la clase FILEMANAGER
string contenido = "Inventario actualizado";
fileManager.Escribir("inventario.txt", contenido);

string leerContenido = fileManager.Leer("inventario.txt");
Console.WriteLine(contenido);



//Crer repositorio en Memoria usando la fabrica (factory)
InMemoryProductoRepository repositorio = new InMemoryProductoRepository();      //creando una INSTANCIA (Objeto) de la clase INMEMORYPRODUCTOREPOSITORY

Producto laptop = ProductoFactory.Crear("Laptop Dell XPS 13", 1200, 5, CategoriaProducto.Electronica);
Producto mouse = ProductoFactory.Crear("Mouse Logitech MX Master", 99, 20, CategoriaProducto.Electronica);
Producto teclado = ProductoFactory.Crear("Teclado Mecánico", 150, 3, CategoriaProducto.Electronica);
Producto silla = ProductoFactory.Crear("Silla Ergonómica Herman Miller", 500, 8, CategoriaProducto.Muebles);
Producto escritorio = ProductoFactory.Crear("Escritorio Stand-up", 300, 2, CategoriaProducto.Muebles);

//Agregando cada producto al REPOSITORIO (en Memoria)
repositorio.Agregar(laptop);
repositorio.Agregar(mouse);
repositorio.Agregar(teclado);
repositorio.Agregar(silla);
repositorio.Agregar(escritorio);

Console.WriteLine($"Productos agregados: {repositorio.Cantidad}\n");

//Consultas basicas LINQ
IEnumerable<Producto> electronicos = repositorio.BuscarPorCategoria(CategoriaProducto.Electronica);
Console.WriteLine("Productos de electrónica");

foreach(Producto producto in electronicos)
{
    Console.WriteLine($" {producto.Nombre}: ${producto.Precio}");
}
Console.WriteLine("\n Productos con 'mouse' en el nombre: ");

IEnumerable<Producto> conMouse = repositorio.BuscarPorNombre("mouse");

foreach(Producto producto in conMouse)
{
    Console.WriteLine($" {producto.Nombre}");
}

//var totalInventario = repositorio.ObtenerTodos().Sum(p => p.ValorTotal);
var nombres = repositorio.ObtenerNombres();
Console.WriteLine($"\n Todos los nombres {string.Join(",", nombres)}");

var hayStockBajo = repositorio.HayStockBajo();
Console.WriteLine($"\n Hay Stock Bajo: {hayStockBajo}");
*/

//==================================EJERCICIO 1
/* VA
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


*/

/* VA
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

*/

/* VA
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
*/

/* NO VA
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

/* VA
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
*/