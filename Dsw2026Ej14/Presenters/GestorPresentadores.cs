using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej14.Presentation.Presenters
{
    public class GestorPresentadores
    {
        private readonly IServiceProvider _provider;
        public GestorPresentadores(IServiceProvider provider)
        {
            _provider = provider;
        }

        public void NavegarA<T>()
        {
            _ = _provider.GetService(typeof(T));
        }
    }
}
