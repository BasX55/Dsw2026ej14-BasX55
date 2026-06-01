using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Domain;

public class Sucursal
{
    public string Codigo { get; init; }
    public string Direccion { get; init; }
    public string Ciudad { get; init; }
    public Responsable Responsable { get; init; }

    public Sucursal(string codigo, string direccion, string ciudad, Responsable responsable)
    {
        Codigo = codigo;
        Direccion = direccion;
        Ciudad = ciudad;
        Responsable = responsable;
    }
}
