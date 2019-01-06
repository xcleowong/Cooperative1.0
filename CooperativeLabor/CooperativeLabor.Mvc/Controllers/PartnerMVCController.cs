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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddEnt()
        {
            return View();
        }
    }
}