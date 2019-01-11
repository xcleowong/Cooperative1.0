using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CooperativeLabor.WebApi.Controllers
{
    using CooperativeLabor.Model;
    using CooperativeLabor.Services;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Cache;
    using Unity.Attributes;
    using Dapper;
    using Newtonsoft.Json;
    using System.Xml;

    /// <summary>
    /// 单位科室
    /// </summary>
    [RoutePrefix("DepartmentMaintenance")]
    public class DepartmentMaintenanceController : ApiController
    {
        //方法一
        //需要引用 using Unity.Attributes;
        /// <summary>
        /// 属性实例化
        /// </summary>
        [Dependency]
        public IDepartmentMaintenanceServices IdepartmentMaintenanceServices { get; set; }
        /// <summary>
        /// 添加单位科室
        /// </summary>
        /// <param name="departmentMaintenance"></param>
        /// <returns></returns>
        [Route("AddDepartmentMaintenance")]
        [HttpPost]
        public int AddDepartmentMaintenance(DepartmentMaintenance departmentMaintenance)
        {
            int i = IdepartmentMaintenanceServices.AddDepartmentMaintenance(departmentMaintenance);
            return i;

        }

        /// <summary>
        /// 删除单位科室
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("DeleteDepartmentMaintenance")]
        [HttpGet]
        public int DeleteDepartmentMaintenance(int Id)
        {
            int i = IdepartmentMaintenanceServices.DeleteDepartmentMaintenance(Id);
            return i;
        }

        /// <summary>
        /// 根据ID获取单位科室
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetAloneDepartmentMaintenance")]
        [HttpGet]
        public object GetAloneDepartmentMaintenance(int Id)
        {
            var dept = IdepartmentMaintenanceServices.GetAloneDepartmentMaintenance(Id);
            return dept;

        }

        /// <summary>
        /// 根据Pid获取数据
        /// </summary>
        /// <param name="Pid">Pid为0则绑定下拉框,其他值则返回全部数据</param>
        /// <returns></returns>
        [Route("GetDepartmentMaintenance")]
        [HttpGet]
        public object GetDepartmentMaintenance(int Pid = 0)
        {
            var result = IdepartmentMaintenanceServices.GetDepartmentMaintenance();
            if (Pid == 0)
            {
                result = result.Where(a => a.Pid.Equals(Pid)).ToList();
                return result.ToList();
            }
                return Json<List<DepartmentMaintenance>>(result);
           
        }

        /// <summary>
        /// 根据PID获取单位科室
        /// </summary>
        /// <param name="Pid"></param>
        /// <returns></returns>
        [Route("GetDepartmentMaintenancePid")]
        [HttpGet]
        public DepartmentMaintenance GetDepartmentMaintenancePid(int Pid)
        {
            return IdepartmentMaintenanceServices.GetDepartmentMaintenancePid(Pid);

        }

        /// <summary>
        /// 修改单位科室
        /// </summary>
        /// <param name="departmentMaintenance"></param>
        /// <returns></returns>
        [Route("UpdateDepartmentMaintenance")]
        [HttpPost]
        public int UpdateDepartmentMaintenance(DepartmentMaintenance departmentMaintenance)
        {
            return IdepartmentMaintenanceServices.UpdateDepartmentMaintenance(departmentMaintenance);

        }




    }
}
