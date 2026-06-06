using Dsw2026Ej14.Data;
using Dsw2026Ej14.Domain.Entities;
using Dsw2026Ej14.Presentation.Interfaces;
using Dsw2026Ej14.Presentation.Models;
using Dsw2026Ej14.Presentation.Presenters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Views
{
    public class ListarVehiculosView : BaseView, IListarVehiculosView
    {
        private ListarVehiculosPresenter _presenter;
        public ListarVehiculosView()
        {
            _presenter = new ListarVehiculosPresenter(this);
            _presenter.ListarVehiculos();
        }
        public void ListarVehiculos(List<VehiculoViewModel> vehiculos)
        {
            LimpiarPantalla();
            string[] columnas = { "Patente", "Vehículo", "Tipo", "Cap. Carga", "Km/l", "Año", "L.Extra", "Kms a recorrer" };
            DibujarEncabezado(columnas);

            DibujarDatos(columnas.Length, vehiculos);

            DibujarLinea();

            Console.Write("\n");
            Console.Write("\n");
            Console.WriteLine("Presione una tecla para calcular el total de consumos...");
            Console.ReadLine();
            Dictionary<string, double> vehiculosDict = [];
            foreach (VehiculoViewModel vehiculo in vehiculos)
            {
                vehiculosDict.Add(vehiculo.Patente, vehiculo.KmARecorrer);
            }
            _presenter.CalcularConsumos(vehiculosDict);
        }

        public void MostrarConsumos(double electricos, double combustible)
        {
            DibujarLinea();
            Console.WriteLine($"Total consumo Vehículos Eléctricos: {electricos:N2} kWh");
            Console.WriteLine($"Total consumo Vehículos Combustible: {combustible:N2} Litros");
            DibujarLinea();
            Console.Write("\n");
            Console.Write("\n");
            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadLine();
        }

    }
}
