using System;
using System.Runtime.CompilerServices;
using ZiCai.CMS.Common;

namespace ZiCai.CMS.Framework
{
    public class Presenter : NotifyPropertyChangedObject, IPresenter
    {
        public Presenter(IView view)
        {
            this.View = view;
            this.View.DataContext = this;
        }

        public IView View { get; set; }
    }
}

