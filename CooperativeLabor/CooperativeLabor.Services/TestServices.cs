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
        /// 测试添加
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public int Add(Test test)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = "insert into test(Name,Sex,Age) values(:Name,:Sex,:Age)";
                var result = conn.Execute(sql, test);
                return result;
            }
        }

        /// <summary>
        /// 测试删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = "delete from test where Id = :Id";
                var values = new { Id  };
                var result = conn.Execute(sql, values);
                return result;
            }
        }
        
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

        /// <summary>
        /// 获取ID
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<Test> GetTestById(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = "select * from test where Id = :Id";
                var values = new { Id };
                var result = conn.Query<Test>(sql, values);
                return result.ToList<Test>();
            }
        }

        /// <summary>
        /// 测试修改
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public int Update(Test test)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = "update Test set Name = :Name , Sex = :Sex , Age = :Age  where Id = :Id";
                var result = conn.Execute(sql, test);
                return result;
            }
        }
    }
}
