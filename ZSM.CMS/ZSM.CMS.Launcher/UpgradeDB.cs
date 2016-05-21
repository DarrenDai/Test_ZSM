using DDSoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ZSM.CMS.Presentation.DataModel;

namespace ZSM.CMS.Launcher
{
    class UpgradeDB
    {
        public static void Upgrade()
        {
            //IDataModel
            var assembly = typeof(IDataModel).Assembly;
            var dataModelList = assembly.GetTypes().Where(x => x.GetInterfaces().Contains(typeof(IDataModel))).ToList();

            foreach (var item in dataModelList)
            {
                string tableName = item.Name;
                var properties = item.GetProperties();
                using (var helper = new AccessDbHelper())
                {
                    var table = helper.GetDataTable(string.Format("SELECT * FROM [{0}]", tableName));
                    foreach (var property in properties)
                    {
                        if (!table.Columns.Contains(property.Name))
                        {
                            helper.ExecuteSQLNonQuery(string.Format("ALTER TABLE [{0}] ADD COLUMN [{1}] {2}", tableName, property.Name, GetDBType(property)));
                        }
                    }
                }
            }
        }


        private static string GetDBType(PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof(string))
            {
                return DBType.Text;
            }

            if (propertyInfo.PropertyType == typeof(bool))
            {
                return DBType.YesNo;
            }

            if (propertyInfo.PropertyType == typeof(DateTime))
            {
                return DBType.Date;
            }

            if (propertyInfo.PropertyType == typeof(int))
            {
                return DBType.Integer;
            }

            return DBType.Text;
        }
    }


    static class DBType
    {
        public static string Text = "varchar(200)";
        public static string Integer = "int";
        public static string Date = "DATETIME";
        public static string YesNo = "bit";
    }
}
