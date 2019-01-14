using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CooperativeLabor.Mvc.Controllers
{
    using CooperativeLabor.Mvc.Fatier;
    using Utility;
    public class PartnerMVCController : Controller
    {
        #region 入离厂信息
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
        /// 入离厂信息页面
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexEnt()
        {
            return View();
        }
        #endregion

        #region 基本信息页面
        /// <summary>
        /// 基本信息页面
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexEss1()
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

        #endregion
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
        public ActionResult UpdateRoles(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }


        #endregion



        #region 用户表信息
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <returns></returns>
        [LoginFatier]
        public ActionResult AddUserManagement()
        {
            
            return View();
        }

        /// <summary>
        /// 显示用户
        /// </summary>
        /// <returns></returns>
        //public ActionResult GetUserManagement()
        //{
        //    return View();
        //}

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <returns></returns>
        [LoginFatier]
        public ActionResult UpdateUserManagement(int Id)
        {
            ViewBag.Id = Id;
            return View();
        }
        #endregion


        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminList()
        {
            return View();
        }
        /// <summary>
        /// 角色管理
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleList()
        {
            return View();
        }
        /// <summary>
        /// 权限分类
        /// </summary>
        /// <returns></returns>
        public ActionResult PermissionType()
        {
            return View();
        }
        /// <summary>
        /// 权限管理
        /// </summary>
        /// <returns></returns>
        public ActionResult PermissionList()
        {
            return View();
        }
    }
}