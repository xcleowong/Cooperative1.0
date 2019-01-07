using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooperativeLabor.Mvc.Controllers
{
    public class HolidaySettingsViewController : Controller
    {
        // GET: HolidaySettingsView
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加假期设置界面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddHolidaySettingsView()
        {
            return View();
        }

        /// <summary>
        /// 显示假期设置界面
        /// </summary>
        /// <returns></returns>
        public ActionResult GetHolidaySettingsView()
        {
            return View();
        }

        /// <summary>
        /// 修改假期设置界面
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateHolidaySettingsView()
        {
            return View();
        }
    }
}