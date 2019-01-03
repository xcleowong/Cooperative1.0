using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.Services
{
    using CooperativeLabor.IServices;
    using CooperativeLabor.Model;
    using CooperativeLabor.Common;
    using Dapper;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// 测试Services
    /// </summary>
    public class TestServices : ITestServices
    {
        /// <summary>
        /// 获取test表中数据
        /// </summary>
        /// <returns></returns>
        public List<Test> GetTests()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = "select * from test";
                var result = conn.Query<Test>(sql, null);
                return result.ToList<Test>();
            }
        }

    }
}
