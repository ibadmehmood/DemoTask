using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagementSystem.Helpers
{
    public class JsonResultWithStatusCode : JsonResult
    {
        private readonly HttpStatusCode _httpStatus;

        public JsonResultWithStatusCode(object data, HttpStatusCode httpStatus)
        {
            Data = data;
            _httpStatus = httpStatus;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.StatusCode = (int)_httpStatus;
            this.JsonRequestBehavior=JsonRequestBehavior.AllowGet;
            base.ExecuteResult(context);
        }
    }
}