using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Views
{
    internal class BaseView
    {
        private void DibjuarDatos(int columnas, List<VehiculoViewModel> vehiculos)
        {
            int ancho = Console.WindowWidth / columnas;
            foreach (var vehiculo in vehiculos)
            {
                Console.Write("|");
                CentrarTexto(vehiculo.Patente, out int l, ancho - 1, false);
                Console.Write("".PadRight(ancho - 1 - l));
                Console.Write("|");
                CentrarTexto(vehiculo.Vehiculo, out l, ancho - 1, false);
                Console.Write("".PadRight(ancho - 1 - l));
                Console.Write("|");
                CentrarTexto(vehiculo.Tipo, out l, ancho - 1, false);
                Console.Write("".PadRight(ancho - 1 - l));
                Console.Write("|");
                CentrarTexto(vehiculo.CapacidadCarga.ToString(), out l, ancho - 1, false);
                Console.Write("".PadRight(ancho - 1 - l));
                Console.Write("|");
                CentrarTexto(vehiculo.KmPorLitro.ToString(), out l, ancho - 1, false);
                Console.Write("".PadRight(ancho - 1 - l));
                Console.Write("|");
                CentrarTexto(vehiculo.Anio.ToString(), out l, ancho - 1, false);
                Console.Write("".PadRight(ancho - 1 - l));
                Console.Write("|");
                CentrarTexto(vehiculo.LitrosExtra.ToString(), out l, ancho - 1, false);
                Console.Write("".PadRight(ancho - 1 - l));
                Console.Write("|");
                CentrarTexto(vehiculo.KmARecorrer.ToString(), out l, ancho - 1, false);
                Console.Write("".PadRight(ancho - 1 - l));
            }
        }
}
