using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooperativeLabor.Mvc.Controllers
{
    public class DepartmentMaintenanceViewController : Controller
    {
        // GET: DepartmentMaintenanceView
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加单位科室界面
        /// </summary>
        /// <returns></returns>
        public ActionResult AddDepartmentMaintenanceView()
        {
            return View();
        }

        /// <summary>
        /// 显示单位科室界面
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDepartmentMaintenanceView()
        {
            return View();
        }

        /// <summary>
        /// 修改单位科室界面
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateDepartmentMaintenanceView()
        {
            return View();
        }

        


    }
}