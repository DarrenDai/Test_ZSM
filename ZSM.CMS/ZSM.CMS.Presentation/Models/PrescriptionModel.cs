using DDSoft.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZSM.CMS.Presentation.Models
{
    public class PrescriptionModel : NotifyPropertyChangedObject, IModel
    {
        private int _id;
        private int _customerId;
        private string _vsionFarLeft;
        private string _vsionFarRight;
        private string _vsionNearLeft;
        private string _vsionNearRight;
        private string _bMirrorFarLeft;
        private string _bMirrorFarRight;
        private string _bMirrorNearLeft;
        private string _bMirrorNearRight;
        private string _pMirrorFarLeft;
        private string _pMirrorFarRight;
        private string _pMirrorNearLeft;
        private string _pMirrorNearRight;
        private string _aMirrorFarLeft;
        private string _aMirrorFarRight;
        private string _aMirrorNearLeft;
        private string _aMirrorNearRight;
        private string _oKFarLeft;
        private string _oKFarRight;
        private string _oKNearLeft;
        private string _oKNearRight;
        private string _degreeFarLeft;
        private string _degreeFarRight;
        private string _degreeNearLeft;
        private string _degreeNearRight;
        private string _dFarLeft;
        private string _dFarRight;
        private string _dNearLeft;
        private string _dNearRight;
        private string _mainEye;
        private string _mirrorModelFar;
        private string _mirrorModelNear;
        private float _mirrorModelFarAmount;
        private float _mirrorModelNearAmount;
        private string _bracketModelFar;
        private string _bracketModelNear;
        private float _bracketModelFarAmount;
        private float _bracketModelNearAmount;
        private string _adeModel;
        private string _careProduct;
        private float _adeAmount;
        private float _totalAmount;
        private float _amountPaid;
        private float _amountNotPaid;
        private string _optometristA;
        private string _optometristB;
        private DateTime _createDate;
        private string _checker;
        private string _comments;

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(() => Id); }
        }

        public int CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; OnPropertyChanged(() => CustomerId); }
        }

        public string VisionFarLeft
        {
            get { return _vsionFarLeft; }
            set { _vsionFarLeft = value; OnPropertyChanged(() => VisionFarLeft); }
        }

        public string VisionFarRight
        {
            get { return _vsionFarRight; }
            set { _vsionFarRight = value; OnPropertyChanged(() => VisionFarRight); }
        }

        public string VisionNearLeft
        {
            get { return _vsionNearLeft; }
            set { _vsionNearLeft = value; OnPropertyChanged(() => VisionNearLeft); }
        }

        public string VisionNearRight
        {
            get { return _vsionNearRight; }
            set { _vsionNearRight = value; OnPropertyChanged(() => VisionNearRight); }
        }

        public string BMirrorFarLeft
        {
            get { return _bMirrorFarLeft; }
            set { _bMirrorFarLeft = value; OnPropertyChanged(() => BMirrorFarLeft); }
        }

        public string BMirrorFarRight
        {
            get { return _bMirrorFarRight; }
            set { _bMirrorFarRight = value; OnPropertyChanged(() => BMirrorFarRight); }
        }

        public string BMirrorNearLeft
        {
            get { return _bMirrorNearLeft; }
            set { _bMirrorNearLeft = value; OnPropertyChanged(() => BMirrorNearLeft); }
        }

        public string BMirrorNearRight
        {
            get { return _bMirrorNearRight; }
            set { _bMirrorNearRight = value; OnPropertyChanged(() => BMirrorNearRight); }
        }

        public string PMirrorFarLeft
        {
            get { return _pMirrorFarLeft; }
            set { _pMirrorFarLeft = value; OnPropertyChanged(() => PMirrorFarLeft); }
        }

        public string PMirrorFarRight
        {
            get { return _pMirrorFarRight; }
            set { _pMirrorFarRight = value; OnPropertyChanged(() => PMirrorFarRight); }
        }

        public string PMirrorNearLeft
        {
            get { return _pMirrorNearLeft; }
            set { _pMirrorNearLeft = value; OnPropertyChanged(() => PMirrorNearLeft); }
        }

        public string PMirrorNearRight
        {
            get { return _pMirrorNearRight; }
            set { _pMirrorNearRight = value; OnPropertyChanged(() => PMirrorNearRight); }
        }

        public string AMirrorFarLeft
        {
            get { return _aMirrorFarLeft; }
            set { _aMirrorFarLeft = value; OnPropertyChanged(() => AMirrorFarLeft); }
        }

        public string AMirrorFarRight
        {
            get { return _aMirrorFarRight; }
            set { _aMirrorFarRight = value; OnPropertyChanged(() => AMirrorFarRight); }
        }

        public string AMirrorNearLeft
        {
            get { return _aMirrorNearLeft; }
            set { _aMirrorNearLeft = value; OnPropertyChanged(() => AMirrorNearLeft); }
        }

        public string AMirrorNearRight
        {
            get { return _aMirrorNearRight; }
            set { _aMirrorNearRight = value; OnPropertyChanged(() => AMirrorNearRight); }
        }

        public string OKFarLeft
        {
            get { return _oKFarLeft; }
            set { _oKFarLeft = value; OnPropertyChanged(() => OKFarLeft); }
        }

        public string OKFarRight
        {
            get { return _oKFarRight; }
            set { _oKFarRight = value; OnPropertyChanged(() => OKFarRight); }
        }

        public string OKNearLeft
        {
            get { return _oKNearLeft; }
            set { _oKNearLeft = value; OnPropertyChanged(() => OKNearLeft); }
        }

        public string OKNearRight
        {
            get { return _oKNearRight; }
            set { _oKNearRight = value; OnPropertyChanged(() => OKNearRight); }
        }

        public string DegreeFarLeft
        {
            get { return _degreeFarLeft; }
            set { _degreeFarLeft = value; OnPropertyChanged(() => DegreeFarLeft); }
        }

        public string DegreeFarRight
        {
            get { return _degreeFarRight; }
            set { _degreeFarRight = value; OnPropertyChanged(() => DegreeFarRight); }
        }

        public string DegreeNearLeft
        {
            get { return _degreeNearLeft; }
            set { _degreeNearLeft = value; OnPropertyChanged(() => DegreeNearLeft); }
        }

        public string DegreeNearRight
        {
            get { return _degreeNearRight; }
            set { _degreeNearRight = value; OnPropertyChanged(() => DegreeNearRight); }
        }

        public string DFarLeft
        {
            get { return _dFarLeft; }
            set { _dFarLeft = value; OnPropertyChanged(() => DFarLeft); }
        }

        public string DFarRight
        {
            get { return _dFarRight; }
            set { _dFarRight = value; OnPropertyChanged(() => DFarRight); }
        }

        public string DNearLeft
        {
            get { return _dNearLeft; }
            set { _dNearLeft = value; OnPropertyChanged(() => DNearLeft); }
        }

        public string DNearRight
        {
            get { return _dNearRight; }
            set { _dNearRight = value; OnPropertyChanged(() => DNearRight); }
        }

        public string MainEye
        {
            get { return _mainEye; }
            set { _mainEye = value; OnPropertyChanged(() => MainEye); }
        }

        public string MirrorModelFar
        {
            get { return _mirrorModelFar; }
            set { _mirrorModelFar = value; OnPropertyChanged(() => MirrorModelFar); }
        }

        public string MirrorModelNear
        {
            get { return _mirrorModelNear; }
            set { _mirrorModelNear = value; OnPropertyChanged(() => MirrorModelNear); }
        }

        public float MirrorModelFarAmount
        {
            get { return _mirrorModelFarAmount; }
            set { _mirrorModelFarAmount = value; OnPropertyChanged(() => MirrorModelFarAmount); }
        }

        public float MirrorModelNearAmount
        {
            get { return _mirrorModelNearAmount; }
            set { _mirrorModelNearAmount = value; OnPropertyChanged(() => MirrorModelNearAmount); }
        }

        public string BracketModelFar
        {
            get { return _bracketModelFar; }
            set { _bracketModelFar = value; OnPropertyChanged(() => BracketModelFar); }
        }

        public string BracketModelNear
        {
            get { return _bracketModelNear; }
            set { _bracketModelNear = value; OnPropertyChanged(() => BracketModelNear); }
        }

        public float BracketModelFarAmount
        {
            get { return _bracketModelFarAmount; }
            set { _bracketModelFarAmount = value; OnPropertyChanged(() => BracketModelFarAmount); }
        }

        public float BracketModelNearAmount
        {
            get { return _bracketModelNearAmount; }
            set { _bracketModelNearAmount = value; OnPropertyChanged(() => BracketModelNearAmount); }
        }

        public string AdeModel
        {
            get { return _adeModel; }
            set { _adeModel = value; OnPropertyChanged(() => AdeModel); }
        }

        public string CareProduct
        {
            get { return _careProduct; }
            set { _careProduct = value; OnPropertyChanged(() => CareProduct); }
        }

        public float AdeAmount
        {
            get { return _adeAmount; }
            set { _adeAmount = value; OnPropertyChanged(() => AdeAmount); }
        }

        public float TotalAmount
        {
            get { return _totalAmount; }
            set { _totalAmount = value; OnPropertyChanged(() => TotalAmount); }
        }

        public float AmountPaid
        {
            get { return _amountPaid; }
            set { _amountPaid = value; OnPropertyChanged(() => AmountPaid); }
        }

        public float AmountNotPaid
        {
            get { return _amountNotPaid; }
            set { _amountNotPaid = value; OnPropertyChanged(() => AmountNotPaid); }
        }

        public string OptometristA
        {
            get { return _optometristA; }
            set { _optometristA = value; OnPropertyChanged(() => OptometristA); }
        }

        public string OptometristB
        {
            get { return _optometristB; }
            set { _optometristB = value; OnPropertyChanged(() => OptometristB); }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; OnPropertyChanged(() => CreateDate); }
        }

        public int CreateDateYear
        {
            get { return CreateDate.Year; }
            set
            {
                CreateDate = new DateTime(value, _createDate.Month, _createDate.Day);
                OnPropertyChanged(() => CreateDateYear);
            }
        }

        public int CreateDateMonth
        {
            get { return CreateDate.Month; }
            set
            {
                CreateDate = new DateTime(_createDate.Year, value, _createDate.Day);
                OnPropertyChanged(() => CreateDateMonth);
            }
        }

        public int CreateDateDay
        {
            get { return CreateDate.Day; }
            set
            {
                CreateDate = new DateTime(_createDate.Year, _createDate.Month, value);
                OnPropertyChanged(() => CreateDateDay);
            }
        }

        public string Checker
        {
            get { return _checker; }
            set { _checker = value; OnPropertyChanged(() => Checker); }
        }

        public string Comments
        {
            get { return _comments; }
            set { _comments = value; OnPropertyChanged(() => Comments); }
        }

        private string _requirment;

        public string Requirment
        {
            get { return _requirment; }
            set { _requirment = value; OnPropertyChanged(() => Requirment); }
        }
        private string _lightCheck;

        public string LightCheck
        {
            get { return _lightCheck; }
            set { _lightCheck = value; OnPropertyChanged(() => LightCheck); }
        }
        private string _r1mmLeft;

        public string R1mmLeft
        {
            get { return _r1mmLeft; }
            set { _r1mmLeft = value; OnPropertyChanged(() => R1mmLeft); }
        }
        private string _r1DLeft;

        public string R1DLeft
        {
            get { return _r1DLeft; }
            set { _r1DLeft = value; OnPropertyChanged(() => R1DLeft); }
        }
        private string _r1AXLeft;

        public string R1AXLeft
        {
            get { return _r1AXLeft; }
            set { _r1AXLeft = value; OnPropertyChanged(() => R1AXLeft); }
        }
        private string _r2mmLeft;

        public string R2mmLeft
        {
            get { return _r2mmLeft; }
            set { _r2mmLeft = value; OnPropertyChanged(() => R2mmLeft); }
        }
        private string _r2DLeft;

        public string R2DLeft
        {
            get { return _r2DLeft; }
            set { _r2DLeft = value; OnPropertyChanged(() => R2DLeft); }
        }
        private string _r2AXLeft;

        public string R2AXLeft
        {
            get { return _r2AXLeft; }
            set { _r2AXLeft = value; OnPropertyChanged(() => R2AXLeft); }
        }
        private string _aVGmmLeft;

        public string AVGmmLeft
        {
            get { return _aVGmmLeft; }
            set { _aVGmmLeft = value; OnPropertyChanged(() => AVGmmLeft); }
        }
        private string _aVGDLeft;

        public string AVGDLeft
        {
            get { return _aVGDLeft; }
            set { _aVGDLeft = value; OnPropertyChanged(() => AVGDLeft); }
        }
        private string _aVGAXLeft;

        public string AVGAXLeft
        {
            get { return _aVGAXLeft; }
            set { _aVGAXLeft = value; OnPropertyChanged(() => AVGAXLeft); }
        }
        private string _cYLmmLeft;

        public string CYLmmLeft
        {
            get { return _cYLmmLeft; }
            set { _cYLmmLeft = value; OnPropertyChanged(() => CYLmmLeft); }
        }
        private string _cYLDLeft;

        public string CYLDLeft
        {
            get { return _cYLDLeft; }
            set { _cYLDLeft = value; OnPropertyChanged(() => CYLDLeft); }
        }
        private string _cYLAXLeft;

        public string CYLAXLeft
        {
            get { return _cYLAXLeft; }
            set { _cYLAXLeft = value; OnPropertyChanged(() => CYLAXLeft); }
        }
        private string _r1mmRight;

        public string R1mmRight
        {
            get { return _r1mmRight; }
            set { _r1mmRight = value; OnPropertyChanged(() => R1mmRight); }
        }
        private string _r1DRight;

        public string R1DRight
        {
            get { return _r1DRight; }
            set { _r1DRight = value; OnPropertyChanged(() => R1DRight); }
        }
        private string _r1AXRight;

        public string R1AXRight
        {
            get { return _r1AXRight; }
            set { _r1AXRight = value; OnPropertyChanged(() => R1AXRight); }
        }
        private string _r2mmRight;

        public string R2mmRight
        {
            get { return _r2mmRight; }
            set { _r2mmRight = value; OnPropertyChanged(() => R2mmRight); }
        }
        private string _r2DRight;

        public string R2DRight
        {
            get { return _r2DRight; }
            set { _r2DRight = value; OnPropertyChanged(() => R2DRight); }
        }
        private string _r2AXRight;

        public string R2AXRight
        {
            get { return _r2AXRight; }
            set { _r2AXRight = value; OnPropertyChanged(() => R2AXRight); }
        }
        private string _aVGmmRight;

        public string AVGmmRight
        {
            get { return _aVGmmRight; }
            set { _aVGmmRight = value; OnPropertyChanged(() => AVGmmRight); }
        }
        private string _aVGDRight;

        public string AVGDRight
        {
            get { return _aVGDRight; }
            set { _aVGDRight = value; OnPropertyChanged(() => AVGDRight); }
        }
        private string _aVGAXRight;

        public string AVGAXRight
        {
            get { return _aVGAXRight; }
            set { _aVGAXRight = value; OnPropertyChanged(() => AVGAXRight); }
        }
        private string _cYLmmRight;

        public string CYLmmRight
        {
            get { return _cYLmmRight; }
            set { _cYLmmRight = value; OnPropertyChanged(() => CYLmmRight); }
        }
        private string _cYLDRight;

        public string CYLDRight
        {
            get { return _cYLDRight; }
            set { _cYLDRight = value; OnPropertyChanged(() => CYLDRight); }
        }
        private string _cYLAXRight;

        public string CYLAXRight
        {
            get { return _cYLAXRight; }
            set { _cYLAXRight = value; OnPropertyChanged(() => CYLAXRight); }
        }

        private string _horLocationFar;

        public string HorLocationFar
        {
            get { return _horLocationFar; }
            set { _horLocationFar = value; OnPropertyChanged(() => HorLocationFar); }
        }
        private string _horLocationNear;

        public string HorLocationNear
        {
            get { return _horLocationNear; }
            set { _horLocationNear = value; OnPropertyChanged(() => HorLocationNear); }
        }
        private string _verLocationFar;

        public string VerLocationFar
        {
            get { return _verLocationFar; }
            set { _verLocationFar = value; OnPropertyChanged(() => VerLocationFar); }
        }
        private string _verLocationNear;

        public string VerLocationNear
        {
            get { return _verLocationNear; }
            set { _verLocationNear = value; OnPropertyChanged(() => VerLocationNear); }
        }
        private string _aCCal;

        public string ACCal
        {
            get { return _aCCal; }
            set { _aCCal = value; OnPropertyChanged(() => ACCal); }
        }
        private string _aCTD;

        public string ACTD
        {
            get { return _aCTD; }
            set { _aCTD = value; OnPropertyChanged(() => ACTD); }
        }
        private string _pRA;

        public string PRA
        {
            get { return _pRA; }
            set { _pRA = value; OnPropertyChanged(() => PRA); }
        }
        private string _nRA;

        public string NRA
        {
            get { return _nRA; }
            set { _nRA = value; OnPropertyChanged(() => NRA); }
        }
        private string _bCC;

        public string BCC
        {
            get { return _bCC; }
            set { _bCC = value; OnPropertyChanged(() => BCC); }
        }
        private string _rightAdjustWidth;

        public string RightAdjustWidth
        {
            get { return _rightAdjustWidth; }
            set { _rightAdjustWidth = value; OnPropertyChanged(() => RightAdjustWidth); }
        }
        private string _rightAdjustSensitivity;

        public string RightAdjustSensitivity
        {
            get { return _rightAdjustSensitivity; }
            set { _rightAdjustSensitivity = value; OnPropertyChanged(() => RightAdjustSensitivity); }
        }
        private string _leftAdjustWidth;

        public string LeftAdjustWidth
        {
            get { return _leftAdjustWidth; }
            set { _leftAdjustWidth = value; OnPropertyChanged(() => LeftAdjustWidth); }
        }
        private string _leftAdjustSensitivity;

        public string LeftAdjustSensitivity
        {
            get { return _leftAdjustSensitivity; }
            set { _leftAdjustSensitivity = value; OnPropertyChanged(() => LeftAdjustSensitivity); }
        }
        private string _bothAdjustWidth;

        public string BothAdjustWidth
        {
            get { return _bothAdjustWidth; }
            set { _bothAdjustWidth = value; OnPropertyChanged(() => BothAdjustWidth); }
        }
        private string _bothAdjustSensitivity;

        public string BothAdjustSensitivity
        {
            get { return _bothAdjustSensitivity; }
            set { _bothAdjustSensitivity = value; OnPropertyChanged(() => BothAdjustSensitivity); }
        }
        private string _checkWayAdjustWidth;

        public string CheckWayAdjustWidth
        {
            get { return _checkWayAdjustWidth; }
            set { _checkWayAdjustWidth = value; OnPropertyChanged(() => CheckWayAdjustWidth); }
        }
        private string _checkWayAdjustSensitivity;

        public string CheckWayAdjustSensitivity
        {
            get { return _checkWayAdjustSensitivity; }
            set { _checkWayAdjustSensitivity = value; OnPropertyChanged(() => CheckWayAdjustSensitivity); }
        }
        private string _inosculateFunction;

        public string InosculateFunction
        {
            get { return _inosculateFunction; }
            set { _inosculateFunction = value; OnPropertyChanged(() => InosculateFunction); }
        }
        private string _stereoFunction;

        public string StereoFunction
        {
            get { return _stereoFunction; }
            set { _stereoFunction = value; OnPropertyChanged(() => StereoFunction); }
        }
        private string _nPC;

        public string NPC
        {
            get { return _nPC; }
            set { _nPC = value; OnPropertyChanged(() => NPC); }
        }
        private string _chromaticVision;

        public string ChromaticVision
        {
            get { return _chromaticVision; }
            set { _chromaticVision = value; OnPropertyChanged(() => ChromaticVision); }
        }

        #region Override methods

        public override string ToString()
        {
            return string.Format("ID:{0}, Customer ID:{1};", Id, CustomerId);
        }

        #endregion
    }
}
