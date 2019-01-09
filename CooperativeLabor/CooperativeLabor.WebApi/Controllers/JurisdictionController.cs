using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CooperativeLabor.WebApi.Controllers
{
    using CooperativeLabor.Model;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Services;
    using Unity.Attributes;


    [RoutePrefix("Jurisdiction")]
    public class JurisdictionController : ApiController
    {
        /// <summary>
        /// 权限表
        /// </summary>
        [Dependency]
       public IPermissionServices permission  { get; set; }
        #region 权限表信息
        /// <summary>
        /// 添加权限信息
        /// </summary>
        [Route("AddPermission")]
        [HttpPost]
        public int AddPermission(Permission permission)
        {
            int i = this.permission.AddPermission(permission);
            return i;
        }
        /// <summary>
        /// 显示权限信息
        /// </summary>
        [Route("GetPermissions")]
        [HttpGet]
        public IEnumerable<Permission> GetPermissions()
        {
            var result = this.permission.GetPermissions();
            return result;
        }
        /// <summary>
        /// 删除权限信息
        /// </summary>
        [Route("DeletePermission")]
        [HttpPost]
        public int DeletePermission(int Id)
        {
            int i = this.permission.DeletePermission(Id);
            return i;
        }
        /// <summary>
        /// 修改权限信息
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        [Route("UpdatePermission")]
        [HttpPost]
        public int UpdatePermission(Permission permission)
        {
            int i = this.permission.UpdatePermission(permission);
            return i;
        }
        /// <summary>
        ///根据ID显示权限信息
        /// </summary>
        [Route("GetPermissionById")]
        [HttpGet]
        public Permission GetPermissionById(int Id)
        {
            var result = this.permission.GetPermissionById(Id);
            return result;
        }
        /// <summary>
        /// 获取权限名称
        /// </summary>
        /// <returns></returns>
        [Route("GetPermissionName")]
        [HttpGet]
        public IEnumerable<Permission> GetPermissionName()
        {
            var result = this.permission.GetPermissionName();
            return result;
        }

        /// <summary>
        ///根据PID显示权限信息
        /// </summary>
        [Route("GetPermissionsByPid")]
        [HttpGet]
        public IEnumerable<Permission> GetPermissionsByPid(int Pid)
        {
            var result = this.permission.GetPermissionsByPid(Pid);
            return result;
        }
        #endregion
        /// <summary>
        /// 角色表
        /// </summary>
        [Dependency]
        public IRolesServices role { get; set; }
        #region
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        [Route("AddRoles")]
        [HttpPost]
        public int AddRoles(Roles roles)
        {
            int i = this.role.AddRole(roles);
            return i;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("DeleteRoles")]
        [HttpGet]
        public int DeleteRoles(int Id)
        {
            int i = this.role.DeleteRole(Id);
            return i;
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [Route("GetRoles")]
        [HttpGet]
        public IEnumerable<Roles> GetRoles()
        {
            var result = this.role.GetRoles();
            return result;
        }
        /// <summary>
        /// 根据Id获取单个角色
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetRolesById")]
        [HttpGet]
        public Roles GetRolesById(int Id)
        {
            var result = this.role.GetRolesById(Id);
            return result;
        }
        [Route("UpdateRoles")]
        [HttpPost]
        public int UpdateRoles(Roles roles)
        {
            int i = this.role.UpdateRoles(roles);
            return i;
        }
        #endregion

    }
}
