using Dsw2026Ej14.Data;
using Dsw2026Ej14.Domain.Entities;
using Dsw2026Ej14.Presentation.Interfaces;
using Dsw2026Ej14.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Presenters
{
    public class AgregarVehiculosPresenter : IAgregarVehiculosPresenter
    {
        private IAgregarVehiculosView _vista;

        public AgregarVehiculosPresenter(IAgregarVehiculosView vista)
        {
            _vista = vista;
            _vista.SetPresenter(this);
            _vista.AgregarVehiculo();
        }

        public List<Sucursal> ObtenerSucursales()
        {
            return Persistencia.GetSucursales();
        }

        

        public bool AgregarVehiculoElectrico(string patente, string marca, string modelo, int anio,
            double capacidadCarga, Sucursal sucursal, double kwhBase)
        {
            VehiculoElectrico vehiculo = new VehiculoElectrico(patente, marca, modelo, anio,
                capacidadCarga, sucursal, kwhBase);
            return Persistencia.AgregarVehiculo(vehiculo);
        }

        public bool AgregarVehiculoCombustible(string patente, string marca, string modelo, int anio,
            double capacidadCarga, Sucursal sucursal, double kilometrosPorLitro, double litrosExtra)
        {
            VehiculoCombustible vehiculo = new VehiculoCombustible(patente, marca, modelo, anio,
                capacidadCarga, sucursal, kilometrosPorLitro, litrosExtra);
            return Persistencia.AgregarVehiculo(vehiculo);
        }
    }
}
