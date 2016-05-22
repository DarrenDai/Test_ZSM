using DDSoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZSM.CMS.Presentation.DataModel
{
    public class User : IDataModel
    {
        //private int       _id;
        //private string    _userName;
        //private string    _password;
        //private DateTime  _createDate;
        //private DateTime  _updateDate;

        public int Id
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public DateTime CreateDate
        {
            get;
            set;
        }

        public DateTime UpdateDate
        {
            get;
            set;
        }
    }
}
