using System;
using System.Collections.Generic;

namespace ServicioApi.Models;

public partial class Estante
{
    public int IdEstante { get; set; }

    public string? Codigo { get; set; }

    public string? Categoria { get; set; }
}
