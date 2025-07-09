using System;
using System.Collections.Generic;

namespace ServicioApi.Models;

public partial class Ejemplare
{
    public int IdEjemplar { get; set; }

    public string? Codigo { get; set; }

    public int? Estado { get; set; }

    public int? TipoProd { get; set; }

    public int? IdItem { get; set; }

    public int? IdEstante { get; set; }
}

public partial class EjemplarAdd
{
    public int IdLibro { get; set; }
    public string Codigo { get; set; }
    public int IdEstante { get; set; }
}
