using System;
using System.Collections.Generic;

namespace ServicioApi.Models;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string? Nombre { get; set; }

    public string? Genero { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioAlquiler { get; set; }

    public decimal? PrecioVenta { get; set; }
}
