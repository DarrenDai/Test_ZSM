using System;

namespace DDSoft.Framework
{
    public interface IViewModel
    {
        IView View { get; set; }

        void Initialize();
    }
}

