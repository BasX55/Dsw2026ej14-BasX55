using Dsw2026Ej14.Presentation.Interfaces;
using Dsw2026Ej14.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Dsw2026Ej14.Presentation.Presenters
{
    public class MenuPresenter : BasePresenter<IMenuView>, IMenuPresenter
    {
        
        private readonly GestorPresentadores _gestor;
        public MenuPresenter(IMenuView vista, GestorPresentadores gestor) : base(vista)
        {
            _gestor = gestor;
            Vista.DibujarMenu();
        }

        

        public void AgregarVehiculo()
        {
            _gestor.NavegarA<IAgregarVehiculosPresenter>();
        }

        public void ListarVehiculo()
        {
            _gestor.NavegarA<IListarVehiculosPresenter>();
        } 

        
    }
}
