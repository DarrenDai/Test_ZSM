using DDSoft.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using ZSM.CMS.Presentation.Models;

namespace ZSM.CMS.Presentation.Extensions
{
    public static class EntityExtensions
    {
        public static List<UserModel> ToUserList(this DataTable table)
        {
            List<UserModel> users = new List<UserModel>();

            if (table == null)
                return users;

            try
            {
                foreach (DataRow item in table.Rows)
                {
                    UserModel tempUser = new UserModel()
                    {
                        Id = (int)item["Id"],
                        UserName = item["UserName"].ToString(),
                        Password = item["Password"].ToString(),
                        //CreateDate = GetDBDateTime(item["CreateDate"]),
                        //UpdateDate = GetDBDateTime(item["UpdateDate"]),
                    };
                    users.Add(tempUser);
                }
            }
            catch (Exception ex)
            {
                ApplicationContext.Current.Logger.Error("Error happened when converting table to Entity.", ex);
            }

            return users;
        }
    }
}
