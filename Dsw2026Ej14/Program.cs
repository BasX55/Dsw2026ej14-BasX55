using Dsw2026Ej14.Data;
using Dsw2026Ej14.Presentation.Views;

namespace Dsw2026Ej14.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persistencia.InicializarDatos();
            var view = new MenuView();
            view.DibujarMenu();
        }
    }
}
