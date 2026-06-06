using Dsw2026Ej14.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Interfaces
{
    public interface IAgregarVehiculosPresenter
    {
        public List<Sucursal> ObtenerSucursales();
        public void AgregarVehiculo();
        public bool AgregarVehiculoElectrico(string patente, string marca, string modelo, int anio,
            double capacidadCarga, Sucursal sucursal, double kwhBase);
        public bool AgregarVehiculoCombustible(string patente, string marca, string modelo, int anio,
            double capacidadCarga, Sucursal sucursal, double kilometrosPorLitro, double litrosExtra);
    }
}
