using System;
using System.Collections.Generic;

namespace ServicioApi.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioVenta { get; set; }
}
