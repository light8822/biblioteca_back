using System;
using System.Collections.Generic;

namespace ServicioApi.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int? Cantidad { get; set; }

    public int? IdCliente { get; set; }

    public string? IdTransaccion { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? IdMedio { get; set; }
}
