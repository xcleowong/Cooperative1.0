using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooperativeLabor.Mvc.Controllers
{
    public class SpecialSignMVCController : Controller
    {
        // GET: SpecialSignMVC
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();

        }
    }
}