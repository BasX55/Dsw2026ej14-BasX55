using Dsw2026Ej14.Data;
using Dsw2026Ej14.Domain.Entities;
using Dsw2026Ej14.Domain.Interfaces;
using Dsw2026Ej14.Presentation.Interfaces;
using Dsw2026Ej14.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Presenters
{
    public class AgregarVehiculosPresenter : BasePresenter<IAgregarVehiculosView>, IAgregarVehiculosPresenter
    {
        private readonly IPersistencia _persistencia;

        public AgregarVehiculosPresenter(IAgregarVehiculosView vista, IPersistencia persistencia) : base(vista)
        {
            _persistencia = persistencia;
            
            Vista.AgregarVehiculo();
        }

        public List<Sucursal> ObtenerSucursales()
        {
            return _persistencia.GetSucursales();
        }

        

        public bool AgregarVehiculoElectrico(string patente, string marca, string modelo, int anio,
            double capacidadCarga, Sucursal sucursal, double kwhBase)
        {
            VehiculoElectrico vehiculo = new VehiculoElectrico(patente, marca, modelo, anio,
                capacidadCarga, sucursal, kwhBase);
            return _persistencia.AgregarVehiculo(vehiculo);
        }

        public bool AgregarVehiculoCombustible(string patente, string marca, string modelo, int anio,
            double capacidadCarga, Sucursal sucursal, double kilometrosPorLitro, double litrosExtra)
        {
            VehiculoCombustible vehiculo = new VehiculoCombustible(patente, marca, modelo, anio,
                capacidadCarga, sucursal, kilometrosPorLitro, litrosExtra);
            return _persistencia.AgregarVehiculo(vehiculo);
        }
    }
}
