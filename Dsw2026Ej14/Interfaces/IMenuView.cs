using Dsw2026Ej14.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Interfaces
{
    public interface IMenuView : IBaseView<IMenuPresenter>
    {
        void DibujarMenu();
    }
}
