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
    [RoutePrefix("api/dashboard")]
    public class DashboardController : ApiController
    {
        private readonly string _baseURL;
        private string _requestURI = "api/dashboard/";
        public string _errorMessage = "Error occurred in webclient DashboardController";
        public string _exception = "Exception occurred in webclient DashboardController";

        public DashboardController()
        {
            _baseURL = ConfigurationManager.AppSettings["APIBASEURL"].ToString();
        }

        #region "GET REQUEST"

        [AllowAnonymous]
        [HttpGet]
        [Route("getstatus/{activityid:int?}")]
        public HttpResponseMessage GetStatus(int? activityid = null)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string strContent = (activityid != null) ? activityid.ToString() : string.Empty;
                string requestUri = _requestURI + "getstatus/" + strContent;
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
        [HttpGet]
        [Route("getactivity")]
        public HttpResponseMessage GetActivity()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getactivity/";
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
        [HttpGet]
        [Route("gethearingofficers")]
        public HttpResponseMessage GetHearingOfficers()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "gethearingofficers/";
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
        [HttpGet]
        [Route("getanalysts")]
        public HttpResponseMessage GetAnalysts()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getanalysts/";
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
        [HttpGet]
        [Route("assignanalyst/{cID:int}/{AnalystUserID:int}")]
        public HttpResponseMessage AssignAnalyst(int cID, int AnalystUserID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "assignanalyst/" + cID.ToString() + "/" + AnalystUserID.ToString();
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
        [HttpGet]
        [Route("assignhearingofficer/{cID:int}/{HearingOfficerUserID:int}")]
        public HttpResponseMessage AssignHearingOfficer(int cID, int HearingOfficerUserID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "assignhearingofficer/" + cID.ToString() + "/" + HearingOfficerUserID.ToString();
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
        [Route("getemptyactivitystatus")]
        [HttpGet]
        public HttpResponseMessage GetEmptyActivityStatus()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getemptyactivitystatus/";
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
        [Route("GetCaseDocuments/{cid}")]
        [HttpGet]
        public HttpResponseMessage GetCaseDocuments(string cid)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetCaseDocuments/" + cid;
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
        [Route("GetCustomEmail/{cid}")]
        [HttpGet]
        public HttpResponseMessage GetCustomEmail(string cid)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetCustomEmail/" + cid;
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
        [Route("GetMail")]
        [HttpGet]
        public HttpResponseMessage GetMail()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetMail/";
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
        [Route("GetEmptyCaseSearchModel/")]
        [HttpGet]
        public HttpResponseMessage GetEmptyCaseSearchModel()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetEmptyCaseSearchModel/" ;
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
        [Route("GetCustomEmailNotification/{cid}/{activityid}/{NotificationID}")]
        [HttpGet]
        public HttpResponseMessage GetCustomEmailNotification(string cid, string activityid, string NotificationID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetCustomEmailNotification/" + cid + "/" + activityid + "/" + NotificationID;
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
        [Route("GetMailNotification/{NotificationID}")]
        [HttpGet]
        public HttpResponseMessage GetMailNotification(string NotificationID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetMailNotification/" + NotificationID;
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
        #endregion

        #region "POST REQUEST"
        [AllowAnonymous]
        [Route("getcaseactivitystatus")]
        [HttpPost]
        public HttpResponseMessage GetCaseActivityStatus()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "getcaseactivitystatus/";
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
        [Route("GetCaseSearch")]
        [HttpPost]
        public HttpResponseMessage GetCaseSearch()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetCaseSearch/";
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
        [Route("GetCaseswithNoAnalyst/{UserID}")]
        [HttpPost]
        public HttpResponseMessage GetCaseswithNoAnalyst(string UserID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "GetCaseswithNoAnalyst/" + UserID;
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
        [Route("UpdateAPNAddress")]
        [HttpPost]
        public HttpResponseMessage UpdateAPNAddress()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "UpdateAPNAddress/";
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
        [Route("savenewactivitystatus/{cid:int}")]
        [HttpPost]
        public HttpResponseMessage SaveNewActivityStatus(int CID)
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "savenewactivitystatus/" + CID.ToString();
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
        [Route("SaveCaseDocuments")]
        [HttpPost]
        public HttpResponseMessage SaveCaseDocuments()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "SaveCaseDocuments/";
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
        [Route("SubmitCustomEmail")]
        [HttpPost]
        public HttpResponseMessage SubmitCustomEmail()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "SubmitCustomEmail/";
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
        [Route("SubmitMail")]
        [HttpPost]
        public HttpResponseMessage SubmitMail()
        {
            HttpResponseMessage responseMessage;
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(_baseURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string requestUri = _requestURI + "SubmitMail/";
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