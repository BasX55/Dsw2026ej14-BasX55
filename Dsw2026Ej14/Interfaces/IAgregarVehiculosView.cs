using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Interfaces
{
    public interface IAgregarVehiculosView
    {
        void AgregarVehiculo();
        void SetPresenter(IAgregarVehiculosPresenter presentador);
    }
}
