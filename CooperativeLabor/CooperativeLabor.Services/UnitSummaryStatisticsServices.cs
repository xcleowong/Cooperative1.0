using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.Services
{
    using CooperativeLabor.Common;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Model;
    using Dapper;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// 单位汇总统计接口
    /// </summary>
    public class UnitSummaryStatisticsServices : IUnitSummaryStatisticsServices
    {
        /// <summary>
        /// 单位汇总统计功能
        /// </summary>
        /// <returns></returns>
        public List<UnitSummaryStatistics> GetUnitSummaryStatistics(string year, int quarter)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"SELECT * FROM checkingin WHERE StaffId = @staffId ORDER BY SignInTime DESC LIMIT 1";

                var result = conn.Query<UnitSummaryStatistics>(sql, null);
                return result.ToList();
            }
        }

    }
}
