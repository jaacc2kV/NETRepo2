//Console.WriteLine("Hello, World!");

using System.Reflection;

String pruebavariable = "Soy Variable";

Assembly assembly = Assembly.GetExecutingAssembly();
Version? version = assembly.GetName().Version;


Console.WriteLine("=========================================");
Console.WriteLine("     SISTEMA DE GESTIÓN DE INVENTARIO    ");
Console.WriteLine("=========================================");
Console.WriteLine();
Console.WriteLine($"Versión: {version}]");
Console.WriteLine($"Plataforma: {Environment.OSVersion}");      //INTERPOLACION: $"....{variable}"
Console.WriteLine($".NET Versión: {Environment.Version}");
Console.WriteLine();
Console.WriteLine($"Prueba Variable: {pruebavariable}");        //INTERPOLACION: $"....{variable}"
Console.WriteLine("Estructura del proyecto");
Console.WriteLine("Configuración .csproj");
Console.WriteLine("Carpeta src/ creada");
Console.WriteLine("Metadatos configurados");
Console.WriteLine();
Console.WriteLine("Estado: Proyecto inicializado");
