using System;
using System.Collections.Generic;

namespace ServicioApi.Models;

public partial class Perfil
{
    public int IdPerfil { get; set; }

    public string? Nombre { get; set; }

    public int? Usuarios { get; set; }

    public int? Clientes { get; set; }

    public int? Ventas { get; set; }

    public int? Reportes { get; set; }

    public int? ListaNegra { get; set; }
}
