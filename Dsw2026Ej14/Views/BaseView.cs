using Dsw2026Ej14.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Views
{
    public abstract class BaseView
    {
        public void DibujarDatos(int columnas, List<VehiculoViewModel> vehiculos)
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

        #region Util
        public static void DibujarEncabezado()
        {
            LimpiarPantalla();
            DibujarLinea();
            CentrarTexto("Menú Principal - Empresa de Transporte", out int _);
            DibujarLinea();
        }

        public static void CentrarTexto(string? texto, out int usado, int? ancho = null, bool salto = true)
        {
            texto ??= string.Empty;
            ancho ??= Console.WindowWidth;
            int largo = texto.Length;
            if (largo > ancho)
            {
                largo = ancho.Value;
                texto = texto.Substring(0, ancho.Value);
            }
            int espacios = (ancho.Value - largo) / 2;
            espacios = espacios % 2 == 0 ? espacios : espacios + 1;
            string fin = salto ? "\n" : string.Empty;
            string final = new string(' ', espacios) + texto + fin;
            Console.Write(final);
            usado = final.Length;
        }
        public static void LimpiarPantalla()
        {
            Console.Clear();
        }
        public static void DibujarLinea()
        {
            var with = Console.WindowWidth;
            for (int i = 0; i < with; i++)
            {
                Console.Write("-");
            }
        }
        public static void DibujarEncabezado(params string[] columnas)
        {
            DibujarLinea();
            int ancho = Console.WindowWidth / columnas.Length;

            foreach (var columna in columnas)
            {
                Console.Write("|");
                CentrarTexto(columna, out int l, ancho - 1, false);
                Console.Write("".PadRight(ancho - 1 - l));
            }
            Console.Write("\n");
            DibujarLinea();
        }
        #endregion
    }
}
