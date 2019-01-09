using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooperativeLabor.Mvc.Controllers
{
    public class PartnerMVCController : Controller
    {
        // GET: PartnerMVC
        /// <summary>
        /// 显示入离厂信息
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 添加入离厂信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddEnt()
        {
            return View();
        }

        /// <summary>
        /// 显示基本信息
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexEss()
        {
            return View();
        }

        /// <summary>
        /// 添加基本信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddEntEss()
        {
            return View();
        }
        public ActionResult aaa()
        {
            return View();
        }

        public ActionResult bbb()
        {
            return View();
        }
        #region 添加权限信息
        public ActionResult AddPermission()
        {
            return View();
        }
        #endregion
    }
}