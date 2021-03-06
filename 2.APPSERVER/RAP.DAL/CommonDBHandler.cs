﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using RAP.Core.Common;
using RAP.Core.DataModels;

namespace RAP.DAL
{
    public class CommonDBHandler : ICommonDBHandler
    {
        private readonly string _connString;
        private bool _logToDatabase;
       
        public CommonDBHandler()
        {
            _connString = ConfigurationManager.AppSettings["RAPDBConnectionString"];
            _logToDatabase = string.IsNullOrEmpty(ConfigurationManager.AppSettings["logToDatabase"]) ? false : ((ConfigurationManager.AppSettings["logToDatabase"] == "true" ? true : false));
        }

        /// <summary>
        /// Logs error details to the database
        /// </summary>
        /// <returns></returns>

        public void SaveErrorLog(OperationStatus status)
        {

            try
            {
                if (_logToDatabase)
                {
                    using (CommonDataContext db = new CommonDataContext(_connString))
                    {
                        ErrorLog error = new ErrorLog();
                        error.ErrorNumber = status.StatusCode;
                        error.ErrorMessage = status.StatusMessage;
                        error.ErrorMessageDetails = status.StatusDetails;
                        error.CreatedDate = DateTime.Now;
                        db.ErrorLogs.InsertOnSubmit(error);
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Gets the data needed to to display on the tenant petition form
        /// </summary>
        /// <returns></returns>

        public ReturnResult<UserInfoM> SaveUserInfo(UserInfoM userInfo)
        {
            ReturnResult<UserInfoM> result = new ReturnResult<UserInfoM>();
            try
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "DAL SaveUserInfo started");
                using (CommonDataContext db = new CommonDataContext(_connString))
                {
                    //EditUserInfo
                    if (userInfo.UserID != 0)
                    {
                        var userDB = db.UserInfos.Where(x => x.UserID == userInfo.UserID).FirstOrDefault();
                        userDB.FirstName = userInfo.FirstName;
                        userDB.LastName = userInfo.LastName;
                        userDB.BusinessName = userInfo.BusinessName;
                        userDB.AddressLine1 = userInfo.AddressLine1;
                        userDB.AddressLine2 = userInfo.AddressLine2;
                        userDB.City = userInfo.City;
                        userDB.StateID = userInfo.State.StateID;
                        userDB.Zip = userInfo.Zip;
                        userDB.PhoneNumber = userInfo.PhoneNumber;
                        userDB.ContactEmail = userInfo.Email;
                        userDB.CreatedDate = DateTime.Now;

                        db.SubmitChanges();

                        System.Diagnostics.EventLog.WriteEntry("Application", "DAL EditUserInfo completed");
                        result.result = userInfo;
                        result.status = new OperationStatus() { Status = StatusEnum.Success };
                        return result;
                    }
                    var user = db.UserInfos.Where(x => (x.FirstName == userInfo.FirstName
                                                            && x.LastName == userInfo.LastName
                                                            && x.AddressLine1 == userInfo.AddressLine1
                                                            && x.AddressLine2 == userInfo.AddressLine2
                                                            && x.City == userInfo.City
                                                            && x.StateID == userInfo.State.StateID
                                                            && x.Zip == userInfo.Zip)).FirstOrDefault();

                    if (user != null)
                    {
                        userInfo.UserID = user.UserID;
                    }
                    else
                    {
                        UserInfo userInfoDB = new UserInfo();
                        userInfoDB.FirstName = userInfo.FirstName;
                        userInfoDB.LastName = userInfo.LastName;
                        userInfoDB.BusinessName = userInfo.BusinessName;
                        userInfoDB.AddressLine1 = userInfo.AddressLine1;
                        userInfoDB.AddressLine2 = userInfo.AddressLine2;
                        userInfoDB.City = userInfo.City;
                        userInfoDB.StateID = userInfo.State.StateID;
                        userInfoDB.Zip = userInfo.Zip;
                        userInfoDB.PhoneNumber = userInfo.PhoneNumber;
                        userInfoDB.ContactEmail = userInfo.Email;
                        userInfoDB.CreatedDate = DateTime.Now;

                        db.UserInfos.InsertOnSubmit(userInfoDB);
                        db.SubmitChanges();
                        userInfo.UserID = userInfoDB.UserID;
                    }
                    System.Diagnostics.EventLog.WriteEntry("Application", "DAL SaveUserInfo completed");
                    result.result = userInfo;
                    result.status = new OperationStatus() { Status = StatusEnum.Success };
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "Error : " + ex.Message + "| StackTrace" + ex.StackTrace.ToString());
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }
        /// <summary>
        /// Edits the data needed to to display on the tenant petition form
        /// </summary>
        /// <returns></returns>

        public ReturnResult<UserInfoM> EditUserInfo(UserInfoM userInfo)
        {
            ReturnResult<UserInfoM> result = new ReturnResult<UserInfoM>();
            try
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "DAL SaveUserInfo started");
                using (CommonDataContext db = new CommonDataContext(_connString))
                {
                    var userInfoDB = db.UserInfos.Where(x => (x.UserID == userInfo.UserID)).FirstOrDefault();

                    userInfoDB.FirstName = userInfo.FirstName;
                    userInfoDB.LastName = userInfo.LastName;
                    userInfoDB.BusinessName = userInfo.BusinessName;
                    userInfoDB.AddressLine1 = userInfo.AddressLine1;
                    userInfoDB.AddressLine2 = userInfo.AddressLine2;
                    userInfoDB.City = userInfo.City;
                    userInfoDB.StateID = userInfo.State.StateID;
                    userInfoDB.Zip = userInfo.Zip;
                    userInfoDB.PhoneNumber = userInfo.PhoneNumber;
                    userInfoDB.ContactEmail = userInfo.Email;
                    db.SubmitChanges();
                }
                System.Diagnostics.EventLog.WriteEntry("Application", "DAL SaveUserInfo completed");
                result.result = userInfo;
                result.status = new OperationStatus() { Status = StatusEnum.Success };
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "Error : " + ex.Message + "| StackTrace" + ex.StackTrace.ToString());
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }
        public ReturnResult<UserInfoM> GetUserInfo(int UserId)
        {
            ReturnResult<UserInfoM> result = new ReturnResult<UserInfoM>();
            UserInfoM _userinfo = new UserInfoM();
            try
            {
                using (CommonDataContext db = new CommonDataContext(_connString))
                {
                    var userinfo = db.UserInfos.Where(x => x.UserID == UserId).FirstOrDefault();
                    //.Select(c => new UserInfoM()
                    //{
                    //    UserID = c.UserID,
                    //    FirstName = c.FirstName,
                    //    LastName = c.LastName,
                    //    AddressLine1 = c.AddressLine1,
                    //    AddressLine2 = c.AddressLine2,
                    //    City = c.City,
                    //    PhoneNumber = c.PhoneNumber,
                    //    State.StateID = c.State.SID,
                    //    Zip = c.Zip,
                    //    Email = c.ContactEmail,
                    //})

                    if (userinfo != null)
                    {


                        _userinfo.UserID = userinfo.UserID;
                        _userinfo.FirstName = userinfo.FirstName;
                        _userinfo.LastName = userinfo.LastName;
                        _userinfo.BusinessName = userinfo.BusinessName;
                        _userinfo.AddressLine1 = userinfo.AddressLine1;
                        _userinfo.AddressLine2 = userinfo.AddressLine2;
                        _userinfo.City = userinfo.City;
                        _userinfo.PhoneNumber = userinfo.PhoneNumber;
                        _userinfo.State.StateID = userinfo.StateID;
                        _userinfo.Zip = userinfo.Zip;
                        _userinfo.Email = userinfo.ContactEmail;
                        _userinfo.IsAPNAddress = Convert.ToBoolean(userinfo.bParcelAddress);                  

                    }
                    var state = db.States.Where(x => x.StateID == _userinfo.State.StateID).FirstOrDefault();
                    _userinfo.State.StateName = state.StateName;
                    _userinfo.State.StateCode = state.StateCode;

                    result.result = _userinfo;
                    result.status = new OperationStatus() { Status = StatusEnum.Success };
                    return result;
                }
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }

        /// <summary>
        /// Update the APN Address
        /// </summary>
        /// <returns></returns>
        public ReturnResult<APNAddress> UpdateAPNAddress(APNAddress apnAddress)
        {
            ReturnResult<APNAddress> result = new ReturnResult<APNAddress>();
            try
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "DAL APNAddress started");
                using (CommonDataContext db = new CommonDataContext(_connString))
                {                   
                    
                    var parcelDB = db.ParcelAddresses.Where(x => x.UserID == apnAddress.UserID).FirstOrDefault();

                    if (parcelDB != null)
                    {
                        parcelDB.AddressLine1 = apnAddress.AddressLine1;
                        parcelDB.AddressLine2 = apnAddress.AddressLine2;
                        parcelDB.City = apnAddress.City;
                        parcelDB.Zip = apnAddress.Zip;
                        parcelDB.APNNumber = apnAddress.APNNumber;

                        db.SubmitChanges();
                    }
                    else
                    {
                        ParcelAddress parcelAddressDB = new ParcelAddress();
                        parcelAddressDB.AddressLine1 = apnAddress.AddressLine1;
                        parcelAddressDB.AddressLine2 = apnAddress.AddressLine2;
                        parcelAddressDB.City = apnAddress.City;
                        parcelAddressDB.Zip = apnAddress.Zip;
                        parcelAddressDB.APNNumber = apnAddress.APNNumber;
                        parcelAddressDB.UserID = apnAddress.UserID;

                        db.ParcelAddresses.InsertOnSubmit(parcelAddressDB);
                        db.SubmitChanges();
                    }
                    var UserInfodb = db.UserInfos.Where(x => x.UserID == apnAddress.UserID).FirstOrDefault();
                    if (UserInfodb != null)
                    {
                        UserInfodb.bParcelAddress = true;
                        db.SubmitChanges();
                    }
                    System.Diagnostics.EventLog.WriteEntry("Application", "DAL APNAddress completed");
                    result.result = apnAddress;
                    result.status = new OperationStatus() { Status = StatusEnum.Success };
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "Error : " + ex.Message + "| StackTrace" + ex.StackTrace.ToString());
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }

        public ReturnResult<APNAddress> GetAPNAddress(int UserID)
        {
            ReturnResult<APNAddress> result = new ReturnResult<APNAddress>();
            try
            {
                APNAddress apnAddress = new APNAddress();
                System.Diagnostics.EventLog.WriteEntry("Application", "DAL APNAddress started");
                using (CommonDataContext db = new CommonDataContext(_connString))
                {

                    var parcelDB = db.ParcelAddresses.Where(x => x.UserID == UserID).FirstOrDefault();

                    if (parcelDB != null)
                    {
                        apnAddress.AddressLine1 = parcelDB.AddressLine1;
                        apnAddress.AddressLine2 = parcelDB.AddressLine2;
                        apnAddress.City = parcelDB.City;
                        apnAddress.Zip = parcelDB.Zip;
                        apnAddress.APNNumber = parcelDB.APNNumber;
                        apnAddress.UserID = UserID;
                    }

                    System.Diagnostics.EventLog.WriteEntry("Application", "DAL APNAddress completed");
                    result.result = apnAddress;
                    result.status = new OperationStatus() { Status = StatusEnum.Success };
                    return result;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "Error : " + ex.Message + "| StackTrace" + ex.StackTrace.ToString());
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }

        /// <summary>
        /// Coverts Datetime to CustomDate
        /// </summary>
        /// <param name="DatabaseDate"></param>
        /// <returns></returns>
        public CustomDate GetDateFromDatabase(DateTime DatabaseDate)
        {
            try
            {
                if (DatabaseDate.Year != 1)
                {
                    CustomDate FrontEndDate = new CustomDate();
                    FrontEndDate.Day = DatabaseDate.Day;
                    FrontEndDate.Month = DatabaseDate.Month;
                    FrontEndDate.Year = DatabaseDate.Year;
                    return FrontEndDate;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ReturnResult<DocumentM> SaveDocument(DocumentM doc)
        {
            ReturnResult<DocumentM> result = new ReturnResult<DocumentM>();
            try
            {
                if (doc != null)
                {
                    using (CommonDataContext db = new CommonDataContext(_connString))
                    {
                        Document document = new Document();
                        document.DocName = doc.DocName;
                        document.DocTitle = doc.DocTitle;
                        document.DocThirdPartyID = doc.DocThirdPartyID;
                        if (doc.CustomerID > 0)
                        {
                            document.CustomerID = doc.CustomerID;
                        }
                        if (doc.CityUserID > 0)
                        {
                            document.CityUserID = doc.CityUserID;
                        }
                        document.DocCategory = doc.DocCategory;
                        document.DocDescription = string.IsNullOrEmpty(doc.DocDescription) ? null : doc.DocDescription;
                        document.IsPetitionFiled = false;
                        document.MimeType = doc.MimeType;
                        document.CreatedDate = DateTime.Now;
                        db.Documents.InsertOnSubmit(document);
                        db.SubmitChanges();
                        doc.DocID = document.DocID;
                    }
                    result.result = doc;
                }
                result.status = new OperationStatus() { Status = StatusEnum.Success };
                return result;
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }

        public ReturnResult<bool> PetitionFiledActivity(int C_ID, int CaseFileBy, int ActivityID, int StatusID)
        {
            ReturnResult<bool> result = new ReturnResult<bool>();
            try
            {
                using (DashboardDataContext db = new DashboardDataContext(ConfigurationManager.AppSettings["RAPDBConnectionString"]))
                {
                    string errorMessage = "";
                    int? errorCode = 0;
                    //TBD
                    int returnCode = db.USP_NewActivityStatus_Save(ActivityID, StatusID,
                                     C_ID, "", DateTime.Now, CaseFileBy, 3, null, null, ref errorMessage, ref errorCode);

                    if (errorCode != 0)
                    {
                        result.result = false;
                        result.status = new OperationStatus() { Status = StatusEnum.DatabaseMessage, StatusMessage = errorMessage };
                        return result;
                    }
                }
                result.status = new OperationStatus() { Status = StatusEnum.Success };
                return result;
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }

        public ReturnResult<bool> MailSentActivity(int C_ID, int SentBy, int ActivityID, int NotificationID, int NotificationType)
        {
            ReturnResult<bool> result = new ReturnResult<bool>();
            try
            {
                using (DashboardDataContext db = new DashboardDataContext(ConfigurationManager.AppSettings["RAPDBConnectionString"]))
                {
                    string errorMessage = "";
                    int? errorCode = 0;
                    //TBD
                    int returnCode = db.USP_NewActivityStatus_Save(ActivityID, (int)StatusDefaults.NotificationSent,
                                     C_ID, "", DateTime.Now, SentBy, 1, NotificationID, NotificationType, ref errorMessage, ref errorCode);

                    if (errorCode != 0)
                    {
                        result.result = false;
                        result.status = new OperationStatus() { Status = StatusEnum.DatabaseMessage, StatusMessage = errorMessage };
                        return result;
                    }
                }
                result.status = new OperationStatus() { Status = StatusEnum.Success };
                return result;
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }
        public ReturnResult<List<DocumentM>> GetDocuments(int CustmerID, bool isPetitiofiled, string docTitle = null)
        {
            ReturnResult<List<DocumentM>> result = new ReturnResult<List<DocumentM>>();
            List<DocumentM> docs = new List<DocumentM>();
            try
            {

                using (CommonDataContext db = new CommonDataContext(_connString))
                {

                    if (string.IsNullOrEmpty(docTitle))
                    {
                        var _documents = db.Documents.Where(r => r.CustomerID == CustmerID && r.IsPetitionFiled == isPetitiofiled);
                        if (_documents != null)
                        {
                            foreach (var item in _documents)
                            {
                                DocumentM doc = new DocumentM();
                                doc.C_ID = item.C_ID;
                                doc.CustomerID =(item.CustomerID != null) ? Convert.ToInt32(item.CustomerID) : 0;
                                doc.CityUserID = (item.CityUserID != null) ? Convert.ToInt32(item.CityUserID) : 0;
                                doc.DocCategory = item.DocCategory;
                                doc.DocName = item.DocName;
                                doc.DocID = item.DocID;
                                doc.DocThirdPartyID = item.DocThirdPartyID;
                                doc.DocDescription = item.DocDescription;
                                doc.DocTitle = item.DocTitle;
                                doc.MimeType = item.MimeType;
                                doc.IsPetitonFiled = (bool)item.IsPetitionFiled;
                                doc.isUploaded = true;
                                docs.Add(doc);
                            }
                        }
                    }
                    else
                    {
                        var _documents = db.Documents.Where(r => r.CustomerID == CustmerID && r.IsPetitionFiled == isPetitiofiled && r.DocTitle == docTitle);
                        if (_documents != null)
                        {
                            foreach (var item in _documents)
                            {
                                DocumentM doc = new DocumentM();                             
                                doc.C_ID = item.C_ID;
                                doc.CustomerID =(item.CustomerID != null) ? Convert.ToInt32(item.CustomerID) : 0;
                                doc.CityUserID = (item.CityUserID != null) ? Convert.ToInt32(item.CityUserID) : 0;
                                doc.DocCategory = item.DocCategory;
                                doc.DocName = item.DocName;
                                doc.DocID = item.DocID;
                                doc.DocThirdPartyID = item.DocThirdPartyID;
                                doc.DocDescription = item.DocDescription;
                                doc.DocTitle = item.DocTitle;
                                doc.MimeType = item.MimeType;
                                doc.IsPetitonFiled = (bool)item.IsPetitionFiled;
                                doc.isUploaded = true;
                                docs.Add(doc);
                            }
                        }
                    }

                }
                result.result = docs;
                result.status = new OperationStatus() { Status = StatusEnum.Success };
                return result;
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }

        public ReturnResult<List<DocumentM>> GetCaseDocuments(int c_id)
        {
            ReturnResult<List<DocumentM>> result = new ReturnResult<List<DocumentM>>();
            List<DocumentM> docs = new List<DocumentM>();
            try
            {
                using (CommonDataContext db = new CommonDataContext(_connString))
                {
                    var _documents = db.Documents.Where(r => r.C_ID == c_id && r.IsPetitionFiled == true);
                        if (_documents != null)
                        {
                            foreach (var item in _documents)
                            {
                                DocumentM doc = new DocumentM();
                                doc.C_ID = item.C_ID;                                                        
                                doc.DocCategory = item.DocCategory;
                                doc.DocName = item.DocName;
                                doc.DocID = item.DocID;
                                doc.DocThirdPartyID = item.DocThirdPartyID;
                                doc.DocDescription = item.DocDescription;
                                doc.DocTitle = item.DocTitle;
                                doc.MimeType = item.MimeType;
                                doc.IsPetitonFiled = Convert.ToBoolean(item.IsPetitionFiled);
                                doc.CreatedDate =Convert.ToDateTime(item.CreatedDate);
                                doc.isUploaded = true;
                                if (item.CityUserID != null)
                                {
                                    doc.CityUserID = Convert.ToInt32(item.CityUserID);
                                    using (AccountManagementDataContext accountDbContext = new AccountManagementDataContext(_connString))
                                    {
                                        var dbResult = accountDbContext.CityUserAccounts.Where(r => r.CityUserID == doc.CityUserID).FirstOrDefault();
                                        if (dbResult != null)
                                        {
                                            doc.UploadedBy = dbResult.FirstName + " " + dbResult.LastName;
                                        }
                                    }
                                }
                                if (item.CustomerID != null)
                                {
                                    doc.CustomerID = Convert.ToInt32(item.CustomerID);
                                    using (AccountManagementDataContext accountDbContext = new AccountManagementDataContext(_connString))
                                    {
                                        var dbResult = accountDbContext.CustomerDetails.Where(r => r.CustomerID == doc.CustomerID).First();
                                        if (dbResult != null)
                                        {
                                            var userInfo = GetUserInfo(Convert.ToInt32(dbResult.UserID));
                                            if(userInfo.status.Status == StatusEnum.Success)
                                            {
                                                doc.UploadedBy = userInfo.result.FirstName + " " + userInfo.result.LastName;
                                            }
                                        }
                                    }
                                }                                       
                                docs.Add(doc);
                            }
                        }
                    }
                result.result = docs;
                result.status = new OperationStatus() { Status = StatusEnum.Success };
                return result;
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }

        public ReturnResult<DocumentM> SaveCaseDocument(DocumentM doc)
        {
            ReturnResult<DocumentM> result = new ReturnResult<DocumentM>();
            try
            {
                if (doc != null)
                {
                    using (CommonDataContext db = new CommonDataContext(_connString))
                    {
                        Document document = new Document();
                        document.DocName = doc.DocName;
                        document.DocTitle = doc.DocTitle;
                        document.DocThirdPartyID = doc.DocThirdPartyID;
                        if (doc.CustomerID > 0)
                        {
                            document.CustomerID = doc.CustomerID;
                        }
                        if (doc.CityUserID > 0)
                        {
                            document.CityUserID = doc.CityUserID;
                        }
                        document.C_ID = doc.C_ID;
                        document.DocCategory = doc.DocCategory;
                        document.DocDescription = string.IsNullOrEmpty(doc.DocDescription) ? null : doc.DocDescription;
                        document.IsPetitionFiled = true;
                        document.MimeType = doc.MimeType;
                        document.CreatedDate = DateTime.Now;
                        db.Documents.InsertOnSubmit(document);
                        db.SubmitChanges();
                        doc.DocID = document.DocID;
                    }
                    result.result = doc;
                }
                result.status = new OperationStatus() { Status = StatusEnum.Success };
                return result;
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }


        public ReturnResult<List<DocumentM>> GetDocumentsByCategory(int CustmerID, bool isPetitiofiled, string docCategory)
        {
            ReturnResult<List<DocumentM>> result = new ReturnResult<List<DocumentM>>();
            List<DocumentM> docs = new List<DocumentM>();
            try
            {

                using (CommonDataContext db = new CommonDataContext(_connString))
                {

                    var _documents = db.Documents.Where(r => r.CustomerID == CustmerID && r.IsPetitionFiled == isPetitiofiled && r.DocCategory == docCategory);
                    if (_documents != null)
                    {
                        foreach (var item in _documents)
                        {
                            DocumentM doc = new DocumentM();
                            doc.C_ID = item.C_ID;
                            doc.CustomerID = (item.CustomerID != null) ? Convert.ToInt32(item.CustomerID) : 0;
                            doc.CityUserID = (item.CityUserID != null) ? Convert.ToInt32(item.CityUserID) : 0;
                            doc.DocCategory = item.DocCategory;
                            doc.DocName = item.DocName;
                            doc.DocID = item.DocID;
                            doc.DocThirdPartyID = item.DocThirdPartyID;
                            doc.DocDescription = item.DocDescription;
                            doc.DocTitle = item.DocTitle;
                            doc.MimeType = item.MimeType;
                            doc.IsPetitonFiled = (bool)item.IsPetitionFiled;
                            doc.isUploaded = true;
                            docs.Add(doc);
                        }
                    }

                }
                result.result = docs;
                result.status = new OperationStatus() { Status = StatusEnum.Success };
                return result;
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }

        public ReturnResult<bool> UpdateDocumentCaseInfo(int CustmerID, int C_ID, string docCategory)
        {
            ReturnResult<bool> result = new ReturnResult<bool>();
            try
            {
                using (CommonDataContext db = new CommonDataContext(_connString))
                {

                    var _documents = db.Documents.Where(r => r.CustomerID == CustmerID && r.IsPetitionFiled == false && r.DocCategory == docCategory);
                    if (_documents.Any())
                    {
                        foreach (var doc in _documents)
                        {
                            doc.C_ID = C_ID;
                            doc.IsPetitionFiled = true;
                            db.SubmitChanges();
                        }
                    }
                }
                result.result = true;
                result.status = new OperationStatus() { Status = StatusEnum.Success };
                return result;
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }

        }

        public ReturnResult<List<string>> GetDocDescription()
        {
            ReturnResult<List<string>> result = new ReturnResult<List<string>>();
            try
            {
                using (CommonDataContext db = new CommonDataContext(_connString))
                {
                    var descriptions = db.DocDescriptions.Select(r => r.Description);

                    if (descriptions != null && descriptions.Count() > 0)
                    {
                        result.result = descriptions.ToList();
                    }
                }
                result.status = new OperationStatus() { Status = StatusEnum.Success };
                return result;
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }
       /// <summary>
       /// Get the Webcenter Reference ID based on document type
       /// </summary>
       /// <param name="doc"></param>
       /// <returns></returns>
        public ReturnResult<int> GetDocReferenceID(DocumentM doc)
        {
            ReturnResult<int> result = new ReturnResult<int>();
            //Default value if none of the criteria’s are met
            int RefID = 6312;
            try
            {
                using (CommonDataContext db = new CommonDataContext(_connString))
                {
                    if (doc.DocTitle.Contains("AdditionalDocuments"))
                    {
                        var WebCenterMapping = db.WebCenterReferenceTypeMappings.Where(r => r.DocumentType == doc.DocDescription).FirstOrDefault();
                        if (WebCenterMapping != null)
                        {
                            RefID = WebCenterMapping.RefID;
                        }
                    }
                    else
                    {
                        var WebCenterMapping = db.WebCenterReferenceTypeMappings.Where(r => r.DocumentType == doc.DocTitle).FirstOrDefault();
                        if (WebCenterMapping != null)
                        {
                            RefID = WebCenterMapping.RefID;
                        }
                    }
                }
                result.result = RefID;
                result.status = new OperationStatus() { Status = StatusEnum.Success };
                return result;
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }

        public ReturnResult<CustomEmailM> GetCustomEmailNotification(int c_id, int ActivityID, int NotificationID)
        {
            ReturnResult<CustomEmailM> result = new ReturnResult<CustomEmailM>();
            CustomEmailM model = new CustomEmailM();

            try
            {
                using (CommonDataContext db = new CommonDataContext(_connString))
                {
                    var notification = db.CustomEmailNotifications.Where(r => r.C_ID == c_id && r.ActivityID == ActivityID && r.NotificationID == NotificationID).FirstOrDefault();
                    if (notification != null)
                    {
                        model.ActivityID = ActivityID;
                        model.C_ID = c_id;
                        model.Message.RecipientAddress = notification.Recipient.Split(',').Select(r => r.ToString()).ToList();
                        model.Message.MessageBody = notification.MessageBody;
                        model.CreatedDate = Convert.ToDateTime(notification.CreatedDate).Date;
                        if (notification.CreatedBy != null)
                        {
                            model.CityUserID = Convert.ToInt32(notification.CreatedBy);
                            using (AccountManagementDataContext accountDbContext = new AccountManagementDataContext(_connString))
                            {
                                var dbResult = accountDbContext.CityUserAccounts.Where(r => r.CityUserID == model.CityUserID).FirstOrDefault();
                                if (dbResult != null)
                                {
                                    model.SentBy = dbResult.FirstName + " " + dbResult.LastName;
                                }
                            }
                        }
                        var attachments = db.CustomEmailNotificationAttachments.Where(r => r.NotificationID == notification.NotificationID);
                        if (attachments.Any())
                        {
                            foreach (var item in attachments)
                            {
                                var doc = db.Documents.Where(r => r.DocID == item.DocumentID).FirstOrDefault();
                                if (doc != null)
                                {
                                    DocumentM attachment = new DocumentM();
                                    attachment.DocID = doc.DocID;
                                    attachment.DocThirdPartyID = doc.DocThirdPartyID;
                                    attachment.DocName = doc.DocName;
                                    attachment.DocTitle = doc.DocTitle;
                                    attachment.isUploaded = true;
                                    attachment.MimeType = doc.MimeType;
                                    model.Message.Attachments.Add(attachment);
                                }
                            }
                        }
                        result.result = model;
                        result.status = new OperationStatus() { Status = StatusEnum.Success };
                    }
                    else
                    {
                        result.status = new OperationStatus() { Status = StatusEnum.NoDataFound };
                    }
                }
                
                return result;
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }

        }

        public ReturnResult<EmailM> SaveCustomEmailNotification(EmailM message, int cityUserID, int c_id, int activityID)
        {
            ReturnResult<EmailM> result = new ReturnResult<EmailM>();
            try
            {
                using (CommonDataContext db = new CommonDataContext(_connString))
                {
                    if(message != null)
                    {
                        CustomEmailNotification notification = new CustomEmailNotification();
                        notification.Subject = message.Subject;
                        notification.MessageBody = message.MessageBody;
                        notification.Recipient = String.Join(",", message.RecipientAddress);
                        if(message.CC !=null && message.CC.Any())
                        {
                            notification.CC = String.Concat(message.CC);
                        }
                        if(message.BCC !=null)
                        {
                            notification.BCC = message.BCC;
                        }
                        notification.CreatedDate = DateTime.Now;
                        notification.CreatedBy = cityUserID;
                        notification.C_ID = c_id;
                        notification.ActivityID = activityID;

                        db.CustomEmailNotifications.InsertOnSubmit(notification);
                        db.SubmitChanges();
                        message.NotificationID = notification.NotificationID;

                        if(message.NotificationID > 0)
                        {
                            if(message.Attachments != null && message.Attachments.Any())
                            {
                                foreach(var item in message.Attachments)
                                {
                                    CustomEmailNotificationAttachment notificationAttachment = new CustomEmailNotificationAttachment();
                                    notificationAttachment.NotificationID = message.NotificationID;
                                    notificationAttachment.DocumentID = item.DocID;
                                    db.CustomEmailNotificationAttachments.InsertOnSubmit(notificationAttachment);
                                    db.SubmitChanges();
                                }
                            }
                        }

                        result.result = message;
                        result.status = new OperationStatus() { Status = StatusEnum.Success };
                        return result;
                    }
                    else
                    {
                        throw new Exception("Email model is empty");
                    }
                }
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }

        public ReturnResult<MailM> GetMailNotification(int notificationID)
        {
            ReturnResult<MailM> result = new ReturnResult<MailM>();
            MailM model = new MailM();
            try
            {
                using (CommonDataContext db = new CommonDataContext(_connString))
                {
                    var notification = db.MailNotifications.Where(r => r.NotificationID == notificationID).FirstOrDefault();
                    if (notification != null)
                    {                                             
                        model.Recipient = notification.Recipient.Split(',').Select(r => r.ToString()).ToList();
                        model.Notes = notification.Notes;
                        model.C_ID = Convert.ToInt32(notification.C_ID);
                        model.MailingDate = Convert.ToDateTime(notification.MailingDate).Date;
                        if (notification.CreatedBy != null)
                        {
                            model.CityUserID = Convert.ToInt32(notification.CreatedBy);
                            using (AccountManagementDataContext accountDbContext = new AccountManagementDataContext(_connString))
                            {
                                var dbResult = accountDbContext.CityUserAccounts.Where(r => r.CityUserID == model.CityUserID).FirstOrDefault();
                                if (dbResult != null)
                                {
                                    model.SentBy = dbResult.FirstName + " " + dbResult.LastName;
                                }
                            }
                        }
                        var attachments = db.MailNotificationAttachments.Where(r => r.NotificationID == notification.NotificationID);
                        if (attachments.Any())
                        {
                            foreach (var item in attachments)
                            {
                                var doc = db.Documents.Where(r => r.DocID == item.DocumentID).FirstOrDefault();
                                if (doc != null)
                                {
                                    DocumentM attachment = new DocumentM();
                                    attachment.DocID = doc.DocID;
                                    attachment.DocThirdPartyID = doc.DocThirdPartyID;
                                    attachment.DocName = doc.DocName;
                                    attachment.DocTitle = doc.DocTitle;
                                    attachment.isUploaded = true;
                                    attachment.MimeType = doc.MimeType;                                   
                                    model.Attachments.Add(attachment);
                                }
                            }
                        }
                        result.result = model;
                        result.status = new OperationStatus() { Status = StatusEnum.Success };
                    }
                    else
                    {
                        result.status = new OperationStatus() { Status = StatusEnum.NoDataFound };
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }

        }
        public ReturnResult<MailM> SaveMailNotification(MailM message)
        {
            ReturnResult<MailM> result = new ReturnResult<MailM>();
            try
            {
                using (CommonDataContext db = new CommonDataContext(_connString))
                {
                    if (message != null)
                    {
                        MailNotification notification = new MailNotification();
                        notification.Activity = message.Activity;
                        notification.Notes = message.Notes;
                        notification.Recipient = String.Join(",", message.Recipient);
                        notification.MailingDate = message.MailingDate;
                        notification.CreatedDate = DateTime.Now;
                        notification.CreatedBy = message.CityUserID;
                        notification.C_ID = message.C_ID;
                        db.MailNotifications.InsertOnSubmit(notification);
                        db.SubmitChanges();
                        message.NotificationID = notification.NotificationID;

                        if (message.NotificationID > 0)
                        {
                            if (message.Attachments != null && message.Attachments.Any())
                            {
                                foreach (var item in message.Attachments)
                                {
                                    MailNotificationAttachment notificationAttachment = new MailNotificationAttachment();
                                    notificationAttachment.NotificationID = message.NotificationID;
                                    notificationAttachment.DocumentID = item.DocID;
                                    db.MailNotificationAttachments.InsertOnSubmit(notificationAttachment);
                                    db.SubmitChanges();
                                }
                            }
                        }
                        result.result = message;
                        result.status = new OperationStatus() { Status = StatusEnum.Success };
                        return result;
                    }
                    else
                    {
                        throw new Exception("Mail model is empty");
                    }
                }
            }
            catch (Exception ex)
            {
                IExceptionHandler eHandler = new ExceptionHandler();
                result.status = eHandler.HandleException(ex);
                SaveErrorLog(result.status);
                return result;
            }
        }


    }
}
