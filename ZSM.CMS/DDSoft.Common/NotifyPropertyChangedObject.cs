using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace DDSoft.Common
{
    public class NotifyPropertyChangedObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged<TP>(Expression<Func<TP>> property)
        {
            PropertyInfo member = (property.Body as MemberExpression).Member as PropertyInfo;
            if (null == member)
            {
                throw new ArgumentException("The lambda expression property should point to a valid Property");
            }
            this.NotifyPropertyChanged(member.Name);
        }

        //public void OnPropertyChanged([CallerMemberName] string name = "")
        //{
        //    NotifyPropertyChanged(name);
        //}

        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
