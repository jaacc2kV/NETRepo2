namespace InventarioApp.Models;

/// <summary>
/// Cliclo de vida de un producto en el inventario.
/// </summary>

public enum EstadoProducto
{
    /// <summary>
    /// Disponible para venta.
    /// </summary>
    Activo,
    /// <summary>
    /// Temporalmente fuera de disponiblidad.
    /// </summary>
    Inactivo,
    /// <summary>
    /// Retirado permanentemente del catalogo.
    /// </summary>
    Descontinuado
}