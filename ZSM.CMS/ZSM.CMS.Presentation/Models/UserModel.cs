using DDSoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZSM.CMS.Presentation.Models
{
    public class UserModel : NotifyPropertyChangedObject, IModel
    {
        private int _id;
        private string _userName;
        private string _password;
        private DateTime _createDate;
        private DateTime _updateDate;

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(() => Id); }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(() => UserName); }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (!string.IsNullOrEmpty(value) && _password != value)
                {
                    _password = value;
                    OnPropertyChanged(() => Password);
                }
            }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; OnPropertyChanged(() => CreateDate); }
        }

        public DateTime UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; OnPropertyChanged(() => UpdateDate); }
        }

        #region Override methods

        public override string ToString()
        {
            return string.Format("User name:{0}, Id:{1};", UserName, Id);
        }

        #endregion
    }
}
