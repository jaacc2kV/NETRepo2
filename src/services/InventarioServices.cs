namespace InventarioApp.services;

using InventarioApp.Models;
using InventarioApp.Repositories;
using InventarioApp.Infraestructure;
using InventarioApp.Factories;
using System.ComponentModel;
using System.Transactions;

public class InventarioServices
{
    private readonly InMemoryProductoRepository _repository;
    private readonly JsonInventarioStorage _storage;
    private readonly string _rutaInventario;

    public InventarioServices(string rutaInventario = "inventario.json")
    {
        _repository = new InMemoryProductoRepository();
        _storage = new JsonInventarioStorage();
        _rutaInventario = rutaInventario;

        CargarInventario();
    }

    public void CargarInventario()
    {
        if (File.Exists(_rutaInventario))
        {
            List<Producto> productos = _storage.Cargar(_rutaInventario);
            foreach(Producto producto in productos)
            {
                _repository.Agregar(producto);
            }
        }
    }

    public void AgregarProducto(string nombre, decimal precio, int cantidad, CategoriaProducto categoria)
    {
        Producto producto = ProductoFactory.Crear(nombre, precio, cantidad, categoria);
        _repository.Agregar(producto);
        _Persistir();
    }

    public IEnumerable<Producto> ObtenerTodosLosProductos()
    {
        return _repository.ObtenerTodos();
    }

    public Producto? ObtenerProductoPorId(int id)
    {
        return _repository.ObtenerPorId(id);
    }

    public void ActualizarProducto(int id, string nombre, decimal precio, int cantidad, CategoriaProducto categoria)
    {
        Producto? producto = _repository.ObtenerPorId(id);
        if (producto != null)
        {
            producto.Nombre = nombre;
            producto.Precio = precio;
            producto.Cantidad = cantidad;
            producto.Categoria = categoria;
            _repository.Actualizar(producto);
            _Persistir();
        }
    }

    public void EliminarProducto(int id)
    {
        _repository.Eliminar(id);
        _Persistir();
    }

    public IEnumerable<Producto> BuscarPorCategoria(CategoriaProducto categoria)
    {
        return _repository.BuscarPorCategoria(categoria);
    }

    public IEnumerable<Producto> BuscarPorNombre(string nombre)
    {
        return _repository.BuscarPorNombre(nombre);
    }

    public IEnumerable<Producto> ObtenerProductosBajoStock(int minimo = 5)
    {
        return _repository.ObtenerStockBajo(minimo);
    }

    public decimal ObtenerValorTotalInventario()
    {
        return _repository.ObtenerValorTotalInventario();
    }

    public decimal ObtenerPrecioPromedio()
    {
        return _repository.ObtenerPrecioPromedio();
    }

    public Producto? ObtenerProductoMasCaro()
    {
        return _repository.ObtenerProductoMasCaro();
    }

    //Metodo REPORTES
    public string GenerarResumen()
    {
        IEnumerable<Producto> productos = _repository.ObtenerTodos();
        GeneradorReportes generador = new GeneradorReportes(productos);
        return generador.GenerarResumen();
    }

    public string GenerarReporteStockBajo(int minimo = 5)
    {
        IEnumerable<Producto> productos = _repository.ObtenerTodos();
        GeneradorReportes generador = new GeneradorReportes(productos);
        return generador.GenerarReporteStockBajo(minimo);
    }

    public string GenerarTopProductos(int cantidad = 5)
    {
        IEnumerable<Producto> productos = _repository.ObtenerTodos();
        GeneradorReportes generador = new GeneradorReportes(productos);
        return generador.GenerarTopProductos(cantidad);
    }

    public string ExportarCsv()
    {
        IEnumerable<Producto> productos = _repository.ObtenerTodos();
        GeneradorReportes generador = new GeneradorReportes(productos);
        return generador.ExportarCsv();
    }

    public void _Persistir()
    {
        _storage.CrearBackup(_rutaInventario);
        List<Producto> productos = _repository.ObtenerTodos().ToList();
        _storage.Guardar(productos, _rutaInventario);
    }

}