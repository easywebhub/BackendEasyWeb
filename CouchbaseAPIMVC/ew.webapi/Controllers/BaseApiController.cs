using ew.core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ew.application.Entities;

namespace ew.webapi.Controllers
{
    public class BaseApiController : ApiController
    {
        protected StatusCodeResult NoContext()
        {
            return StatusCode(HttpStatusCode.NoContent);
        }

        protected IHttpActionResult InvalidRequest()
        {
            var x = new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse(
                    (HttpStatusCode)400,
                    new HttpError(GlobalStatus.InvalidData.ToString())
                )

            );

            x.Response.Headers.Add(EwHeaders.X_Status, GlobalStatus.InvalidData.ToString());
            return x;
        }

        protected IHttpActionResult NoOK()
        {
            return NoOK("Something goes wrong");
        }

        protected IHttpActionResult NoOK(GlobalStatus statusCode)
        {
            return NoOK(statusCode.ToString());
        }

        protected IHttpActionResult NoOK(EwhEntityBase ewhEntityBase)
        {
            var x = NoOK(ewhEntityBase.EwhStatus.ToString()) as ResponseMessageResult;
            if (ewhEntityBase != null)
            {
                x.Response.Headers.Add(EwHeaders.X_Error_Message, ewhEntityBase.EwhErrorMessage);
            }
            return x;
        }

        protected IHttpActionResult NoOK(string statusCode)
        {
            var x = new System.Web.Http.Results.ResponseMessageResult(
                Request.CreateErrorResponse(
                    (HttpStatusCode)422,
                    new HttpError(statusCode)
                )

            );

            x.Response.Headers.Add(EwHeaders.X_Status, statusCode);
            return x;
        }

        
        
    }
}
