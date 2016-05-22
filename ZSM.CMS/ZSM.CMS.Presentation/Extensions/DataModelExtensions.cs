using DDSoft.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using ZSM.CMS.Presentation.DataModel;
using ZSM.CMS.Presentation.Models;

namespace ZSM.CMS.Presentation.Extensions
{
    public static class DataModelExtensions
    {
        #region ToViewModel

        public static UserModel ToViewModel(this User model)
        {
            return new UserModel()
            {
                Id = model.Id,
                UserName = model.UserName,
                Password = model.Password,
                CreateDate = model.CreateDate,
                UpdateDate = model.UpdateDate,
            };
        }

        public static CustomerModel ToViewModel(this Customer model)
        {
            return new CustomerModel()
            {
                Id = model.Id,
                CustomerNo = model.CustomerNo,
                CustomerName = model.CustomerName,
                Sex = model.Sex,
                Birthday = model.Birthday,
                TelephoneNumber = model.TelephoneNumber,
                Address = model.Address,
                Email = model.Email,
                CreateDate = model.CreateDate,
                Comment = model.Comment,
            };
        }

        public static PrescriptionModel ToViewModel(this  Prescription model)
        {
            return new PrescriptionModel()
            {
                Id = model.Id,
                CustomerId = model.CustomerId,
                VisionFarLeft = model.VisionFarLeft,
                VisionFarRight = model.VisionFarRight,
                VisionNearLeft = model.VisionNearLeft,
                VisionNearRight = model.VisionNearRight,
                BMirrorFarLeft = model.BMirrorFarLeft,
                BMirrorFarRight = model.BMirrorFarRight,
                BMirrorNearLeft = model.BMirrorNearLeft,
                BMirrorNearRight = model.BMirrorNearRight,
                PMirrorFarLeft = model.PMirrorFarLeft,
                PMirrorFarRight = model.PMirrorFarRight,
                PMirrorNearLeft = model.PMirrorNearLeft,
                PMirrorNearRight = model.PMirrorNearRight,
                AMirrorFarLeft = model.AMirrorFarLeft,
                AMirrorFarRight = model.AMirrorFarRight,
                AMirrorNearLeft = model.AMirrorNearLeft,
                AMirrorNearRight = model.AMirrorNearRight,
                OKFarLeft = model.OKFarLeft,
                OKFarRight = model.OKFarRight,
                OKNearLeft = model.OKNearLeft,
                OKNearRight = model.OKNearRight,
                DegreeFarLeft = model.DegreeFarLeft,
                DegreeFarRight = model.DegreeFarRight,
                DegreeNearLeft = model.DegreeNearLeft,
                DegreeNearRight = model.DegreeNearRight,
                DFarLeft = model.DFarLeft,
                DFarRight = model.DFarRight,
                DNearLeft = model.DNearLeft,
                DNearRight = model.DNearRight,
                MainEye = model.MainEye,
                MirrorModelFar = model.MirrorModelFar,
                MirrorModelNear = model.MirrorModelNear,
                MirrorModelFarAmount = model.MirrorModelFarAmount,
                MirrorModelNearAmount = model.MirrorModelNearAmount,
                BracketModelFar = model.BracketModelFar,
                BracketModelNear = model.BracketModelNear,
                BracketModelFarAmount = model.BracketModelFarAmount,
                BracketModelNearAmount = model.BracketModelNearAmount,
                AdeModel = model.AdeModel,
                CareProduct = model.CareProduct,
                AdeAmount = model.AdeAmount,
                TotalAmount = model.TotalAmount,
                AmountPaid = model.AmountPaid,
                AmountNotPaid = model.AmountNotPaid,
                OptometristA = model.OptometristA,
                OptometristB = model.OptometristB,
                CreateDate = model.CreateDate,
                Checker = model.Checker,
                Comments = model.Comments,

                //
                Requirment = model.Requirment,
                LightCheck = model.LightCheck,
                R1mmLeft = model.R1mmLeft,
                R1DLeft = model.R1DLeft,
                R1AXLeft = model.R1AXLeft,
                R2mmLeft = model.R2mmLeft,
                R2DLeft = model.R2DLeft,
                R2AXLeft = model.R2AXLeft,
                AVGmmLeft = model.AVGmmLeft,
                AVGDLeft = model.AVGDLeft,
                AVGAXLeft = model.AVGAXLeft,
                CYLmmLeft = model.CYLmmLeft,
                CYLDLeft = model.CYLDLeft,
                CYLAXLeft = model.CYLAXLeft,
                R1mmRight = model.R1mmRight,
                R1DRight = model.R1DRight,
                R1AXRight = model.R1AXRight,
                R2mmRight = model.R2mmRight,
                R2DRight = model.R2DRight,
                R2AXRight = model.R2AXRight,
                AVGmmRight = model.AVGmmRight,
                AVGDRight = model.AVGDRight,
                AVGAXRight = model.AVGAXRight,
                CYLmmRight = model.CYLmmRight,
                CYLDRight = model.CYLDRight,
                CYLAXRight = model.CYLAXRight,
                //
                HorLocationFar = model.HorLocationFar,
                HorLocationNear = model.HorLocationNear,
                VerLocationFar = model.VerLocationFar,
                VerLocationNear = model.VerLocationNear,
                ACCal = model.ACCal,
                ACTD = model.ACTD,
                PRA = model.PRA,
                NRA = model.NRA,
                BCC = model.BCC,
                RightAdjustWidth = model.RightAdjustWidth,
                RightAdjustSensitivity = model.RightAdjustSensitivity,
                LeftAdjustWidth = model.LeftAdjustWidth,
                LeftAdjustSensitivity = model.LeftAdjustSensitivity,
                BothAdjustWidth = model.BothAdjustWidth,
                BothAdjustSensitivity = model.BothAdjustSensitivity,
                CheckWayAdjustWidth = model.CheckWayAdjustWidth,
                CheckWayAdjustSensitivity = model.CheckWayAdjustSensitivity,
                InosculateFunction = model.InosculateFunction,
                StereoFunction = model.StereoFunction,
                NPC = model.NPC,
                ChromaticVision = model.ChromaticVision,
            };
        }

