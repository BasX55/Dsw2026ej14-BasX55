using Dsw2026Ej14.Data;
using Dsw2026Ej14.Domain.Entities;
using Dsw2026Ej14.Domain.Interfaces;
using Dsw2026Ej14.Presentation.Interfaces;
using Dsw2026Ej14.Presentation.Models;
using Dsw2026Ej14.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Presenters
{
    public class ListarVehiculosPresenter : BasePresenter<IListarVehiculosView>, IListarVehiculosPresenter
    {
        private readonly IPersistencia _persistencia;


        public ListarVehiculosPresenter(IListarVehiculosView vista, IPersistencia persistencia) : base(vista)
        {
            _persistencia = persistencia;
            ListarVehiculos();
        }

        public void ListarVehiculos()
        {
            List<VehiculoViewModel> vehiculos = [];
            foreach (Vehiculo vehiculo in _persistencia.GetVehiculos())
            {
                vehiculos.Add(new VehiculoViewModel(vehiculo));
            }
            Vista.ListarVehiculos(vehiculos);
        }

        public void CalcularConsumos(Dictionary<string, double> vehiculos)
        {
            double consumoElectricos = 0;
            double consumoCombustible = 0;
            foreach (KeyValuePair<string, double> entry in vehiculos)
            {
                double consumo = 0;
                Vehiculo? vehiculo = _persistencia.GetVehiculo(entry.Key);
                if (vehiculo != null)
                {
                    consumo = vehiculo.CalcularConsumo(entry.Value);
                    consumoElectricos += vehiculo.EsDe(VehiculoTipo.Electrico) ? consumo : 0;
                    consumoCombustible += vehiculo.EsDe(VehiculoTipo.Combustible) ? consumo : 0;
                }
            }
            Vista.MostrarConsumos(consumoElectricos, consumoCombustible);
        }

        

    }
}
