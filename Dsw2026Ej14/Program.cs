using Dsw2026Ej14.Data;
using Dsw2026Ej14.Views;

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
