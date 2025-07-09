using System;
using System.Collections.Generic;

namespace ServicioApi.Models;

public partial class Transaccion
{
    public int IdTransact { get; set; }

    public DateOnly? FechaEntrega { get; set; }

    public DateOnly? FechaRetorno { get; set; }

    public int? IdCliente { get; set; }

    public int? IdEstado { get; set; }

    public int? IdTipotran { get; set; }

    public string? Direccion { get; set; }
}


public partial class TransactEnvio
{
    public int libro1 { get; set; }
    public int? libro2 { get; set; }
    public int? libro3 { get; set; }
    public int id_cliente { get; set; }
    public int tipo_transact { get; set; }

}