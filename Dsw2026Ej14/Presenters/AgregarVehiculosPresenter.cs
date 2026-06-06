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
        private readonly AgregarVehiculosView _vista;

        public AgregarVehiculosPresenter(AgregarVehiculosView vista)
        {
            _vista = vista;
            
        }

        public List<Sucursal> ObtenerSucursales()
        {
            return Persistencia.GetSucursales();
        }

        public void AgregarVehiculo()
        {
            _vista.AgregarVehiculo();
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
