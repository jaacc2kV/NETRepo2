namespace InventarioApp.Infraestructure;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks.Dataflow;
using InventarioApp.Models;

public class GeneradorReportes
{
     private readonly IEnumerable<Producto> _productos;

     public GeneradorReportes(IEnumerable<Producto> productos)
    {
        _productos = productos;
    }

    public string GenerarResumen()
    {
        var sb = new StringBuilder();
        sb.AppendLine("=== RESUMEN DE INVENTARIO ===");
        sb.AppendLine($"Total de productos: {_productos.Count()}");
        sb.AppendLine($"Valor total del inventario: ${_productos.Sum(p => p.ValorTotal):F2}");

        var productosPorCategoria = _productos
                                                .GroupBy(p => p.Categoria)
                                                .Select(g => new {Categoria = g.Key, Cantidad = g.Count()});

        sb.AppendLine("\nProductos por categoría:");
        foreach (var categoria in productosPorCategoria)
        {
            sb.AppendLine($"    {categoria.Categoria}: {categoria.Cantidad}");
        }

        return sb.ToString();
    }

    public string GenerarReporteStockBajo(int minimo = 5)
    {
        var sb = new StringBuilder();
        sb.AppendLine("==== PRODUCTOS CON STOCK BAJO (< {minimo})====");

        IOrderedEnumerable<Producto> stockBajo = _productos
                                    .Where(p => p.Cantidad < minimo)
                                    .OrderBy(p => p.Cantidad);

        //verificando si existe al menos un producto con Stock Bajo    
        if (!stockBajo.Any())
        {
            sb.AppendLine("No hay productos con stock bajo");
            return sb.ToString();
        }

        foreach(var producto in stockBajo)
        {
            sb.AppendLine($"ID: {producto.Id} | {producto.Nombre} | Stock: {producto.Cantidad} | {producto.Precio:F2}");
        }

        return sb.ToString();

    }

    public string GenerarTopProductos(int cantidad = 5)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"=== TOP {cantidad} PRODUCTOS POR VALOR TOTAL ===");

        IEnumerable<Producto> top = _productos
                    .OrderByDescending(p => p.ValorTotal)
                    .Take(cantidad);

        if (!top.Any())
        {
            sb.AppendLine("No hay productos disponible");
            return sb.ToString();
        }

        int posicion = 1;
        foreach(Producto producto in top)
        {
            sb.AppendLine($"{posicion}. {producto.Nombre} | Cantidad: {producto.Cantidad} | Valor: {producto.ValorTotal:F2}");
            posicion++;
        }
        return sb.ToString();
    }

    public string ExportarCsv()
    {
        var sb = new StringBuilder();

        sb.AppendLine("Id, Nombre, Precio, Cantidad, Categoria, ValorTotal");

        foreach(var producto in _productos.OrderBy(p => p.Id))
        {
            sb.AppendLine($"{producto.Id}, {producto.Nombre}, {producto.Precio}, {producto.Cantidad}, {producto.Categoria}, {producto.ValorTotal}");
        }

        return sb.ToString();
    }

    public string ExportarResumenJson()
    {
        var resumen = new
        {
            TotalProductos = _productos.Count(), 
            ValorTotalInventario = _productos.Sum(p => p.ValorTotal), 
            ProductosPorCategoria = _productos
                    .GroupBy(p => p.Categoria)
                    .Select(g => new {Categoria = g.Key, Cantidad = g.Count()}), 
            Top5Productos = _productos
                    .OrderByDescending(p => p.ValorTotal)
                    .Take(5)
                    .Select(p => new {p.Id, p.Nombre, p.Cantidad, p.ValorTotal})
        };
        return JsonSerializer.Serialize(resumen, new JsonSerializerOptions {WriteIndented = true});
    }
}
