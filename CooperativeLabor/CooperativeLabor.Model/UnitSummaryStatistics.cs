using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.Model
{
    /// <summary>
    /// 单位汇总统计Model
    /// </summary>
    public class UnitSummaryStatistics
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int StaffId { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string StaffName { get; set; }

        /// <summary>
        /// 用工单位
        /// </summary>
        public string EmployingUnit { get; set; }

        /// <summary>
        /// 合作方名称
        /// </summary>
        public string PartnerName { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        public string Year { get; set; }

        /// <summary>
        /// 季度
        /// </summary>
        public string Quarter { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// 总花费
        /// </summary>
        public string FeeInTotal { get; set; }
        

    }
}
