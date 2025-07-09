using System;
using System.Collections.Generic;

namespace ServicioApi.Models;

public partial class Usuario
{
    public int IdUser { get; set; }

    public string? Codigo { get; set; }

    public string? Clave { get; set; }

    public int? Estado { get; set; }

    public string? Correo { get; set; }

    public int? IdPerfil { get; set; }
}

public partial class UsuarioLogin
{
    public int IdUser { get; set; }

    public string? Codigo { get; set; }

    public string? Clave { get; set; }

    public int? Estado { get; set; }

    public string? Correo { get; set; }

    public int? IdPerfil { get; set; }
    public string? NombrePerfil { get; set; }
    public int? Usuarios { get; set; }
    public int? Clientes { get; set; }
    public int? Ventas { get; set; }
    public int? Reportes { get; set; }
    public int? Lista_Negra { get; set; }
}

public partial class Login
{
    public string? Codigo { get; set; }
    public string? Clave { get; set; }
}
