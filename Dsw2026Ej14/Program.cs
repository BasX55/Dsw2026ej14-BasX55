using Dsw2026Ej14.Data;
using Dsw2026Ej14.Domain.Interfaces;
using Dsw2026Ej14.Presentation.Interfaces;
using Dsw2026Ej14.Presentation.Presenters;
using Dsw2026Ej14.Presentation.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Dsw2026Ej14.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var services = new ServiceCollection();
            _ = services.AddTransient<IMenuView, MenuView>();
            _ = services.AddTransient<IMenuPresenter, MenuPresenter>();
            _ = services.AddTransient<IListarVehiculosView, ListarVehiculosView>();
            _ = services.AddTransient<IListarVehiculosPresenter, ListarVehiculosPresenter>();
            _ = services.AddTransient<IAgregarVehiculosView, AgregarVehiculosView>();
            _ = services.AddTransient<IAgregarVehiculosPresenter, AgregarVehiculosPresenter>();
            _ = services.AddSingleton<GestorPresentadores>();
            _ = services.AddSingleton<IPersistencia, Persistencia>();

            var provider = services.BuildServiceProvider();
            var gestor = provider.GetService<GestorPresentadores>();

            gestor?.NavegarA<IMenuPresenter>();
            
            
        }
    }
}
