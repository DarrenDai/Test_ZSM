using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace DDSoft.Common
{
    public class NotifyPropertyChangedObject : INotifyPropertyChanged
    {
        // Events
        public event PropertyChangedEventHandler PropertyChanged;

        // Methods
        protected void OnPropertyChanged<TP>(Expression<Func<TP>> property)
        {
            PropertyInfo member = (property.Body as MemberExpression).Member as PropertyInfo;
            if (null == member)
            {
                throw new ArgumentException("The lambda expression property should point to a valid Property");
            }
            this.OnPropertyChanged(member.Name);
        }

        //public void NotifyChanged<T>(Expression<Func<T>> propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        var memberExpression = propertyName.Body as MemberExpression;
        //        if (memberExpression != null)
        //        {
        //            PropertyChanged(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
        //        }
        //    }
        //}

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }



}
