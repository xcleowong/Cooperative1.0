using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooperativeLabor.Mvc.Controllers
{
    public class AllowancesViewController : Controller
    {
        // GET: AllowancesView
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加补助标准界面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddAllowancesView()
        {
            return View();
        }

        /// <summary>
        /// 显示补助标准标准界面
        /// </summary>
        /// <returns></returns>
        public ActionResult GetAllowancesView()
        {
            return View();
        }

        /// <summary>
        /// 修改补助标准界面
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateAllowancesView()
        {
            return View();
        }

    }
}