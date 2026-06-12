using Dsw2026Ej14.Presentation.Interfaces;
using Dsw2026Ej14.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Presenters
{
    public abstract class BasePresenter<T> : IPresenter where T : IBaseView
    {
        public T Vista { get; }
        protected BasePresenter(T vista)
        {
            Vista = vista;
            Vista.SetPresentador(this);
        }
    }
}
