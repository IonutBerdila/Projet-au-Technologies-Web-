using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BuisnessLogic.Interfaces;
using eUseControl.Domain.Enums;

namespace eUseControl.Web.Attributes
{
    public class AdminModeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string userRole = filterContext.HttpContext.Session["UserRole"] as string;
            if (userRole != "Admin")
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error"
                };
            }
        }
    }
}