        #endregion

        public static List<T> ToItemList<T>(this DataTable table)
        {
            List<T> items = new List<T>();

            if (table == null)
                return items;

            try
            {
                PropertyInfo[] properties = typeof(T).GetProperties();

                foreach (DataRow item in table.Rows)
                {
                    T tempItem = (T)Activator.CreateInstance(typeof(T));

                    foreach (var property in properties)
                    {
                        var data = item[property.Name];
                        if (!Convert.IsDBNull(data))
                            property.SetValue(tempItem, data, null);

                        //if (property.PropertyType == typeof(DateTime))
                        //{
                        //    property.SetValue(tempItem, GetDBDateTime(data), null);
                        //}
                        //else
                        //{
                        //    property.SetValue(tempItem, data, null);
                        //}
                    }

                    items.Add(tempItem);
                }
            }
            catch (Exception ex)
            {
                ApplicationContext.Current.Logger.Error("Error happened when converting table to Entity.", ex);
            }

            return items;
        }

        #region DB operations

        public static bool SaveToDb(this IDataModel obj)
        {
            try
            {
                using (var helper = new AccessDbHelper())
                {
                    string insertParams = GetInsertString(obj);
                    helper.ExecuteSQLNonQuery(string.Format("INSERT INTO [{0}] {1}", obj.GetType().Name, insertParams));
                }
                return true;
            }
            catch (Exception ex)
            {
                ApplicationContext.Current.Logger.Error("DeleteFromDb failed.", ex);
            }

            return false;
        }

