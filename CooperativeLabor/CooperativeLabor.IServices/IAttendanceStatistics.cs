using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    /// <summary>
    /// 考勤统计
    /// </summary>
    public interface IAttendanceStatistics
    {
        /// <summary>
        /// 获取单位科室
        /// </summary>
        /// <returns></returns>
        List<DepartmentMaintenance> GetDepartmentMaintenances();

        /// <summary>
        /// 获取派出单位(入厂)
        /// </summary>
        /// <returns></returns>
        List<EntryAndExitRecord> GetEntryAndExitRecords();




    }
}
