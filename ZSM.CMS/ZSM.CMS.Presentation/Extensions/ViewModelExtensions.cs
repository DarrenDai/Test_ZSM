using ZSM.CMS.Presentation.DataModel;
using ZSM.CMS.Presentation.Models;

namespace ZSM.CMS.Presentation.Extensions
{
    public static class ViewModelExtensions
    {
        public static User ToDataModel(this UserModel model)
        {
            return new User()
            {
                Id = model.Id,
                UserName = model.UserName,
                Password = model.Password,
                CreateDate = model.CreateDate,
                UpdateDate = model.UpdateDate,
            };
        }

        public static Customer ToDataModel(this CustomerModel model)
        {
            return new Customer()
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

        public static Prescription ToDataModel(this PrescriptionModel model)
        {
            return new Prescription()
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
    }
}
