using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DDSoft.Common.Controls
{
    public class ActionButton : Button
    {
        //static ActionButton()
        //{
        //    DefaultStyleKeyProperty.OverrideMetadata(typeof(ActionButton), new FrameworkPropertyMetadata(typeof(ActionButton)));
        //}

        public string PicturePath
        {
            get { return (string)GetValue(PicturePathProperty); }
            set { SetValue(PicturePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PicturePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PicturePathProperty =
            DependencyProperty.Register("PicturePath", typeof(string), typeof(ActionButton), new PropertyMetadata(string.Empty));

        public string ActionName
        {
            get { return (string)GetValue(ActionNameProperty); }
            set { SetValue(ActionNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ActionName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActionNameProperty =
            DependencyProperty.Register("ActionName", typeof(string), typeof(ActionButton), new PropertyMetadata(string.Empty));

    }
}