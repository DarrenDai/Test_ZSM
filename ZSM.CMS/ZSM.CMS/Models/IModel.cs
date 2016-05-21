using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZSM.CMS.Presentation.DataModel;

namespace ZSM.CMS.Presentation.Models
{
    public interface IModel
    {
        int Id { get; set; }

        //IDataModel ToDataModel();
    }
}
