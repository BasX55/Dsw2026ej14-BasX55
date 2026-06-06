using Dsw2026Ej14.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Interfaces
{
    public interface IListarVehiculosView
    {
        void ListarVehiculos(List<VehiculoViewModel> vehiculos);
        void MostrarConsumos(double electricos, double combustible);

        void SetPresenter(IListarVehiculosPresenter presenter);
    }
}
