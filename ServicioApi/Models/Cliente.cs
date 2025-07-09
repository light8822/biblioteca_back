using System;
using System.Collections.Generic;

namespace ServicioApi.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Dni { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public int? Estado { get; set; }

    public string? Clave { get; set; }

    public string? Direccion { get; set; }

    public string? Ubigeo { get; set; }
}
