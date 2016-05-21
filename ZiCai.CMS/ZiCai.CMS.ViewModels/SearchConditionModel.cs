using System;
using System.Linq.Expressions;
using System.Reflection;
using ZiCai.CMS.Common;
using ZiCai.CMS.Common.EnumDefinitions;

namespace ZiCai.CMS.ViewModels
{
    public class SearchConditionModel : NotifyPropertyChangedObject
    {
        private SearchConditionEnum _conditonType;
        private string _name = string.Empty;

        public SearchConditionEnum ConditonType
        {
            get
            {
                return this._conditonType;
            }
            set
            {
                if (value != this._conditonType)
                {
                    this._conditonType = value;
                    OnPropertyChanged(() => ConditonType);
                    //base.OnPropertyChanged<SearchConditionEnum>(Expression.Lambda<Func<SearchConditionEnum>>(Expression.Property(Expression.Constant(this, typeof(SearchConditionModel)), (MethodInfo) methodof(SearchConditionModel.get_ConditonType)), new ParameterExpression[0]));
                }
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                if (value != this._name)
                {
                    this._name = value;
                    OnPropertyChanged(() => Name);
                    //base.OnPropertyChanged<string>(Expression.Lambda<Func<string>>(Expression.Property(Expression.Constant(this, typeof(SearchConditionModel)), (MethodInfo) methodof(SearchConditionModel.get_Name)), new ParameterExpression[0]));
                }
            }
        }
    }
}

