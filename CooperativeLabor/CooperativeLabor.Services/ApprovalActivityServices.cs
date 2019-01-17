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
    ///<summary>
    ///审批活动表
    ///</summary>
    public class ApprovalActivityServices : IApprovalActivityServices
    {
        /// <summary>
        /// 添加审批活动
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        public int AddApprovalActivity(ApprovalActivity approvalActivity)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"INSERT into approvalactivity(ProcessID,NodeID,ProcessCode,RoleSector,ApprovalRoleID,NextApprovalRoleID,ApprovalUserID,NextApprovalUserID,ProcessRoleID,JudgmentID,Condtion,IsAllowModity,IsAllowVersion,ApprovalUser,ApprovalOpinion,TureCondtion,ApprovalTime,Creator,CreateTime,Disabled) VALUES(@ProcessID,@NodeID,@ProcessCode,@RoleSector,@ApprovalRoleID,@NextApprovalRoleID,@ApprovalUserID,@NextApprovalUserID,@ProcessRoleID,@JudgmentID,@Condtion,@IsAllowModity,@IsAllowVersion,@ApprovalUser,@ApprovalOpinion,@TureCondtion,@ApprovalTime,@Creator,@CreateTime,@Disabled)";
                var result = conn.Execute(sql, approvalActivity);
                return result;
            }
        }

        /// <summary>
        /// 删除审批活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteApprovalActivity(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"DELETE FROM approvalactivity where Id=@Id";
                var result = conn.Execute(sql, new { Id });
                return result;
            }
        }




        /// <summary>
        /// 获取审批活动
        /// </summary>
        /// <returns></returns>
        public List<ApprovalActivity> GetApprovalActivity()
        {

            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from approvalactivity";
                var result = conn.Query<ApprovalActivity>(sql, null);
                return result.ToList();
            }
        }

        /// <summary>
        ///根据ID获取审批活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ApprovalActivity GetApprovalActivityById(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from approvalactivity WHERE Id=@Id";
                ApprovalActivity result = conn.Query<ApprovalActivity>(sql, new { Id }).FirstOrDefault();
                return result;
            }

        }

        /// <summary>
        /// 修改审批活动
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        public int UpdateApprovalActivity(ApprovalActivity approvalActivity)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"UPDATE approvalactivity SET ProcessID=@ProcessID,NodeID=@NodeID,ProcessCode=@ProcessCode,RoleSector=@RoleSector,ApprovalRoleID=@ApprovalRoleID,NextApprovalRoleID=@NextApprovalRoleID,ApprovalUserID=@ApprovalUserID,NextApprovalUserID=@NextApprovalUserID,ProcessRoleID=@ProcessRoleID,JudgmentID=@JudgmentID,Condtion=@Condtion,IsAllowModity=@IsAllowModity,IsAllowVersion=@IsAllowVersion,ApprovalUser=@ApprovalUser,ApprovalOpinion=@ApprovalOpinion,TureCondtion=@TureCondtion,ApprovalTime=@ApprovalTime,Creator=@Creator,CreateTime=@CreateTime,Disabled=@Disabled WHERE Id = @Id;";
                var result = conn.Execute(sql, approvalActivity);
                return result;
            }
        }
    }
}
