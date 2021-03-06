﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Core.DataModels
{


    #region Owner Petition
    public class OwnerPetitionInfoM
    {
        public OwnerPetitionInfoM()
        {
            ApplicantInfo = new OwnerPetitionApplicantInfoM();
            PropertyInfo = new OwnerPetitionPropertyInfoM();
            Verification = new VerificationM();
        }
        public VerificationM Verification { get; set; }
        private List<OwnerRentIncreaseReasonsM> _rentIncreaseReasons = new List<OwnerRentIncreaseReasonsM>();
        public int OwnerPetitionID { get; set; }
        public OwnerPetitionApplicantInfoM ApplicantInfo { get; set; }
        public OwnerPetitionPropertyInfoM PropertyInfo { get; set; }
        public bool bPetitionFiledByThirdParty { get; set; }
        public bool bAgreeToCityMediation { get; set; }
        public int PetitionFiledBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public List<OwnerRentIncreaseReasonsM> RentIncreaseReasons
        {
            get
            {
                return _rentIncreaseReasons;
            }
            set
            {
                _rentIncreaseReasons = value;
            }
        }
       public int CustomerID { get; set; }
       public DateTime VerificationDate
       {
           get
           {
               return DateTime.Now;
           }
       }
       public string CustomerIdentityKey { get; set; }
    }

    public class OwnerPetitionApplicantInfoM
    {
        private List<NumberRangeForUnitsM> _rangeOfUnits = new List<NumberRangeForUnitsM>();
        public OwnerPetitionApplicantInfoM()
        {
            ThirdPartyUser = new UserInfoM();
            ApplicantUserInfo = new UserInfoM();
            BuildingAcquiredDate = new CustomDate();
        }
        private bool _bThirdPartyRepresentation = false;
        public int OwnerPetitionApplicantInfoID { get; set; }
        public UserInfoM ApplicantUserInfo { get; set; }
        public bool bApplicantEmailNotification { get; set; }
        public bool bApplicantMailNotification { get; set; }
        public bool bThirdPartyRepresentation
        {
            get
            {
                return _bThirdPartyRepresentation;
            }
            set
            {
                _bThirdPartyRepresentation = value;
            }
        }
        public UserInfoM ThirdPartyUser { get; set; }
        public bool ThirdPartyEmailNotification { get; set; }
        public bool ThirdPartyMailNotification { get; set; }
        public bool bBusinessLicensePaid { get; set; }
        public string BusinessLicenseNumber { get; set; }
        public bool bRentAdjustmentProgramFeePaid { get; set; }
        public CustomDate BuildingAcquiredDate { get; set; }
        public int? NumberOfUnits { get; set; }
        public bool bMoreThanOneStreetOnParcel { get; set; }
        public int CustomerID { get; set; }
        public bool bPetitionFiled { get; set; }
        public string RAPFee { get; set; } 
        public int NumberOfUnitsRangeID { get; set; }
    }

    public class OwnerPetitionPropertyInfoM
        {
        public OwnerPetitionPropertyInfoM()
        {
            MovedInDate = new CustomDate();
            RAPNoticeGivenDate = new CustomDate();
        }
        private List<OwnerPetitionTenantInfoM> _tenantInfo = new List<OwnerPetitionTenantInfoM>();
        private List<OwnerPetitionRentalIncrementInfoM> _rentalInfo = new List<OwnerPetitionRentalIncrementInfoM>();
        private List<UnitTypeM> _unitTypes = new List<UnitTypeM>();

        public int OwnerPropertyID { get; set; }
        public int UnitTypeID { get; set; }
        public CustomDate MovedInDate { get; set; }
        public decimal? InitialRent { get; set; }
        public int? RAPNoticeStatusID { get; set; }
        public CustomDate RAPNoticeGivenDate { get; set; }
        public bool CurrentOnRent { get; set; }
        public int CustomerID { get; set; }
        public bool bPetitionFiled { get; set; }
        public List<OwnerPetitionTenantInfoM> TenantInfo
        {
            get
            {
                return _tenantInfo;
            }
            set
            {
                _tenantInfo = value;
            }
        }
        public List<OwnerPetitionRentalIncrementInfoM> RentalInfo
        {
            get
            {
                return _rentalInfo;
            }
            set
            {
                _rentalInfo = value;
            }
        }
        public List<UnitTypeM> UnitTypes
        {
            get
            {
                return _unitTypes;
            }
            set
            {
                _unitTypes = value;
            }
        }



    }

    public class OwnerPetitionTenantInfoM
    {
        public OwnerPetitionTenantInfoM()
        {
            TenantUserInfo = new UserInfoM();
        }

        public int TenantInfoID { get; set; }
        public int OwnerPropertyID { get; set; }
        public UserInfoM TenantUserInfo { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class OwnerRentIncreaseReasonsM
    {
        private bool _isSelected = false;
        public int ReasonID { get; set; }
        public string ReasonDescription { get; set; }
        public string ToolTip { get; set; }
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
            }
        }
    }

    public class OwnerPetitionRentalIncrementInfoM
    {
        public OwnerPetitionRentalIncrementInfoM()
        {
            RentIncreaseNoticeDate = new CustomDate();
            RentIncreaseEffectiveDate = new CustomDate();
        }
        public int RentalIncreaseInfoID { get; set; }
        public int OwnerPropertyID { get; set; }
        public bool bRentIncreaseNoticeGiven { get; set; }
        public CustomDate RentIncreaseNoticeDate { get; set; }
        public CustomDate RentIncreaseEffectiveDate { get; set; }
        public decimal? RentIncreasedFrom { get; set; }
        public decimal? RentIncreasedTo { get; set; }
        public bool isDeleted { get; set; }

    }
    #endregion

    #region Owner response
    public class OwnerResponseInfoM
    {
        public OwnerResponseInfoM()
        {
            ApplicantInfo = new OwnerResponseApplicantInfoM();
            PropertyInfo = new OwnerResponsePropertyInfoM();
            Verification = new VerificationM();
        }
        public int OwnerResponseID { get; set; }
        public OwnerResponseApplicantInfoM ApplicantInfo { get; set; }
        public OwnerResponsePropertyInfoM PropertyInfo { get; set; }
        public bool bAgreeToCityMediation { get; set; }
        public DateTime VerificationDate
        {
            get
            {
                return DateTime.Now;
            }
        }
        public string CustomerIdentityKey { get; set; }
        public VerificationM Verification { get; set; }
    }

    public class OwnerResponseApplicantInfoM
    {
        
        public OwnerResponseApplicantInfoM()
        {
            ThirdPartyUser = new UserInfoM();
            ApplicantUserInfo = new UserInfoM();
            BuildingAcquiredDate = new CustomDate();
        }
        private bool _bThirdPartyRepresentation = false;
        public int OwnerResponseApplicantInfoID { get; set; }
        public UserInfoM ApplicantUserInfo { get; set; }
        
        public bool bThirdPartyRepresentation
        {
            get
            {
                return _bThirdPartyRepresentation;
            }
            set
            {
                _bThirdPartyRepresentation = value;
            }
        }
        public UserInfoM ThirdPartyUser { get; set; }
        public bool ThirdPartyEmailNotification { get; set; }
        public bool ThirdPartyMailNotification { get; set; }
        public bool bBusinessLicensePaid { get; set; }
        public string BusinessLicenseNumber { get; set; }
        public bool bRentAdjustmentProgramFeePaid { get; set; }
        public CustomDate BuildingAcquiredDate { get; set; }
        public int? NumberOfUnits { get; set; }
        public bool bMoreThanOneStreetOnParcel { get; set; }
        public int CustomerID { get; set; }
        public bool bPetitionFiled { get; set; }
        public string RAPFee { get; set; }
        public string CaseRespondingTo { get; set; }
        public int NumberOfUnitsRangeID { get; set; }
       
    }

    public class OwnerResponsePropertyInfoM
    {

        public OwnerResponsePropertyInfoM()
        {
            MovedInDate = new CustomDate();
            RAPNoticeGivenDate = new CustomDate();
            RAPNoticeToRAPOfficeDate = new CustomDate();
            Rent = new OwnerResponseRentalIncrementInfoM();
        }
        private List<OwnerPetitionTenantInfoM> _tenantInfo = new List<OwnerPetitionTenantInfoM>();
        private List<OwnerResponseRentalIncrementInfoM> _rentalInfo = new List<OwnerResponseRentalIncrementInfoM>();
        private List<UnitTypeM> _unitTypes = new List<UnitTypeM>();

        public int OwnerPropertyID { get; set; }
        public int UnitTypeID { get; set; }
        public CustomDate MovedInDate { get; set; }
        public decimal? InitialRent { get; set; }
        public int? RAPNoticeStatusID { get; set; }
        public CustomDate RAPNoticeGivenDate { get; set; }
        public bool CurrentOnRent { get; set; }
        public bool bCapitalImprovementIncrease { get; set; }
        public bool bCaptialImprovementContested { get; set; }
        public string CaseNumbers { get; set; }
        public bool bRAPNoticeToRAPOffice { get; set; }
        public CustomDate RAPNoticeToRAPOfficeDate { get; set; }
        public int CustomerID { get; set; }
        public bool bPetitionFiled { get; set; }
        public bool bExemptFromRentAdjustment { get; set; }
        public bool bPriorTenantLeftAfteQuitNotice { get; set; }
        public string PriorTenantLeftAfteQuitNoticeExplenation { get; set; }
        public bool bPriorTenantLeftAfteRentIncreaseNotice { get; set; }
        public string PriorTenantLeftAfteRentIncreaseNoticeExplenation { get; set; }
        public bool bPriorTenantEvicted { get; set; }
        public string PriorTenantEvictedExplenation { get; set; }
        public bool bOutstandingViolations { get; set; }
        public string OutstandingViolationsExplenation { get; set; }
        public bool bSingleFamilyUnitOrCondominium { get; set; }
        public string SingleFamilyUnitOrCondominiumExplenation { get; set; }
        public bool bRoommatesWhenMoviedIN { get; set; }
        public string RoommatesWhenMoviedINExplenation { get; set; }
        public bool bUnitPruchased { get; set; }
        public string UnitPruchasedExplenation { get; set; }
        public string PurchasedFrom { get; set; }
        public bool bEntireBuildingPurchased { get; set; }
        public string EntireBuildingPurchasedExplenation { get; set; }
        public bool bRentControlledOtherThanRAP { get; set; }
        public bool bUnitNewlyConstructed { get; set; }
        public bool bTenantWasResidentOfHotelWhileFiling { get; set; }
        public bool bUnitWasRehabilitated { get; set; }
        public bool bUnitIsAccommodation { get; set; }
        public bool bHasUnitOccupiedByOwner { get; set; }
        public OwnerResponseRentalIncrementInfoM Rent { get; set; }
        public List<OwnerPetitionTenantInfoM> TenantInfo
        {
            get
            {
                return _tenantInfo;
            }
            set
            {
                _tenantInfo = value;
            }
        }
        public List<OwnerResponseRentalIncrementInfoM> RentalInfo
        {
            get
            {
                return _rentalInfo;
            }
            set
            {
                _rentalInfo = value;
            }
        }
        public List<UnitTypeM> UnitTypes
        {
            get
            {
                return _unitTypes;
            }
            set
            {
                _unitTypes = value;
            }
        }

    }

    public class OwnerResponseRentalIncrementInfoM
    {
        public OwnerResponseRentalIncrementInfoM()
        {
            RentIncreaseNoticeDate = new CustomDate();
            RentIncreaseEffectiveDate = new CustomDate();
        }
        private List<OwnerRentIncreaseReasonsM> _rentIncreaseReasons = new List<OwnerRentIncreaseReasonsM>();
        public int RentalIncreaseInfoID { get; set; }
        public int OwnerPropertyID { get; set; }
        public bool bRentIncreaseNoticeGiven { get; set; }
        public CustomDate RentIncreaseNoticeDate { get; set; }
        public CustomDate RentIncreaseEffectiveDate { get; set; }
        public decimal? RentIncreasedFrom { get; set; }
        public decimal? RentIncreasedTo { get; set; }
        public bool isDeleted { get; set; }
        public List<OwnerRentIncreaseReasonsM> RentIncreaseReasons
        {
            get
            {
                return _rentIncreaseReasons;
            }
            set
            {
                _rentIncreaseReasons = value;
            }
        }

    }

    #endregion

}

