using DDSoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZSM.CMS.Presentation.DataModel
{
    public class Prescription : IDataModel
    {
        //private int                  _id;
        //private string               _vsionFarLeft;
        //private string               _vsionFarRight;
        //private string               _vsionNearLeft;
        //private string               _vsionNearRight;
        //private string               _bMirrorFarLeft;
        //private string               _bMirrorFarRight;
        //private string               _bMirrorNearLeft;
        //private string               _bMirrorNearRight;
        //private string               _pMirrorFarLeft;
        //private string               _pMirrorFarRight;
        //private string               _pMirrorNearLeft;
        //private string               _pMirrorNearRight;
        //private string               _aMirrorFarLeft;
        //private string               _aMirrorFarRight;
        //private string               _aMirrorNearLeft;
        //private string               _aMirrorNearRight;
        //private string               _oKFarLeft;
        //private string               _oKFarRight;
        //private string               _oKNearLeft;
        //private string               _oKNearRight;
        //private string               _degreeFarLeft;
        //private string               _degreeFarRight;
        //private string               _degreeNearLeft;
        //private string               _degreeNearRight;
        //private string               _dFarLeft;
        //private string               _dFarRight;
        //private string               _dNearLeft;
        //private string               _dNearRight;
        //private string               _mainEye;
        //private string               _mirrorModelFar;
        //private string               _mirrorModelNear;
        //private float _              mirrorModelFarAmount;
        //private float _              mirrorModelNearAmount;
        //private string               _bracketModelFar;
        //private string               _bracketModelNear;
        //private float                _bracketModelFarAmount;
        //private float                _bracketModelNearAmount;
        //private string               _adeModel;
        //private string               _careProduct;
        //private float                _adeAmount;
        //private float                _totalAmount;
        //private float                _amountPaid;
        //private float                _amountNotPaid;
        //private string               _optometristA;
        //private string               _optometristB;
        //private DateTime             _createDate;
        //private string               _checker;
        //private string               _comments;

        public int Id { set; get; }

        public int CustomerId { set; get; }

        public string VisionFarLeft
        { set; get; }

        public string VisionFarRight
        { set; get; }

        public string VisionNearLeft
        { set; get; }

        public string VisionNearRight
        { set; get; }

        public string BMirrorFarLeft
        { set; get; }

        public string BMirrorFarRight
        { set; get; }

        public string BMirrorNearLeft
        { set; get; }

        public string BMirrorNearRight
        { set; get; }

        public string PMirrorFarLeft
        { set; get; }

        public string PMirrorFarRight
        { set; get; }

        public string PMirrorNearLeft
        { set; get; }

        public string PMirrorNearRight
        { set; get; }

        public string AMirrorFarLeft
        { set; get; }

        public string AMirrorFarRight
        { set; get; }

        public string AMirrorNearLeft
        { set; get; }

        public string AMirrorNearRight
        { set; get; }

        public string OKFarLeft
        { set; get; }

        public string OKFarRight
        { set; get; }

        public string OKNearLeft
        { set; get; }

        public string OKNearRight
        { set; get; }

        public string DegreeFarLeft
        { set; get; }

        public string DegreeFarRight
        { set; get; }

        public string DegreeNearLeft
        { set; get; }

        public string DegreeNearRight
        { set; get; }

        public string DFarLeft
        { set; get; }

        public string DFarRight
        { set; get; }

        public string DNearLeft
        { set; get; }

        public string DNearRight
        { set; get; }

        public string MainEye
        { set; get; }

        public string MirrorModelFar
        { set; get; }

        public string MirrorModelNear
        { set; get; }

        public float MirrorModelFarAmount
        { set; get; }

        public float MirrorModelNearAmount
        { set; get; }

        public string BracketModelFar
        { set; get; }

        public string BracketModelNear
        { set; get; }

        public float BracketModelFarAmount
        { set; get; }

        public float BracketModelNearAmount
        { set; get; }

        public string AdeModel
        { set; get; }

        public string CareProduct
        { set; get; }

        public float AdeAmount
        { set; get; }

        public float TotalAmount
        { set; get; }

        public float AmountPaid
        { set; get; }

        public float AmountNotPaid
        { set; get; }

        public string OptometristA
        { set; get; }

        public string OptometristB
        { set; get; }

        public DateTime CreateDate
        { set; get; }

        public string Checker
        { set; get; }

        public string Comments
        { set; get; }

        //New Added
        public string Requirment { get; set; }
        public string LightCheck { get; set; }
        public string R1mmLeft { get; set; }
        public string R1DLeft { get; set; }
        public string R1AXLeft { get; set; }
        public string R2mmLeft { get; set; }
        public string R2DLeft { get; set; }
        public string R2AXLeft { get; set; }
        public string AVGmmLeft { get; set; }
        public string AVGDLeft { get; set; }
        public string AVGAXLeft { get; set; }
        public string CYLmmLeft { get; set; }
        public string CYLDLeft { get; set; }
        public string CYLAXLeft { get; set; }
        public string R1mmRight { get; set; }
        public string R1DRight { get; set; }
        public string R1AXRight { get; set; }
        public string R2mmRight { get; set; }
        public string R2DRight { get; set; }
        public string R2AXRight { get; set; }
        public string AVGmmRight { get; set; }
        public string AVGDRight { get; set; }
        public string AVGAXRight { get; set; }
        public string CYLmmRight { get; set; }
        public string CYLDRight { get; set; }
        public string CYLAXRight { get; set; }
        //
        public string HorLocationFar { get; set; }
        public string HorLocationNear { get; set; }
        public string VerLocationFar { get; set; }
        public string VerLocationNear { get; set; }
        public string ACCal { get; set; }
        public string ACTD { get; set; }
        //
        public string PRA { get; set; }
        public string NRA { get; set; }
        public string BCC { get; set; }
        public string RightAdjustWidth { get; set; }
        public string RightAdjustSensitivity { get; set; }
        public string LeftAdjustWidth { get; set; }
        public string LeftAdjustSensitivity { get; set; }
        public string BothAdjustWidth { get; set; }
        public string BothAdjustSensitivity { get; set; }
        public string CheckWayAdjustWidth { get; set; }
        public string CheckWayAdjustSensitivity { get; set; }

        //融合
        public string InosculateFunction { get; set; }
        public string StereoFunction { get; set; }
        public string NPC { get; set; }
        public string ChromaticVision { get; set; }
    }
}
