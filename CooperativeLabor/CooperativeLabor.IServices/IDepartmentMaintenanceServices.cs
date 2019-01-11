using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///单位科室维护表
    ///</summary>
    public interface IDepartmentMaintenanceServices
    {
        /// <summary>
        /// 添加单位科室
        /// </summary>
        /// <param name="departmentMaintenance"></param>
        /// <returns></returns>
        int AddDepartmentMaintenance(DepartmentMaintenance departmentMaintenance);

        /// <summary>
        /// 修改单位科室
        /// </summary>
        /// <param name="departmentMaintenance"></param>
        /// <returns></returns>
        int UpdateDepartmentMaintenance(DepartmentMaintenance departmentMaintenance);

        /// <summary>
        /// 删除单位科室
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int DeleteDepartmentMaintenance(int Id);

        /// <summary>
        /// 获取单位科室
        /// </summary>
        /// <returns></returns>
        List<DepartmentMaintenance> GetDepartmentMaintenance();

        /// <summary>
        /// 根据ID获取单位科室
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        DepartmentMaintenance GetAloneDepartmentMaintenance(int Id);

        /// <summary>
        /// 根据PID获取单位科室
        /// </summary>
        /// <param name="Pid"></param>
        /// <returns></returns>
        DepartmentMaintenance GetDepartmentMaintenancePid(int Pid);
    }
}
