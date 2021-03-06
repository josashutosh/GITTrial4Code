﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP.Core.DataModels
{
    
    public class CustomerInfo
    {
        public CustomerInfo()
        {
            thirdpartyDetails = new ThirdPartyDetails();
            User = new UserInfoM();
            MailingAddress = new MailingAddress_M();
        }
        public string AccountType { get; set; }
        public int selected { get; set; }
        public int custID { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public bool EmailNotificationFlag { get; set; }
        public bool MailNotificationFlag { get; set; }
        public ThirdPartyDetails thirdpartyDetails { get; set; }
        public UserInfoM User { get; set; }
        public MailingAddress_M MailingAddress { get; set; }
        public string CustomerIdentityKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsSameMailingAddress { get; set; }
    }
    public class MailingAddress_M
    {
        public MailingAddress_M()
        {
            State = new StateM();
            City = "Oakland";
        }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public StateM State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }

    }
    public class CityUserAccount_M
    {
        public AccountType AccountType { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int EmployeeID { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string OfficeLocation { get; set; }
        public string OfficePhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public bool IsHearingOfficer { get; set; }
        public bool IsAnalyst { get; set; }
        public bool IsNonRAPStaff { get; set; }
        public bool IsAdminAssistant { get; set; }
        public bool IsCityAdmin { get; set; }
        public int SelectedRole { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class StateM
    {
        public StateM()
        {
            StateID = 8;
            StateCode = "CA";
            StateName = "California";
        }
        public int StateID { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
    }
    public class Rent
    {

        public int id { get; set; }
        public string name { get; set; }
    }

    // To be removed ThirdPartyInfoM created to server this purpose
    public class ThirdPartyDetails
    {
        public int ThirdPartyRepresentationID { get; set; }
        public int custID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
    }
    public class ThirdPartyInfoM
    {
        public ThirdPartyInfoM()
        {
            ThirdPartyUser = new UserInfoM();
        }
        public int CustomerID { get; set; }
        public UserInfoM ThirdPartyUser { get; set; }
        public bool EmailNotification { get; set; }
        public bool MailNotification { get; set; }
    }
    public class TranslationServiceInfoM
    {
        public int UserID { get; set; }
        public bool IsTranslatorRequired { get; set; }
        public string TranslationLanguage { get; set; }
    }
    public class Collaborator
    {
        public Collaborator()
        {
            collaboratorDetails = new List<CustomerInfo>();
        }
        public int custID { get; set; }
        public List<CustomerInfo> collaboratorDetails { get; set; }
    }
    public class CollaboratorAccessM
    {
        public CollaboratorAccessM()
        {
            caseInfo = new List<CaseInfoM>();
        }
        public int custID { get; set; }
        public int collaboratorCustID { get; set; }
        public List<CaseInfoM> caseInfo { get; set; }
    }
    public class PetitionDetails
    {
        public int PetitionID { get; set; }
        public string Desc { get; set; }

    }
    public class LoginInfo
    {
        public string email { get; set; }
        public string Password { get; set; }

    }

    public class SearchResult
    {
        public SearchResult()
        {
            List = new List<SearchResultCustomerInfo>();
        }
        public List<SearchResultCustomerInfo> List;
        public string SortBy;
        public bool SortReverse;
        public int PageSize;
        public int CurrentPage;
        public int TotalCount;
    }
    public class SearchResultCustomerInfo
    {
        public string AccountType { get; set; }
        public int custID { get; set; }
        public string email { get; set; }
        public string Name { get; set; }
        public int RankNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ResAddressLine1 { get; set; }
        public string ResAddressLine2 { get; set; }
        public string ResCity { get; set; }
        public string ResStateCode { get; set; }
        public string ResZip { get; set; }
        public string ResPhone { get; set; }
        public bool bMailingAddress {get;set;}
        public string MailAddressLine1 { get; set; }
        public string MailAddressLine2 { get; set; }
        public string MailCity { get; set; }
        public string MailStateCode { get; set; }
        public string MailZip { get; set; }
        public string MailPhone { get; set; }
    }

    public class SearchCaseResult
    {
        public SearchCaseResult()
        {
            List = new List<SearchResultCaseInfo>();
        }
        public List<SearchResultCaseInfo> List;
        public string SortBy;
        public bool SortReverse;
        public int PageSize;
        public int CurrentPage;
        public int TotalCount;
    }    
    public class SearchResultCaseInfo
    {
        public int RankNo { get; set; }
        public int C_ID {get;set;}
        public string CaseID {get;set;}
        public int ActivityID {get;set;}
        public string ActivityName {get;set;}
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Analyst {get;set;}
        public string HearingOfficer {get;set;}
        public string TenantName { get; set; }
        public string ApplicantAddressLine1 {get;set;}
        public string ApplicantAddressLine2 {get;set;}
        public string ApplicantCity {get;set;}
        public int ApplicantStateID {get;set;}
        public string ApplicantStateCode {get;set;}
        public string ApplicantZip {get;set;}
        public string OwnerName { get; set; }
        public string OPOwnerName { get; set; }
        public string OPAddressLine1 { get; set; }
        public string OPAddressLine2 { get; set; }
        public string OPStateCode { get; set; }
        public string OPOwnerZip { get; set; }
        public string OPCity { get; set; }
        public string OwnerTenantName { get; set; }
        public int PetitionCategoryID { get; set; }
    }
}