        public static bool UpdateToDb(this IDataModel obj)
        {
            try
            {
                using (var helper = new AccessDbHelper())
                {
                    string updateParams = GetUpdateString(obj);
                    helper.ExecuteSQLNonQuery(string.Format("UPDATE [{0}] SET {1}", obj.GetType().Name, updateParams));
                }
                return true;
            }
            catch (Exception ex)
            {
                ApplicationContext.Current.Logger.Error("DeleteFromDb failed.", ex);
            }

            return false;
        }

        public static bool DeleteFromDb(this IDataModel obj)
        {
            try
            {
                using (AccessDbHelper helper = new AccessDbHelper())
                {
                    helper.ExecuteSQLNonQuery(string.Format("UPDATE [{0}] SET ISDELETED =1 WHERE ID={1}", obj.GetType().Name, ((IDataModel)obj).Id));
                }
                return true;
            }
            catch (Exception ex)
            {
                ApplicationContext.Current.Logger.Error("DeleteFromDb failed.", ex);
            }

            return false;
        }

        #endregion

        #region Private methods

        private static string ClearStringForSQL(string str)
        {
            if (!string.IsNullOrEmpty(str))
                return str.Replace("'", "''");

            return string.Empty;
        }

        private static DateTime GetDBDateTime(object dateTime)
        {
            if (Convert.IsDBNull(dateTime))
                return DateTime.MinValue;
            else
                return (DateTime)dateTime;
        }

        private static string GetInsertString(object entity)
        {
            if (entity == null)
                return string.Empty;
            try
            {
                var properties = entity.GetType().GetProperties().ToList();
                properties.Remove(properties.FirstOrDefault(x => x.Name.ToLower() == "id"));
                string keys = string.Join(",", properties.Select(x => string.Format("[{0}]", x.Name)).ToList());

                List<string> values = new List<string>();
                foreach (var item in properties)
                {
                    var tempValue = item.GetValue(entity, null);

                    if (item.PropertyType == typeof(string))
                    {
                        values.Add(string.Format("'{0}'", ClearStringForSQL(tempValue == null ? "" : tempValue.ToString())));
                    }
                    else if (item.PropertyType == typeof(DateTime))
                    {
                        values.Add(string.Format("#{0}#", tempValue.ToString()));
                    }
                    else
                    {
                        values.Add(string.Format("{0}", tempValue.ToString()));
                    }
                }

                return string.Format("({0}) VALUES({1})", keys, string.Join(",", values));
            }
            catch (Exception ex)
            {
                ApplicationContext.Current.Logger.Error("GetInsertString failed.", ex);
            }

            return string.Empty;
        }

        private static string GetUpdateString(object entity)
        {
            if (entity == null)
                return string.Empty;
            try
            {
                var properties = entity.GetType().GetProperties().ToList();
                var idProperty = properties.FirstOrDefault(x => x.Name.ToLower() == "id");
                properties.Remove(idProperty);
                // set key=value,
                List<string> values = new List<string>();
                foreach (var item in properties)
                {
                    var tempValue = item.GetValue(entity, null);
                    string separator = string.Empty;
                    if (item.PropertyType == typeof(string))
                    {
                        separator = "'";
                        values.Add(string.Format("[{0}] = {2}{1}{2}", item.Name, ClearStringForSQL(tempValue == null ? "" : tempValue.ToString()), separator));
                    }
                    else if (item.PropertyType == typeof(DateTime))
                    {
                        separator = "#";
                        values.Add(string.Format("[{0}] = {2}{1}{2}", item.Name, tempValue.ToString(), separator));
                    }
                    else
                    {
                        values.Add(string.Format("[{0}] = {2}{1}{2}", item.Name, tempValue.ToString(), separator));
                    }

                }

                return string.Format("{0} WHERE ID= {1}", string.Join(",", values), idProperty.GetValue(entity, null));
            }
            catch (Exception ex)
            {
                ApplicationContext.Current.Logger.Error("GetUpdateString failed.", ex);
            }

            return string.Empty;
        }

        #endregion
    }
}
