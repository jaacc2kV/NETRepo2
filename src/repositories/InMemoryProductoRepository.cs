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

}