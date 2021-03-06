﻿using System;
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
        /// 查询登录用户角色
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public List<UserManagement> GetUserManagements(int Id, string UserName)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"SELECT u.RoleId, p.Id, p.Name from UserManagement u Join personalinformation p WHERE u.UserName = p.UserName ANd p.UId = @Id AND p.UserName = @UserName";
                var values = new { Id, UserName };
                var result = conn.Query<UserManagement>(sql, values);
                return result.ToList();
            }
        }

        /// <summary>
        /// 获取审批活动
        /// </summary>
        /// <returns></returns>
        public List<ApprovalActivity> GetApprovalActivity(int ApprovalRoleID)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from approvalactivity WHERE ApprovalRoleID = @ApprovalRoleID And Disabled = 0";
                var values = new { ApprovalRoleID };
                var result = conn.Query<ApprovalActivity>(sql, values);
                return result.ToList();
            }
        }

        /// <summary>
        /// 获取人员费信息
        /// </summary>
        /// <returns></returns>
        public List<ApprovalActivity> GetPersonnelExpenditures(int PerExpId)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"SELECT DISTINCT p.Id,p.*,a.StaffId,a.Proposer,a.ApprovalUser,a.ApprovalOpinion,a.TureCondtion FROM personnelexpenditure p JOIN approvalactivity a WHERE p.Id = a.PerExpId AND a.PerExpId = @PerExpId And STATUS = 1";
                var values = new { PerExpId };
                var result = conn.Query<ApprovalActivity>(sql, values);
                return result.ToList();
            }
        }

        /// <summary>
        /// 修改审批活动
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        public int UpdateApprovalActivity(int Id, string ApprovalUser, string ApprovalOpinion, int TureCondtion)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"UPDATE approvalactivity SET ApprovalUser=@ApprovalUser,ApprovalOpinion=@ApprovalOpinion,TureCondtion=@TureCondtion WHERE Id = @Id And PerExpId = 0";
                var values =  new { Id, ApprovalUser, ApprovalOpinion, TureCondtion };
                var result = conn.Execute(sql, values);
                return result;
            }
        }

        /// <summary>
        /// 根据ID获取审批活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<ApprovalActivity> GetApprovalActivityById(int Id, int ApprovalUserID)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"select * from approvalactivity WHERE Id=@Id And ApprovalRoleID = @ApprovalRoleID";
                var values = new { Id, ApprovalUserID };
                var result = conn.Query<ApprovalActivity>(sql, values);
                return result.ToList();
            }
        }
    }
}
