﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Configuration;
using System.Net;
using System.Net.Http;


namespace RAP.WebClient
{
    [RoutePrefix("api/applicationprocessing")]
    public class ApplicationProcessingController : ApiController
    {
        private readonly string _baseURL;
        private string _requestURI = "api/applicationprocessing/";
        public string _errorMessage = "Error occurred in webclient ApplicationProcessingController";
        public string _exception = "Exception occurred in webclient ApplicationProcessingController";

        public ApplicationProcessingController()
        {
            _baseURL = ConfigurationManager.AppSettings["APIBASEURL"].ToString();
        }

        #region Get Methods
        [AllowAnonymous]
        [Route("getcaseinfo/{caseID}/{CustomerID}")]
        [HttpGet]
        public HttpResponseMessage GetCaseDetails(string caseID, string CustomerID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getcaseinfo/" + caseID + "/" + CustomerID;
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("getappealgroundinfo/{CaseNumber}/{AppealFiledBy}")]
        [HttpGet]
        public HttpResponseMessage GetAppealGroundInfo(string CaseNumber, string AppealFiledBy)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getappealgroundinfo/" + CaseNumber + "/" + AppealFiledBy;
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("getappealserve/{AppealID}")]
        [HttpGet]
        public HttpResponseMessage GetAppealServe(string AppealID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getappealserve/" + AppealID;
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("GetPetitioncategory")]
        [HttpGet]
        public HttpResponseMessage GetPetitioncategory()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetPetitioncategory/";
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("GetPageSubmissionStatus/{CustomerID}")]
        [HttpGet]
        public HttpResponseMessage GetPageSubmissionStatus(string CustomerID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetPageSubmissionStatus/" + CustomerID;
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("getgroundsinfo/{petitionID}")]
        [HttpGet]
        public HttpResponseMessage GetPetitionGroundInfo(string petitionID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getgroundsinfo/" + petitionID;
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("getapplicationinfo/{CustomerID}")]
        [HttpGet]
        public HttpResponseMessage GetTenantApplicationInfo(string CustomerID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getapplicationinfo/" + CustomerID;
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("gettenantresponseapplicationinfo/{CaseNumber}/{CustomerID}")]
        [HttpGet]
        public HttpResponseMessage GetTenantResponseApplicationInfo(string CaseNumber, string CustomerID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "gettenantresponseapplicationinfo/" + CaseNumber + "/" + CustomerID;
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("gettenantresponseexemptcontestedinfo/{TenantResponseID}")]
        [HttpGet]
        public HttpResponseMessage GetTenantResponseExemptContestedInfo(string TenantResponseID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "gettenantresponseexemptcontestedinfo/" + TenantResponseID;
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("getcasesnoanalyst")]
        [HttpGet]
        public HttpResponseMessage GetCasesNoAnalyst()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getcasesnoanalyst/";
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("getcasesforcustomer/{CustomerID}")]
        [HttpGet]
        public HttpResponseMessage GetCasesForCustomer(string CustomerID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getcasesforcustomer/" + CustomerID;
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("getrentalhistoryinfo/{PetitionId}")]
        [HttpGet]
        public HttpResponseMessage GetRentalHistoryInfo(string PetitionId)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getrentalhistoryinfo/" + PetitionId;
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("gettenantlostservice/{PetitionId}/{CustomerID}")]
        [HttpGet]
        public HttpResponseMessage GetTenantLostServiceInfo(string PetitionId, string CustomerID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "gettenantlostservice/" + PetitionId + "/" + CustomerID;
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("gettenantreview/{CustomerID}")]
        [HttpGet]
        public HttpResponseMessage GetTenantReviewInfo(string CustomerID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "gettenantreview/" + CustomerID;
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("getemptyrentalhistoryinfo")]
        [HttpGet]
        public HttpResponseMessage GetEmptyTenantRentalIncrementInfo()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getemptyrentalhistoryinfo/";
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("getopposingparty")]
        [HttpGet]
        public HttpResponseMessage GetOpposingParty()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getopposingparty/";
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("getemptylostservicesinfo")]
        [HttpGet]
        public HttpResponseMessage GetEmptyLostServicesInfo()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getemptylostservicesinfo/";
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("getemptyproblemsinfo")]
        [HttpGet]
        public HttpResponseMessage GetEmptyProblemsInfo()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getemptyproblemsinfo/";
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("GetDocDescription")]
        [HttpGet]
        public HttpResponseMessage GetDocDescription()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetDocDescription/";
                responseMessage = client.GetAsync(requestUri).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else // error
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }
        
        #endregion

        #region Post Methods
        [AllowAnonymous]
        [Route("submittenantpetition")]
        [HttpPost]
        public HttpResponseMessage SubmitTenantPetition()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "submittenantpetition/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("savecaseinfo")]
        [HttpPost]
        public HttpResponseMessage SaveCaseDetails()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "savecaseinfo/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("submitappeal")]
        [HttpPost]
        public HttpResponseMessage SubmitAppeal()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "submitappeal/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("saveapplicationinfo")]
        [HttpPost]
        public HttpResponseMessage SaveApplicationInfo()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "saveapplicationinfo/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("savetenantresponseapplicationinfo")]
        [HttpPost]
        public HttpResponseMessage SaveTenantResponseApplicationInfo()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "savetenantresponseapplicationinfo/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [Route("savetenantresponseexemptcontested/{CustomerID}")]
        [HttpPost]
        public HttpResponseMessage SaveTenantResponseExemptContestedInfo(string CustomerID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "savetenantresponseexemptcontested/" + CustomerID;
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("savetenantlostserviceinfo/{CustomerID}")]
        [HttpPost]
        public HttpResponseMessage SaveTenantLostServiceInfo(string CustomerID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "savetenantlostserviceinfo/" + CustomerID;
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("savepetitiongroundinfo/{CustomerID}")]
        [HttpPost]
        public HttpResponseMessage SavePetitionGroundInfo(string CustomerID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "savepetitiongroundinfo/" + CustomerID;
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("saverentalhistoryinfo/{CustomerID}")]
        [HttpPost]
        public HttpResponseMessage SaveTenantRentalHistoryInfo([FromUri]string CustomerID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "saverentalhistoryinfo/" + CustomerID;
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("savetenantappealinfo/{CustomerID}")]
        [HttpPost]
        public HttpResponseMessage SaveTenantAppealInfo(string CustomerID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "savetenantappealinfo/" + CustomerID;
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("savetenantservingappeal/{CustomerID}")]
        [HttpPost]
        public HttpResponseMessage SaveTenantServingAppeal(string CustomerID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "savetenantservingappeal/" + CustomerID;
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("addopposingparty")]
        [HttpPost]
        public HttpResponseMessage AddAnotherOpposingParty()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "addopposingparty/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("saveappealgroundinfo")]
        [HttpPost]
        public HttpResponseMessage SaveAppealGroundInfo()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "saveappealgroundinfo/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        #region Owner Petition Methods

        [AllowAnonymous]
        [Route("GetOwnerApplicantInfo")]
        [HttpPost]
        public HttpResponseMessage GetOwnerApplicantInfo()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetOwnerApplicantInfo/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("GetRentIncreaseReasonInfo")]
        [HttpPost]
        public HttpResponseMessage GetRentIncreaseReasonInfo()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetRentIncreaseReasonInfo/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("GetOwnerPropertyAndTenantInfo")]
        [HttpPost]
        public HttpResponseMessage GetOwnerPropertyAndTenantInfo()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetOwnerPropertyAndTenantInfo/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("GetOwnerRentIncreaseAndPropertyInfo")]
        [HttpPost]
        public HttpResponseMessage GetOwnerRentIncreaseAndPropertyInfo()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetOwnerRentIncreaseAndPropertyInfo/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }
        
        [AllowAnonymous]
        [Route("SaveOwnerApplicantInfo")]
        [HttpPost]
        public HttpResponseMessage SaveOwnerApplicantInfo()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "SaveOwnerApplicantInfo/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("SaveRentIncreaseReasonInfo")]
        [HttpPost]
        public HttpResponseMessage SaveRentIncreaseReasonInfo()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "SaveRentIncreaseReasonInfo/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }
        [AllowAnonymous]
        [Route("SaveOwnerPropertyAndTenantInfo")]
        [HttpPost]
        public HttpResponseMessage SaveOwnerPropertyAndTenantInfo()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "SaveOwnerPropertyAndTenantInfo/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("SaveOwnerRentIncreaseAndUpdatePropertyInfo")]
        [HttpPost]
        public HttpResponseMessage SaveOwnerRentIncreaseAndUpdatePropertyInfo()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "SaveOwnerRentIncreaseAndUpdatePropertyInfo/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("SubmitOwnerPetition")]
        [HttpPost]
        public HttpResponseMessage SubmitOwnerPetition()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "SubmitOwnerPetition/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }
        #endregion

        [AllowAnonymous]
        [Route("GetDocument")]
        [HttpPost]
        public HttpResponseMessage GetDocument()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetDocument/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }

        [AllowAnonymous]
        [Route("GetOwnerAdditionalDocuments")]
        [HttpPost]
        public HttpResponseMessage GetOwnerAdditionalDocuments()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetOwnerAdditionalDocuments/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }


        [AllowAnonymous]
        [Route("SaveOwnerAdditionalDocuments")]
        [HttpPost]
        public HttpResponseMessage SaveOwnerAdditionalDocuments()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "SaveOwnerAdditionalDocuments/";
                responseMessage = client.PostAsync(requestUri, Request.Content).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return responseMessage;
                }
                else
                {
                    responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    responseMessage.ReasonPhrase = _errorMessage;
                }
                return responseMessage;
            }
            catch
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                responseMessage.ReasonPhrase = _exception;
                return responseMessage;
            }
        }
        #endregion

    }

       
}
