using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooperativeLabor.Mvc.Controllers
{
    using CooperativeLabor.Model;
    using CooperativeLabor.Common;
    using CooperativeLabor.Cache;
    using Newtonsoft.Json;
    using Utility;
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {

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

        public string GetPermissionList(string id)
        {
            UserManagement u = Utility.RedisHelper.Get<UserManagement>(id);
            string permission = JsonConvert.SerializeObject(u.ListPermission);
            return permission;
        }

    }
}