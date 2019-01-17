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
    public class AppProcessConfigurationServices : IAppProcessConfigurationServices
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="appProcessConfiguration"></param>
        /// <returns></returns>
        public int Add(AppProcessConfiguration appProcessConfiguration)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"INSERT into appprocessconfiguration
(ProcessID,NodeID,ProcessCode,RoleSector,ApprovalRoleID,NextAppRoleId,AppUserId,NextAppUserId,ProcessRoleID,ConditionId,AppStatusId,Sort,Creator,CreateTime,PId,Disabled)VALUES(@ProcessID,@NodeID,@ProcessCode,@RoleSector,@ApprovalRoleID,@NextAppRoleId,@AppUserId,@NextAppUserId,@ProcessRoleID,@ConditionId,@AppStatusId,@Sort,@Creator,@CreateTime,@PId,@Disabled)";
                var result = conn.Execute(sql, appProcessConfiguration);
                return result;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"DELETE FROM appprocessconfiguration where Id=@Id";
                var result = conn.Execute(sql, new { Id });
                return result;
            }
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AppProcessConfiguration> GetAppProcess()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from appprocessconfiguration";
                var result = conn.Query<AppProcessConfiguration>(sql, null);
                return result.ToList();
            }
        }

        /// <summary>
        /// 获取当个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public AppProcessConfiguration GetAppProcessById(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from appprocessconfiguration WHERE Id=@Id";
                AppProcessConfiguration result = conn.Query<AppProcessConfiguration>(sql, new { Id }).FirstOrDefault();
                return result;
            }

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public int Update(AppProcessConfiguration appProcessConfiguration)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"UPDATE appprocessconfiguration SET ProcessID=@ProcessID,NodeID=@NodeID,ProcessCode=@ProcessCode,RoleSector=@RoleSector,ApprovalRoleID=@ApprovalRoleID,NextAppRoleId=@NextAppRoleId,AppUserId=@AppUserId,NextAppUserId=@NextAppUserId,ProcessRoleID=@ProcessRoleID,ConditionId=@ConditionId,AppStatusId=@AppStatusId,Sort=@Sort,Creator=@Creator,CreateTime=@CreateTime,PId=@PId,Disabled=@Disabled WHERE Id = @Id;";
                var result = conn.Execute(sql, appProcessConfiguration);
                return result;
            }
        }
    }
}
