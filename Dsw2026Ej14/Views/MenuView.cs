using Dsw2026Ej14.Presentation.Interfaces;
using Dsw2026Ej14.Presentation.Presenters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Views
{
    public class MenuView : BaseView, IMenuView
    {
        private IMenuPresenter _presenter;
        public MenuView()
        {
            
        }
        
        public void DibujarMenu()
        {
            
            string? opcion = null;
            do
            {
                DibujarEncabezado();
                Console.WriteLine("Elija una opción: \n");
                Console.WriteLine("1. Listar vehículos");
                Console.WriteLine("2. Agregar vehículo");
                Console.WriteLine("3. Salir");
                Console.WriteLine("\n");
                Console.WriteLine("Ingrese su opción: ");
                opcion = Console.ReadLine();
                if (opcion == "1")
                {
                    Console.WriteLine("Listando vehículos...");
                    _presenter.ListarVehiculo();
                }
                else if (opcion == "2")
                {
                    _presenter.AgregarVehiculo();
                }
            }
            while (opcion != "3");
        }

        public void SetPresenter(IMenuPresenter presenter)
        {
            _presenter = presenter;
        }
    }
}
