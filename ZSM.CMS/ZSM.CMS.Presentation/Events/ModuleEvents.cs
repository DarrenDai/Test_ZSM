using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZSM.CMS.Presentation.Events
{
    public class CustomerManagementEvent : CompositePresentationEvent<object>
    {
    }

    public class UserManagementEvent : CompositePresentationEvent<object>
    {
    }

    public class DataManagementEvent : CompositePresentationEvent<object>
    {
    }
}
