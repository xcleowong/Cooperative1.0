﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooperativeLabor.Mvc.Controllers
{
    /// <summary>
    /// 考勤统计
    /// </summary>
    public class AttendanceController : Controller
    {
        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }
    }
}