using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    /// <summary>
    /// 单位汇总统计接口
    /// </summary>
    public interface IUnitSummaryStatisticsServices
    {
        /// <summary>
        /// 单位汇总统计功能
        /// </summary>
        /// <returns></returns>
        List<UnitSummaryStatistics> GetUnitSummaryStatistics(string year, int quarter);

    }
}
