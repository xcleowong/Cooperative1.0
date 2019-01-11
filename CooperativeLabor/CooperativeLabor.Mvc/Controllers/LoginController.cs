using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooperativeLabor.Mvc.Controllers
{
    
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index(string UserName)
        {
            Session["UserName"] = UserName;
         
            return View();
        }
        public ActionResult Login()
        {
            
            return View();
        }
        public ActionResult Welcome()
        {
            return View();
        }
   
    }
}