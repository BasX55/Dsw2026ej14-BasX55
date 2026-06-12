using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Interfaces
{
    public interface IBaseView
    {
        void SetPresentador(IPresenter presentador);
    }

    public interface IBaseView<T> : IBaseView where T : IPresenter
    {
        T Presentador { get; }
        void SetPresentador(T presentador);

    }
}
