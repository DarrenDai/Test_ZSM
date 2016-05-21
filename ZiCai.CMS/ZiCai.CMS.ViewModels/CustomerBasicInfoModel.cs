using System;
using System.Linq.Expressions;
using System.Reflection;
using ZiCai.CMS.Common;

namespace ZiCai.CMS.ViewModels
{
    public class CustomerBasicInfoModel : NotifyPropertyChangedObject
    {
        private string _address = string.Empty;
        private string _beautyAdvisor = string.Empty;
        private DateTime _birthday;
        private string _comment = string.Empty;
        private DateTime _createDate;
        private string _customerName = string.Empty;
        private string _customerNo = string.Empty;
        private string _email = string.Empty;
        private string _qQNumber = string.Empty;
        private string _skinCondition = string.Empty;
        private string _telephoneNumber = string.Empty;
        private string _trade = string.Empty;

        public string Address
        {
            get
            {
                return this._address;
            }
            set
            {
                if (value != this._address)
                {
                    this._address = value;
                    OnPropertyChanged(() => Address);
                }
            }
        }

        public string BeautyAdvisor
        {
            get
            {
                return this._beautyAdvisor;
            }
            set
            {
                if (value != this._beautyAdvisor)
                {
                    this._beautyAdvisor = value;
                    OnPropertyChanged(() => BeautyAdvisor);
                }
            }
        }

        public DateTime Birthday
        {
            get
            {
                return this._birthday;
            }
            set
            {
                if (value != this._birthday)
                {
                    this._birthday = value;
                    OnPropertyChanged(() => Birthday);
                }
            }
        }

        public string Comment
        {
            get
            {
                return this._comment;
            }
            set
            {
                if (value != this._comment)
                {
                    this._comment = value;
                    OnPropertyChanged(() => Comment);
                }
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return this._createDate;
            }
            set
            {
                if (value != this._createDate)
                {
                    this._createDate = value;
                    OnPropertyChanged(() => CreateDate);
                }
            }
        }

        public string CustomerName
        {
            get
            {
                return this._customerName;
            }
            set
            {
                if (value != this._customerName)
                {
                    this._customerName = value;
                    OnPropertyChanged(() => CustomerName);
                }
            }
        }

        public string CustomerNo
        {
            get
            {
                return this._customerNo;
            }
            set
            {
                if (value != this._customerNo)
                {
                    this._customerNo = value;
                    OnPropertyChanged(() => CustomerNo);
                }
            }
        }

        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                if (value != this._email)
                {
                    this._email = value;
                    OnPropertyChanged(() => Email);
                }
            }
        }

        public string QQNumber
        {
            get
            {
                return this._qQNumber;
            }
            set
            {
                if (value != this._qQNumber)
                {
                    this._qQNumber = value;
                    OnPropertyChanged(() => QQNumber);
                }
            }
        }

        public string SkinCondition
        {
            get
            {
                return this._skinCondition;
            }
            set
            {
                if (value != this._skinCondition)
                {
                    this._skinCondition = value;
                    OnPropertyChanged(() => SkinCondition);
                }
            }
        }

        public string TelephoneNumber
        {
            get
            {
                return this._telephoneNumber;
            }
            set
            {
                if (value != this._telephoneNumber)
                {
                    this._telephoneNumber = value;
                    OnPropertyChanged(() => TelephoneNumber);
                }
            }
        }

        public string Trade
        {
            get
            {
                return this._trade;
            }
            set
            {
                if (value != this._trade)
                {
                    this._trade = value;
                    OnPropertyChanged(() => Trade);
                }
            }
        }
    }
}

