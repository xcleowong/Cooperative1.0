using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///单位科室维护表
    ///</summary>
    public class DepartmentMaintenance
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 用工单位组织机构
        /// </summary>           
        public string EmployingUnit { get; set; }

        /// <summary>
        /// 单位科室
        /// </summary>           
        public string UnitDepartment { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>           
        public int IsStart { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>           
        public DateTime ModificationTime { get; set; }

        /// <summary>
        /// Pid
        /// </summary>           
        public int Pid { get; set; }

    }
}
