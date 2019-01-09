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
        #region 权限信息
        /// <summary>
        /// 添加权限信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AddPermission()
        {
            return View();
        }
        /// <summary>
        /// 显示/删除
        /// </summary>
        /// <returns></returns>
        public ActionResult GetPermission()
        {
            return View();
        }
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult Updates(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        #endregion

        #region 角色表信息
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        public ActionResult AddRoles()
        {
            return View();
        }
        /// <summary>
        /// 显示角色
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoles()
        {
            return View();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult UpdateRoles()
        {
            return View();
        }

    
        #endregion
    }
}