using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Interfaces
{
    public interface IPresenter
    {
    }

    public interface IPresenter<T> : IPresenter
    {
        T Vista { get; }
    }
}
