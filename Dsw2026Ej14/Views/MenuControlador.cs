using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Views
{
    public class MenuControlador
    {
        private readonly MenuView _vista;
        public MenuControlador(MenuView vista)
        {
            _vista = vista;
        }

        public void OpcionSeleccionada(int o)
        {
            switch (o)
            {
                case 1:
                    
                    ListarVehiculosControlador _controlador = new ListarVehiculosControlador(new ListarVehiculosView());
                    _controlador.ListarVehiculos();
                    break;
                case 2:
                    AgregarVehiculosView _vista = new AgregarVehiculosView();
                    _vista.AgregarVehiculo();
                    break;
                default:
                    break;
            }
        }
    }
}
