using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Interfaces
{
    public interface IListarVehiculosPresenter
    {
        public void ListarVehiculos();
        public void CalcularConsumos(Dictionary<string, double> vehiculos);

    }
}
