using InventarioApp.Models;

namespace InventarioApp.Repositories;

public class InMemoryProductoRepository : IProductoRepository
{
    private readonly List<Producto> _productos = new List<Producto>();

    private int _proximoId = 1;

    public void Agregar(Producto producto)
    {
        producto.Id = _proximoId;
        _productos.Add(producto);
    }

    public Producto? ObtenerPorId(int id)
    {
        return _productos.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Producto> ObtenerTodos()
    {
        return _productos.AsReadOnly();
    }

    public bool Actualizar(Producto producto)
    {
        Producto? existente = ObtenerPorId(producto.Id);
        if (existente == null) return false;

        existente.Nombre = producto.Nombre;
        existente.Precio = producto.Precio;
        existente.Cantidad = producto.Cantidad;
        existente.Categoria = producto.Categoria;
        existente.Estado = producto.Estado;

        return true;
    }

    public bool Eliminar(int id)
    {
        Producto producto = ObtenerPorId(id);

        if (producto == null) return false;

        return _productos.Remove(producto);
    }

    public int Cantidad => _productos.Count;

    //===================== Busqueda con Where LINQ ===========
    public IEnumerable<Producto> BuscarPorCategoria(CategoriaProducto categoria)
    {
        return _productos.Where(p => p.Categoria == categoria);
    }

    public IEnumerable<Producto> BuscarPorNombre(string nombre)
    {
        return _productos.Where(p => p.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Producto> BuscarPorRangoPrecio(decimal precioMinimo, decimal precioMaximo)
    {
        return _productos.Where(p => p.Precio >= precioMinimo && p.Precio <= precioMaximo);
    }

    public IEnumerable<string> ObtenerNombres()
    {
        return _productos.Select(p => p.Nombre);
    }

    public bool HayStockBajo()
    {
        return _productos.Any(p => p.Cantidad <= 5);
    }

    public IEnumerable<Producto> ObtenerOrdenadosPorPrecio()
    {
        return _productos.OrderBy(p => p.Precio);
    }

    public IEnumerable<Producto> ObtenerTopPorPrecio(int cantidad)
    {
        return _productos.OrderByDescending(p => p.Precio).Take(cantidad);
    }

    //==========GroupBy y conversión a Dictionary ========

    public IEnumerable<IGrouping<CategoriaProducto, Producto>> AgruparPorCategoria()
    {
        return _productos.GroupBy(p => p.Categoria);
    }

    public Dictionary<CategoriaProducto, int> ContarPorCategoria()
    {
        return _productos   //List<Producto>
            .GroupBy(p => p.Categoria)      //IEnumerable<IGrouping<CategoriaProducto, Producto>>
            .ToDictionary(g => g.Key, g => g.Count());
    }

    //=========AGregaciones con SUM, AVERAGE y MAXBY 

    public decimal ObtenerValorTotalInventario()
    {
        return _productos.Sum(p => p.ValorTotal);
    }

    /// <summary>
    /// Dame el PRECIO PROMEDIO de los productos
    /// </summary>
    /// <returns></returns>
    public decimal ObtenerPrecioPromedio()
    {
        if (_productos.Count == 0) return 0;
        return _productos.Average(p => p.Precio);
    }

    /// <summary>
    /// Dame el PRODUCTO mas caro
    /// </summary>
    /// <returns></returns>
    public Producto? ObtenerProductoMasCaro()
    {
        return _productos.MaxBy(p => p.Precio);
    }

    /// <summary>
    /// AGRUPA y SUMA el ValorTotal por cada Categoria
    /// </summary>
    /// <returns></returns>
    public Dictionary<CategoriaProducto, decimal> ObtenerValorPorCategoria()
    {
        return _productos   //List<Producto>
            .GroupBy(p => p.Categoria)      //IEnumerable<IGrouping<>
            .ToDictionary(g => g.Key, g => g.Sum(p => p.ValorTotal));
    }

    /// <summary>
    /// Dame los productos cuyo STOCK esté por debajo de las 5 unidades
    /// </summary>
    /// <param name="umbral"></param>
    /// <returns></returns>
    public IEnumerable<Producto> ObtenerStockBajo(int umbral = 5)
    {
        return _productos.Where(p => p.Cantidad < umbral);
    }

}