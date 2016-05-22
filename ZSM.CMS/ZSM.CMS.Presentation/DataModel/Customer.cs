using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZSM.CMS.Presentation.DataModel
{
    public class Customer : IDataModel
    {
        //private int      Id;
        //private string   CustomerNo;
        //private string   CustomerName;
        //private string   Sex;
        //private DateTime Birthday;
        //private string   TelephoneNumber;
        //private string   Address;
        //private string   Email;
        //private DateTime CreateDate;
        //private string   Comment;

        public int Id
        {
            get;
            set;
        }

        public string CustomerNo
        {
            get;
            set;
        }

        public string CustomerName
        {
            get;
            set;
        }

        public string Sex
        {
            get;
            set;
        }

        public DateTime Birthday
        {
            get;
            set;
        }

        public string TelephoneNumber
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public DateTime CreateDate
        {
            get;
            set;
        }

        public string Comment
        {
            get;
            set;
        }
    }
}
