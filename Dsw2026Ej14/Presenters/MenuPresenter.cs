using Dsw2026Ej14.Presentation.Interfaces;
using Dsw2026Ej14.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Dsw2026Ej14.Presentation.Presenters
{
    public class MenuPresenter : IMenuPresenter
    {
        private readonly MenuView _vista;
        public MenuPresenter(MenuView vista)
        {
            _vista = vista;
        }

        public void AgregarVehiculo()
        {
            AgregarVehiculosView _vistaAgregar = new AgregarVehiculosView();
        }

        public void ListarVehiculo()
        {
            ListarVehiculosView _vistaLista = new ListarVehiculosView();
        } 

        
    }
}
