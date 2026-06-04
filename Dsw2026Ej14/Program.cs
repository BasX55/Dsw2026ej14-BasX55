using Dsw2026Ej14.Data.Sources;
using Dsw2026Ej14.Presentation.Views;

namespace Dsw2026Ej14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persistencia.InicializarDatos();
            var view = new ConsoleView();
            view.DibujarMenu();
        }
    }
}
