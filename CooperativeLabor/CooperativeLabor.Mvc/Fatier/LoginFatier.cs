using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CooperativeLabor.Mvc.Fatier
{
    using System.Web.Mvc;
    public class LoginFatier:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //filterContext.HttpContext.Session["URL"] = filterContext.HttpContext.Request.RawUrl;
            if (filterContext.HttpContext.Session["UserName"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Login");
            }
            //base.OnAuthorization(filterContext);
        }


    }
}