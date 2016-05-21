using System;
using System.Linq.Expressions;
using System.Reflection;
using ZiCai.CMS.Common;

namespace ZiCai.CMS.ViewModels
{
    public class UpdatePurchaseHistoryModel : NotifyPropertyChangedObject
    {
        private CustomerBasicInfoModel _customerInfo;
        private ZiCai.CMS.ViewModels.PurchaseInfo _purchaseInfo;

        public CustomerBasicInfoModel CustomerInfo
        {
            get
            {
                return this._customerInfo;
            }
            set
            {
                if (value != this._customerInfo)
                {
                    this._customerInfo = value;
                    OnPropertyChanged(() => CustomerInfo);
                }
            }
        }

        public ZiCai.CMS.ViewModels.PurchaseInfo PurchaseInfo
        {
            get
            {
                return this._purchaseInfo;
            }
            set
            {
                if (value != this._purchaseInfo)
                {
                    this._purchaseInfo = value;
                    OnPropertyChanged(() => PurchaseInfo);
                }
            }
        }
    }
}

