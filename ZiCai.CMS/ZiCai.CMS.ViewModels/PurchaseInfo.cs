using System;
using System.Linq.Expressions;
using System.Reflection;
using ZiCai.CMS.Common;

namespace ZiCai.CMS.ViewModels
{
    public class PurchaseInfo : NotifyPropertyChangedObject
    {
        private double _amount;
        private string _beautyAdvisor = string.Empty;
        private DateTime _createDate;
        private int _currentScore;
        private string _customerNo = string.Empty;
        private string _gift = string.Empty;
        private int _iD;
        private bool _isExchanged;
        private string _product = string.Empty;
        private int _totalScore;

        public double Amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                if (value != this._amount)
                {
                    this._amount = value;
                    OnPropertyChanged(() => Amount);
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

        public int CurrentScore
        {
            get
            {
                return this._currentScore;
            }
            set
            {
                if (value != this._currentScore)
                {
                    this._currentScore = value;
                    OnPropertyChanged(() => CurrentScore);
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

        public string Gift
        {
            get
            {
                return this._gift;
            }
            set
            {
                if (value != this._gift)
                {
                    this._gift = value;
                    OnPropertyChanged(() => Gift);
                }
            }
        }

        public int ID
        {
            get
            {
                return this._iD;
            }
            set
            {
                this._iD = value;
                OnPropertyChanged(() => ID);
            }
        }

        public bool IsExchanged
        {
            get
            {
                return this._isExchanged;
            }
            set
            {
                if (value != this._isExchanged)
                {
                    this._isExchanged = value;
                    OnPropertyChanged(() => IsExchanged);
                }
            }
        }

        public string Product
        {
            get
            {
                return this._product;
            }
            set
            {
                if (value != this._product)
                {
                    this._product = value;
                    OnPropertyChanged(() => Product);
                }
            }
        }

        public int TotalScore
        {
            get
            {
                return this._totalScore;
            }
            set
            {
                if (value != this._totalScore)
                {
                    this._totalScore = value;
                    OnPropertyChanged(() => TotalScore);
                }
            }
        }
    }
}

