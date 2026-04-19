namespace InventarioApp.Infraestructure;

public class Filemanager
{
    //Método para ESCRIBIR hasta medianos volumenes de datos
    public void Escribir(string ruta, string contenido)
    {
        File.WriteAllText(ruta, contenido);
    }

    //Método para LEER hasta medianos volumenes de datos
    public string Leer(string ruta)
    {
        return File.ReadAllText(ruta);
    }

    public void Agregar(string ruta, string contenido)
    {
        File.AppendAllText(ruta, contenido);
    }

    public bool Existe(string ruta)
    {
        return File.Exists(ruta);
    }

    public void Eliminar(string ruta)
    {
        File.Delete(ruta);
    }

    //Método para LEER grandes volumenes de datos
    public IEnumerable<string> LeerLineas(string ruta)      //VALIDO ->public string[] LeerLineas(string ruta)
    {
        return File.ReadAllLines(ruta);
    }

    //Método para ESCRIBIR grandes volumenes de datos
    public void EscribirLineas(string ruta, IEnumerable<string> lineas)
    {
        File.WriteAllLines(ruta, lineas);
    }

    public void CrearDirectorio(string ruta)
    {
        Directory.CreateDirectory(ruta);
    }

    //Obtener archivos que coincidan con el PATRON, en ese caso, traerá TODOS (*)
    public string[] ObtenerArchivos(string directorio, string patron = "*")
    {
        return Directory.GetFiles(directorio, patron);
    }
    
}


