using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CooperativeLabor.Common;
using CooperativeLabor.Model;
using Newtonsoft.Json;

namespace CooperativeLabor.Mvc.Controllers
{
  

    public class LoginController : BaseController
    {

        /// <summary>
        /// 登录首页
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginIndex()
        {
            ViewBag.Id = Session["Id"];
            ViewBag.UserName = Session["UserName"];
            return View();
        }
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Id = Session["Id"];
            ViewBag.UserName = Session["UserName"];
            return View();
        }

        //public ActionResult Index(int id)
        //{
        //    System.Web.HttpContext.Current.Session["userID"] = id;
        //    return View();
        //}

       

       
       /// <summary>
       /// 登录
       /// </summary>
       /// <returns></returns>
        public ActionResult Login()
        {

            return View();
        }
       



        public ActionResult Welcome()
        {
            return View();
        }

        /// <summary>
        /// forms 身份认证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int Logins(UserManagement userManagement)
        {
            Session["Id"] = userManagement.Id;
            Session["UserName"] = userManagement.UserName;
            WriteDataToCookie(userManagement);
            return 1;
        }

      
        
        public string GetPermissionList(string Id)
        {
            UserManagement u = Utility.RedisHelper.Get<UserManagement>(Id);
            string permission = JsonConvert.SerializeObject(u.ListPermission);
            return permission;
        }


    }
}