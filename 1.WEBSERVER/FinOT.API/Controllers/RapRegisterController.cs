﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RAP.API.Common;
using System.Text;
using RAP.API.Models;
using System.Web.Http.Controllers;
using System.Security.Claims;
using RAP.Core.DataModels;
using RAP.Business.Implementation;
using RAP.Core.Services;
using Ninject;
using System.Net.Mail;
using RAP.Core.Common;
using RAP.Business.Binding;

namespace RAP.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/accountmanagement")]
    public class RapRegisterController : ApiController
    {
        string Username, CorrelationID, ExceptionMessage, InnerExceptionMessage;
        private readonly ICommonService _commonService;
        private readonly IExceptionHandler _eHandler;    
      
        public RapRegisterController()
        {
            _commonService = RAPDependancyResolver.Instance.GetKernel().Get<ICommonService>();
            _eHandler = RAPDependancyResolver.Instance.GetKernel().Get<IExceptionHandler>();
        }

        public void ExtractClaimDetails()
        {
            HttpRequestContext context = Request.GetRequestContext();
            var principle = Request.GetRequestContext().Principal as ClaimsPrincipal;
            CorrelationID = principle.Claims.Where(x => x.Type == ClaimTypes.SerialNumber).FirstOrDefault().Value;
            Username = principle.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault().Value;
            ExceptionMessage = "An error occured while processing your request. Reference# " + CorrelationID;
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public HttpResponseMessage GetCustomer()
        {
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<CustomerInfo> transaction = new TranInfo<CustomerInfo>();
            ReturnResult<CustomerInfo> result = new ReturnResult<CustomerInfo>();

            try
            {
              

                CustomerInfo obj;                
                obj = new CustomerInfo();                

                transaction.data = obj;
                transaction.status = true;
            }
            catch (Exception ex)
            {
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);

                //  LogHelper.Instance.Error(service.CorrelationId, Username, Request.GetRequestContext().VirtualPathRoot, ex.Message, InnerExceptionMessage, 0, ex);
            }

            return Request.CreateResponse<TranInfo<CustomerInfo>>(ReturnCode, transaction);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("getCustomer/{custID:int}")]
        public HttpResponseMessage GetCustomer(int custID)
        {
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<CustomerInfo> transaction = new TranInfo<CustomerInfo>();
            ReturnResult<CustomerInfo> result = new ReturnResult<CustomerInfo>();

            try
            {
                result = accService.GetCustomer(custID);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.data = result.result;
                    transaction.status = true;
                }
                else
                {
                    // transaction.warnings.Add(result.status.StatusMessage);

                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);

                    //_commonService.LogError(result.status.StatusCode, result.status.StatusMessage, result.status.StatusDetails, 0, "LoginCust");
                }
            }
            catch (Exception ex)
            {
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);

                //  LogHelper.Instance.Error(service.CorrelationId, Username, Request.GetRequestContext().VirtualPathRoot, ex.Message, InnerExceptionMessage, 0, ex);
            }

            return Request.CreateResponse<TranInfo<CustomerInfo>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getcityuseracctempty")]
        public HttpResponseMessage GetCityUserAcctEmpty()
        {
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<CityUserAccount_M> transaction = new TranInfo<CityUserAccount_M>();
            ReturnResult<CityUserAccount_M> result = new ReturnResult<CityUserAccount_M>();

            try
            {
                //  ExtractClaimDetails();

                CityUserAccount_M obj;                
                obj = new CityUserAccount_M();
                

                transaction.data = obj;
                transaction.status = true;
            }
            catch (Exception ex)
            {
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);

                //  LogHelper.Instance.Error(service.CorrelationId, Username, Request.GetRequestContext().VirtualPathRoot, ex.Message, InnerExceptionMessage, 0, ex);
            }

            return Request.CreateResponse<TranInfo<CityUserAccount_M>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("logincust")]
        [HttpPost]
        public HttpResponseMessage LoginCust([FromBody] CustomerInfo loginInfo)        
        {
           //System.Diagnostics.EventLog.WriteEntry("Application", "LoginCust started");
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<CustomerInfo> transaction = new TranInfo<CustomerInfo>();
            ReturnResult<CustomerInfo> result = new ReturnResult<CustomerInfo>();

            try
            {
                result = accService.GetCustomer(loginInfo);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.data = result.result;
                    transaction.status = true;
                }
                else
                {
                   // transaction.warnings.Add(result.status.StatusMessage);
                    
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);

                    //_commonService.LogError(result.status.StatusCode, result.status.StatusMessage, result.status.StatusDetails, 0, "LoginCust");
                }
                

            }
            catch (Exception ex)
            {
                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
               // transaction.AddException(ex.Message);
                //ReturnCode = HttpStatusCode.InternalServerError;

                //if (ex.InnerException != null) { InnerExceptionMessage = ex.InnerException.Message; }
                //LogHelper.Instance.Error(CorrelationID, Username, Request.GetRequestContext().VirtualPathRoot, ex.Message, InnerExceptionMessage, 0, ex);
            }

            return Request.CreateResponse<TranInfo<CustomerInfo>>(ReturnCode, transaction);
        }

        

        [AllowAnonymous]
        [Route("GetThirdPartyInfo/{CustomerID:int}")]
        [HttpGet]
        public HttpResponseMessage GetThirdPartyInfo(int CustomerID)
        {
            AccountManagementService accService = new AccountManagementService();         
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<ThirdPartyInfoM> transaction = new TranInfo<ThirdPartyInfoM>();
            ReturnResult<ThirdPartyInfoM> result = new ReturnResult<ThirdPartyInfoM>();
            try
            {

                result = accService.GetThirdPartyInfo(CustomerID);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.data = result.result;
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);
                }
            }
            catch (Exception ex)
            {
                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
            }
            return Request.CreateResponse<TranInfo<ThirdPartyInfoM>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("GetTranslationServiceInfo/{UserID:int}")]
        [HttpGet]
        public HttpResponseMessage GetTranslationServiceInfo(int UserID)
        {
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<TranslationServiceInfoM> transaction = new TranInfo<TranslationServiceInfoM>();
            ReturnResult<TranslationServiceInfoM> result = new ReturnResult<TranslationServiceInfoM>();
            try
            {

                result = accService.GetTranslationServiceInfo(UserID);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.data = result.result;
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);
                }
            }
            catch (Exception ex)
            {
                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
            }
            return Request.CreateResponse<TranInfo<TranslationServiceInfoM>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("changepwd")]
        [HttpPost]
        public HttpResponseMessage ChangePassword([FromBody] CustomerInfo custInfo)
        {
            //System.Diagnostics.EventLog.WriteEntry("Application", "LoginCust started");
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<CustomerInfo> transaction = new TranInfo<CustomerInfo>();
            ReturnResult<CustomerInfo> result = new ReturnResult<CustomerInfo>();

            try
            {
                result = accService.ChangePassword(custInfo);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.data = result.result;
                    transaction.status = true;
                }
                else
                {
                    // transaction.warnings.Add(result.status.StatusMessage);

                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);

                    //_commonService.LogError(result.status.StatusCode, result.status.StatusMessage, result.status.StatusDetails, 0, "LoginCust");
                }


            }
            catch (Exception ex)
            {
                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
                // transaction.AddException(ex.Message);
                //ReturnCode = HttpStatusCode.InternalServerError;

                //if (ex.InnerException != null) { InnerExceptionMessage = ex.InnerException.Message; }
                //LogHelper.Instance.Error(CorrelationID, Username, Request.GetRequestContext().VirtualPathRoot, ex.Message, InnerExceptionMessage, 0, ex);
            }

            return Request.CreateResponse<TranInfo<CustomerInfo>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("resendpin")]
        [HttpPost]
        public HttpResponseMessage ResendPin([FromBody] CustomerInfo custInfo)
        {
            //System.Diagnostics.EventLog.WriteEntry("Application", "LoginCust started");
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<bool> transaction = new TranInfo<bool>();
            ReturnResult<bool> result = new ReturnResult<bool>();

            try
            {
                result = accService.ResendPin(custInfo);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.data = result.result;
                    transaction.status = true;
                }
                else
                {
                    // transaction.warnings.Add(result.status.StatusMessage);

                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);

                    //_commonService.LogError(result.status.StatusCode, result.status.StatusMessage, result.status.StatusDetails, 0, "LoginCust");
                }


            }
            catch (Exception ex)
            {
                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
                // transaction.AddException(ex.Message);
                //ReturnCode = HttpStatusCode.InternalServerError;

                //if (ex.InnerException != null) { InnerExceptionMessage = ex.InnerException.Message; }
                //LogHelper.Instance.Error(CorrelationID, Username, Request.GetRequestContext().VirtualPathRoot, ex.Message, InnerExceptionMessage, 0, ex);
            }

            return Request.CreateResponse<TranInfo<bool>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("forgetpwd")]
        [HttpPost]
        public HttpResponseMessage ForgetPwd([FromBody] CustomerInfo customerInfo)
        {
            //System.Diagnostics.EventLog.WriteEntry("Application", "LoginCust started");
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<bool> transaction = new TranInfo<bool>();
            ReturnResult<bool> result = new ReturnResult<bool>();

            try
            {
                if (customerInfo == null || customerInfo.email == null || customerInfo.email == "")
                {
                    transaction.status = false;
                    transaction.AddException("Please enter email address");
                }
                else
                {
                    result = accService.ForgetPwd(customerInfo.email);
                    if (result.status.Status == StatusEnum.Success)
                    {
                        transaction.data = result.result;
                        transaction.status = true;
                    }
                    else
                    {
                        // transaction.warnings.Add(result.status.StatusMessage);

                        transaction.status = false;
                        transaction.AddException(result.status.StatusMessage);

                        //_commonService.LogError(result.status.StatusCode, result.status.StatusMessage, result.status.StatusDetails, 0, "LoginCust");
                    }

                }
               


            }
            catch (Exception ex)
            {
                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
                // transaction.AddException(ex.Message);
                //ReturnCode = HttpStatusCode.InternalServerError;

                //if (ex.InnerException != null) { InnerExceptionMessage = ex.InnerException.Message; }
                //LogHelper.Instance.Error(CorrelationID, Username, Request.GetRequestContext().VirtualPathRoot, ex.Message, InnerExceptionMessage, 0, ex);
            }

            return Request.CreateResponse<TranInfo<bool>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("logincityuser")]
        [HttpPost]
        public HttpResponseMessage LoginCityUser([FromBody] CityUserAccount_M loginInfo)
        {
            //System.Diagnostics.EventLog.WriteEntry("Application", "LoginCust started");
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<CityUserAccount_M> transaction = new TranInfo<CityUserAccount_M>();
            ReturnResult<CityUserAccount_M> result = new ReturnResult<CityUserAccount_M>();

            try
            {
                result = accService.GetCityUser(loginInfo);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.data = result.result;
                    transaction.status = true;
                }
                else
                {
                    // transaction.warnings.Add(result.status.StatusMessage);

                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);

                    //_commonService.LogError(result.status.StatusCode, result.status.StatusMessage, result.status.StatusDetails, 0, "LoginCust");
                }


            }
            catch (Exception ex)
            {
                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
                // transaction.AddException(ex.Message);
                //ReturnCode = HttpStatusCode.InternalServerError;

                //if (ex.InnerException != null) { InnerExceptionMessage = ex.InnerException.Message; }
                //LogHelper.Instance.Error(CorrelationID, Username, Request.GetRequestContext().VirtualPathRoot, ex.Message, InnerExceptionMessage, 0, ex);
            }

            return Request.CreateResponse<TranInfo<CityUserAccount_M>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("GetCityUserFromID/{CityUserID:int}")]
        [HttpGet]
        public HttpResponseMessage GetCityUserFromID([FromUri] int CityUserID)
        {
            //System.Diagnostics.EventLog.WriteEntry("Application", "LoginCust started");
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<CityUserAccount_M> transaction = new TranInfo<CityUserAccount_M>();
            ReturnResult<CityUserAccount_M> result = new ReturnResult<CityUserAccount_M>();

            try
            {
                result = accService.GetCityUserFromID(CityUserID);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.data = result.result;
                    transaction.status = true;
                }
                else
                {
                    // transaction.warnings.Add(result.status.StatusMessage);

                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);

                    //_commonService.LogError(result.status.StatusCode, result.status.StatusMessage, result.status.StatusDetails, 0, "LoginCust");
                }


            }
            catch (Exception ex)
            {
                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
                // transaction.AddException(ex.Message);
                //ReturnCode = HttpStatusCode.InternalServerError;

                //if (ex.InnerException != null) { InnerExceptionMessage = ex.InnerException.Message; }
                //LogHelper.Instance.Error(CorrelationID, Username, Request.GetRequestContext().VirtualPathRoot, ex.Message, InnerExceptionMessage, 0, ex);
            }

            return Request.CreateResponse<TranInfo<CityUserAccount_M>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getaccounttypes/{AccountTypeID:int}")]
        public HttpResponseMessage GetAccountTypes(int AccountTypeID)
        {
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<List<AccountType>> transaction = new TranInfo<List<AccountType>>();
            ReturnResult<List<AccountType>> result = new ReturnResult<List<AccountType>>();
            try
            {
                result = accService.GetAccountTypes(AccountTypeID);

                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.data = result.result;
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);
                }
            }
            catch (Exception ex)
            {
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
            }

            return Request.CreateResponse<TranInfo<List<AccountType>>>(ReturnCode, transaction);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("getstatelist")]
        public HttpResponseMessage GetStateList()
        {
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<List<StateM>> transaction = new TranInfo<List<StateM>>();
            ReturnResult<List<StateM>> result = new ReturnResult<List<StateM>>();
            try
            {
                result = accService.GetStateList();

                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.data = result.result;
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);
                }
            }
            catch (Exception ex)
            {
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
            }

            return Request.CreateResponse<TranInfo<List<StateM>>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getemptyaccountsearchmodel")]
        public HttpResponseMessage GetEmptyAccountSearchModel()
        {
           
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<AccountSearch> transaction = new TranInfo<AccountSearch>();
            ReturnResult<AccountSearch> result = new ReturnResult<AccountSearch>();
            
            try
            {
                

                transaction.data =  new AccountSearch();
                transaction.status = true;
                
            }
            catch (Exception ex)
            {
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
            }

            return Request.CreateResponse <TranInfo<AccountSearch>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("authorizedusers/{custid:int?}")]
        [HttpGet]
        public HttpResponseMessage GetAuthorizedUsers(int? custID = null)
        {
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<CollaboratorAccessM> transaction = new TranInfo<CollaboratorAccessM>();
            ReturnResult<CollaboratorAccessM> result = new ReturnResult<CollaboratorAccessM>();
            try
            {

                transaction.data = new CollaboratorAccessM();
                transaction.status = true;
                //result = accService.GetAuthorizedUsers((int)custID);
                //if (result.status.Status == StatusEnum.Success)
                //{
                //    transaction.data = result.result;
                //    transaction.status = true;
                //}
                //else
                //{
                //    transaction.status = false;
                //    transaction.AddException(result.status.StatusMessage);
                //    //_commonService.LogError(result.status.StatusCode, result.status.StatusMessage, result.status.StatusDetails, 23, "GetAuthorizedUsers");
                //}


            }
            catch (Exception ex)
            {
                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
                //ReturnCode = HttpStatusCode.InternalServerError;

                //if (ex.InnerException != null) { InnerExceptionMessage = ex.InnerException.Message; }
                //LogHelper.Instance.Error(CorrelationID, Username, Request.GetRequestContext().VirtualPathRoot, ex.Message, InnerExceptionMessage, 0, ex);
            }

            return Request.CreateResponse<TranInfo<CollaboratorAccessM>>(ReturnCode, transaction);
        }
        [AllowAnonymous]
        [Route("searchinvite")]
        [HttpPost]
        public HttpResponseMessage SearchInviteCollaborator([FromBody] CustomerInfo loginInfo)
        {
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<CustomerInfo> transaction = new TranInfo<CustomerInfo>();
            ReturnResult<CustomerInfo> result = new ReturnResult<CustomerInfo>();
            try
            {

                
                result = accService.SearchInviteCollaborator(loginInfo.email);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.data = result.result;
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);
                    
                }


            }
            catch (Exception ex)
            {
                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
                // transaction.AddException(ex.Message);
                //ReturnCode = HttpStatusCode.InternalServerError;

                //if (ex.InnerException != null) { InnerExceptionMessage = ex.InnerException.Message; }
                //LogHelper.Instance.Error(CorrelationID, Username, Request.GetRequestContext().VirtualPathRoot, ex.Message, InnerExceptionMessage, 0, ex);
            }

            return Request.CreateResponse<TranInfo<CustomerInfo>>(ReturnCode, transaction);
        }

       

        [AllowAnonymous]
        [Route("authorizecollaborator")]
        [HttpPost]
        public HttpResponseMessage AuthorizeCollaborator([FromBody] CollaboratorAccessM access)
        {
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<bool> transaction = new TranInfo<bool>();
            ReturnResult<bool> result = new ReturnResult<bool>();
            try
            {

                result = accService.AuthorizeCollaborator(access);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.data = (bool)result.result;
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);
                   
                }
            }
            catch (Exception ex)
            {
                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
                // transaction.AddException(ex.Message);
                //ReturnCode = HttpStatusCode.InternalServerError;

                //if (ex.InnerException != null) { InnerExceptionMessage = ex.InnerException.Message; }
                //LogHelper.Instance.Error(CorrelationID, Username, Request.GetRequestContext().VirtualPathRoot, ex.Message, InnerExceptionMessage, 0, ex);
            }

            return Request.CreateResponse<TranInfo<bool>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("removethirdparty/{custid:int?}")]
        [HttpPost]
        public HttpResponseMessage RemoveThirdParty([FromBody] ThirdPartyDetails thirdpartyInfo, int? custid = null)
        {
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<bool> transaction = new TranInfo<bool>();
            ReturnResult<bool> result = new ReturnResult<bool>();
            try
            {

                
                result = accService.RemoveThirdParty((int)custid, thirdpartyInfo.ThirdPartyRepresentationID);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);
                    
                }



            }
            catch (Exception ex)
            {
                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);

                // transaction.AddException(ex.Message);
                //ReturnCode = HttpStatusCode.InternalServerError;

                //if (ex.InnerException != null) { InnerExceptionMessage = ex.InnerException.Message; }
                //LogHelper.Instance.Error(CorrelationID, Username, Request.GetRequestContext().VirtualPathRoot, ex.Message, InnerExceptionMessage, 0, ex);
            }

            return Request.CreateResponse<TranInfo<bool>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("getaccountsearch")]
        [HttpPost]
        public HttpResponseMessage GetAccountSearch([FromBody] AccountSearch accountSearch)
        {
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<SearchResult> transaction = new TranInfo<SearchResult>();
            ReturnResult<SearchResult> result = new ReturnResult<SearchResult>();

            try
            {
                result = accService.GetAccountSearch(accountSearch);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.data = result.result;
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);

                }
            }
            catch (Exception ex)
            {

                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
            }
            return Request.CreateResponse<TranInfo<SearchResult>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("saveCust")]
        [HttpPost]
        public HttpResponseMessage SaveCustomer([FromBody] CustomerInfo custModel)
        {
            System.Diagnostics.EventLog.WriteEntry("Application", "Controller Save Customer started");
            AccountManagementService accService = new AccountManagementService();
            IEmailService emailService = new EmailService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<CustomerInfo> transaction = new TranInfo<CustomerInfo>();
            ReturnResult<CustomerInfo> result = new ReturnResult<CustomerInfo>();

            try
            {
                result = accService.SaveCustomer(custModel);
                if (result.status.Status == StatusEnum.Success)
                {
                    
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);                  
                }
            }
            catch(Exception ex)
            {

                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
            }
            return Request.CreateResponse<TranInfo<CustomerInfo>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("DeleteCustomer")]
        [HttpPost]
        public HttpResponseMessage DeleteCustomer([FromBody] CustomerInfo custModel)
        {
            System.Diagnostics.EventLog.WriteEntry("Application", "Controller Delete Customer started");
            AccountManagementService accService = new AccountManagementService();           
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<bool> transaction = new TranInfo<bool>();
            ReturnResult<bool> result = new ReturnResult<bool>();

            try
            {
                result = accService.DeleteCustomer(custModel);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);

                }
            }
            catch (Exception ex)
            {

                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
            }
            return Request.CreateResponse<TranInfo<bool>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("DeleteCityUser/{UserID:int}")]
        [HttpGet]
        public HttpResponseMessage DeleteCityUser([FromUri] int UserID)
        {
            System.Diagnostics.EventLog.WriteEntry("Application", "Controller Delete Customer started");
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<bool> transaction = new TranInfo<bool>();
            ReturnResult<bool> result = new ReturnResult<bool>();

            try
            {
                result = accService.DeleteCityUser(UserID);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);

                }
            }
            catch (Exception ex)
            {

                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
            }
            return Request.CreateResponse<TranInfo<bool>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("SaveOrUpdateThirdPartyInfo")]
        [HttpPost]
        public HttpResponseMessage SaveOrUpdateThirdPartyInfo([FromBody] ThirdPartyInfoM model)
        {
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<Boolean> transaction = new TranInfo<Boolean>();
            ReturnResult<Boolean> result = new ReturnResult<Boolean>();

            try
            {
                result = accService.SaveOrUpdateThirdPartyInfo(model);
                if (result.status.Status == StatusEnum.Success)
                {                    
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);

                }
            }
            catch (Exception ex)
            {

                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
            }
            return Request.CreateResponse<TranInfo<Boolean>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("SaveTranslationServiceInfo")]
        [HttpPost]
        public HttpResponseMessage SaveTranslationServiceInfo([FromBody] TranslationServiceInfoM model)
        {
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<Boolean> transaction = new TranInfo<Boolean>();
            ReturnResult<Boolean> result = new ReturnResult<Boolean>();

            try
            {
                result = accService.SaveTranslationServiceInfo(model);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);

                }
            }
            catch (Exception ex)
            {

                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
            }
            return Request.CreateResponse<TranInfo<Boolean>>(ReturnCode, transaction);
        }
        [AllowAnonymous]
        [Route("RemoveThirdPartyInfo")]
        [HttpPost]
        public HttpResponseMessage RemoveThirdPartyInfo([FromBody] ThirdPartyInfoM model)
        {
            System.Diagnostics.EventLog.WriteEntry("Application", "Controller Remove Third Party started");
            AccountManagementService accService = new AccountManagementService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<ThirdPartyInfoM> transaction = new TranInfo<ThirdPartyInfoM>();
            ReturnResult<ThirdPartyInfoM> result = new ReturnResult<ThirdPartyInfoM>();

            try
            {
                result = accService.RemoveThirdPartyInfo(model);
                if (result.status.Status == StatusEnum.Success)
                {
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);

                }
            }
            catch (Exception ex)
            {

                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
            }
            return Request.CreateResponse<TranInfo<ThirdPartyInfoM>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("editCust")]
        [HttpPost]
        public HttpResponseMessage EditCustomer([FromBody] CustomerInfo custModel)
        {
            System.Diagnostics.EventLog.WriteEntry("Application", "Controller edit Customer started");
            AccountManagementService accService = new AccountManagementService();
            IEmailService emailService = new EmailService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<CustomerInfo> transaction = new TranInfo<CustomerInfo>();
            ReturnResult<CustomerInfo> result = new ReturnResult<CustomerInfo>();

            try
            {
                result = accService.EditCustomer(custModel);
                if (result.status.Status == StatusEnum.Success)
                {
                    //emailService.SendEmail(getRegisterCustomerEmailModel(result.result));
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);

                }
            }
            catch (Exception ex)
            {

                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
            }
            return Request.CreateResponse<TranInfo<CustomerInfo>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("createcityuseraccount")]
        [HttpPost]
        public HttpResponseMessage CreateCityUserAccount([FromBody] CityUserAccount_M cityUserModel)
        {
            System.Diagnostics.EventLog.WriteEntry("Application", "Controller Save Customer started");
            AccountManagementService accService = new AccountManagementService();
            IEmailService emailService = new EmailService();
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<CityUserAccount_M> transaction = new TranInfo<CityUserAccount_M>();
            ReturnResult<CityUserAccount_M> result = new ReturnResult<CityUserAccount_M>();

            try
            {
                result = accService.CreateCityUserAccount(cityUserModel);
                if (result.status.Status == StatusEnum.Success)
                {
                    //emailService.SendEmail(getRegisterCustomerEmailModel(result.result));
                    transaction.status = true;
                }
                else
                {
                    transaction.status = false;
                    transaction.AddException(result.status.StatusMessage);

                }
            }
            catch (Exception ex)
            {

                transaction.status = false;
                transaction.AddException(ex.Message);
                ReturnCode = HttpStatusCode.InternalServerError;
                result.status = _eHandler.HandleException(ex);
                _commonService.LogError(result.status);
            }
            return Request.CreateResponse<TranInfo<CityUserAccount_M>>(ReturnCode, transaction);
        }

        [AllowAnonymous]
        [Route("invite")]
        [HttpPost]
        public HttpResponseMessage Invite([FromBody] CustomerInfo custModel)
        {
            HttpStatusCode ReturnCode = HttpStatusCode.OK;
            TranInfo<bool> transaction = new TranInfo<bool>();
  
            MailMessage mail = new MailMessage("nehab.infy@gmail.com", "neha.bhandari@gcomsoft.com");
            
            SmtpClient client = new SmtpClient();
            client.Credentials = new NetworkCredential("", "");
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            mail.Subject = "this is a test email.";
            mail.Body = "this is my test email body";
            try
            {
                client.Send(mail);
            }
            catch(Exception ex)
            {
                transaction.status = false;
            }
            transaction.data = true;

            return Request.CreateResponse<TranInfo<bool>>(ReturnCode, transaction);
        }

        

    }
}
