using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooperativeLabor.Mvc.Controllers
{
    /// <summary>
    /// 考勤签到MVC
    /// </summary>
    public class CheckingInController : Controller
    {
        /// <summary>
        /// 显示/删除/修改/
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        
    }
}