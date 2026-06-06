using Dsw2026Ej14.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Interfaces
{
    public interface IListarVehiculosView
    {
        public void ListarVehiculos(List<VehiculoViewModel> vehiculos);
        public void MostrarConsumos(double electricos, double combustible);

    }
}
