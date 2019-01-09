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

    }
}
