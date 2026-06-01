using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Domain;

public class Responsable
{
    public string Nombre { get; init; }
    public string Documento { get; init; }
    public string Telefono { get; init; }

    public Responsable(string nombre, string documento, string telefono)
    {
        Nombre = nombre;
        Documento = documento;
        Telefono = telefono;
    }
}
