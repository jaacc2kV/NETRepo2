namespace InventarioApp.Repositories;

using InventarioApp.Models;

///<sumary>
/// Contrato para almacenamiento de productos.
/// Define las operaciones basicas CRUD.
/// </sumary>

public interface IProductoRepository
{
    /// <summary>
    /// Agrega un producto al repositorio.
    /// </summary>
    void Agregar(Producto producto);

    /// <summary>
    /// Obtiene un producto por su ID.
    /// Retorna NULL si no existe.
    /// </summary>
    Producto? ObtenerPorId(int id);

    /// <summary>
    /// Obtiene todos los productos.
    /// </summary>    
    IEnumerable<Producto> ObtenerTodos();

    /// <summary>
    /// Actualiza un producto existente.
    /// </summary>    
    bool Actualizar(Producto producto);

    /// <summary>
    /// Elimina un producto por su ID.
    /// Retorna TRUE si se eliminó, FALSE si no existe.
    /// </summary>    
    bool Eliminar(int id);

    /// <summary>
    /// Cantidad total de productos en el repositorio.
    /// </summary>    
    int Cantidad {get;}
}