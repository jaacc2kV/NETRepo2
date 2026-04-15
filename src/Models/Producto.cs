using System.Data.Common;

namespace InventarioApp.Models;

public class Producto
{
    private string _nombre = "";
    private decimal _precio;
    private int _cantidad;
    
    public int Id {get; set;}
    public string Nombre 
    {
        get => _nombre; 
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Nombre no puede estar vacío", nameof(Nombre));
            _nombre = value.Trim();
        }
    }

    //public string Descripcion {get; set;} = "";   //NO es necesario, retirando campos innecesarios
    public decimal Precio 
    {
        get => _precio;
        set
        {
            if (value <0)
                throw new ArgumentException("Precio no puede ser negativo", nameof(Precio));
            _precio = value;
        }
    }
    public int Cantidad 
    {
        get => _cantidad;
        set
        {
            if (value < 0)
                throw new ArgumentException("Cantidad no puede ser negativo", nameof(Cantidad));
            _cantidad = value;
        }
    }
    public CategoriaProducto Categoria {get; set;}
    public EstadoProducto Estado {get; set;} = EstadoProducto.Activo;
    public DateTime FechaRegistro {get; set;}=DateTime.Now;
    public decimal ValorTotal => Precio * Cantidad;

    public override string ToString() => $"[{Id}] {Nombre} - ${Precio:N2} x {Cantidad} = ${ValorTotal:N2}";
    

}