using System;
using System.Collections.Generic;

namespace ServicioApi.Models;

public partial class DetalleTransaccion
{
    public int IdDetalle { get; set; }

    public int? IdEjemplar { get; set; }

    public int? IdTransact { get; set; }
}
