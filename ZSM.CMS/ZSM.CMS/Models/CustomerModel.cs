using DDSoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZSM.CMS.Presentation.Models
{
    public class CustomerModel : NotifyPropertyChangedObject, IModel
    {
        #region Private fields

        private int _id;
        private string _customerNo;
        private string _customerName;
        private string _sex;
        private DateTime _birthday;
        private string _telephoneNumber;
        private string _address;
        private string _email;
        private DateTime _createDate;
        private string _comment;
        private int _age;

        #endregion

        #region DB Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(() => Id); }
        }

        public string CustomerNo
        {
            get { return _customerNo; }
            set { _customerNo = value; OnPropertyChanged(() => CustomerNo); }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; OnPropertyChanged(() => CustomerName); }
        }

        public string Sex
        {
            get { return string.IsNullOrEmpty(_sex) ? "男" : _sex; }
            set { _sex = value; OnPropertyChanged(() => Sex); }
        }

        public DateTime Birthday
        {
            get
            {
                return _birthday == DateTime.MinValue ? new DateTime(1980, 1, 1) : _birthday;
            }
            set
            {
                _birthday = value;
                OnPropertyChanged(() => Birthday);
                OnPropertyChanged(() => Age);
            }
        }

        public string TelephoneNumber
        {
            get { return _telephoneNumber; }
            set { _telephoneNumber = value; OnPropertyChanged(() => TelephoneNumber); }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged(() => Address); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(() => Email); }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; OnPropertyChanged(() => CreateDate); }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; OnPropertyChanged(() => Comment); }
        }

        #endregion

        #region Public Properties

        public int Age
        {
            get
            {
                return (DateTime.Now.Year - Birthday.Year);
            }
            set
            {
                if (value != _age)
                {
                    _age = value;
                    Birthday = new DateTime(DateTime.Now.Year - value, _birthday.Month, _birthday.Day);
                    OnPropertyChanged(() => Age);
                }
            }
        }

        #endregion

        #region Overide methods

        public override string ToString()
        {
            return string.Format("Customer Name:{0}, ID:{1}, NO:{2};", CustomerName, Id, CustomerNo);
        }

        #endregion
    }
}
