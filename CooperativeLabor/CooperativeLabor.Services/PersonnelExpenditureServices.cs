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
    using Newtonsoft.Json;
    using System.Data;
    
    ///<summary>
    ///人员费
    ///</summary>
    public class PersonnelExpenditureServices : IPersonnelExpenditureServices
    {
        
        /// <summary>
        /// 添加人员费信息
        /// </summary>
        /// <param name="personnelExpenditure"></param>
        /// <returns></returns>
        public int AddPersonnelExpenditure(PersonnelExpenditure personnelExpenditure)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"insert into PersonnelExpenditure(StaffId,Name,EmployingUnit,PartnerName,Year,Quarter,Completeness,Post,CreationTime,ModificationTime,Status,AId) values(@StaffId,@Name,@EmployingUnit,@PartnerName,@Year,@Quarter,@Completeness,@Post,@CreationTime,@ModificationTime,@Status,@AId)";
                var result = conn.Execute(sql, personnelExpenditure);
                return result;
            }
        }

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="UId">UserId</param>
        /// <returns></returns>
        public List<PersonalInformation> GetPersonalInformation(int UId)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from PersonalInformation where UId = @UId and IsDelete <> 0 ";
                var values = new { UId };
                var result = conn.Query<PersonalInformation>(sql, values);
                return result.ToList();
            }
        }

        /// <summary>
        /// 获取人员费用信息
        /// </summary>
        /// <returns></returns>
        public List<PersonnelExpenditure> GetPersonnelExpenditures(int StaffId)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from PersonnelExpenditure where StaffId = @StaffId and Status <> 0 ";
                var values = new { StaffId };
                var result = conn.Query<PersonnelExpenditure>(sql, values);
                return result.ToList();
            }
        }

        /// <summary>
        /// 获取人员费用信息
        /// 返回ID
        /// </summary>
        /// <returns></returns>
        public List<PersonnelExpenditure> GetPersonnelExpenditureId(int StaffId, string Name, string EmployingUnit, string PartnerName, string Year, string Quarter, string Completeness, string Post, string CreationTime)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select Id from PersonnelExpenditure where StaffId = @StaffId and StaffId = @StaffId and Name = @Name and EmployingUnit = @EmployingUnit and PartnerName = @PartnerName and Year = @Year and Quarter = @Quarter and Completeness = @Completeness and Post = @Post and CreationTime = @CreationTime and Status <> 0 ";
                var values = new { StaffId, Name, EmployingUnit, PartnerName, Year, Quarter, Completeness, Post, CreationTime };
                var result = conn.Query<PersonnelExpenditure>(sql, values);
                return result.ToList();
            }
        }

        /// <summary>
        /// 获取人员费用信息By Id
        /// </summary>
        /// <returns></returns>
        public List<PersonnelExpenditure> GetPersonnelExpenditureById(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from PersonnelExpenditure where Id = @Id and Status <> 0 ";
                var values = new { Id };
                var result = conn.Query<PersonnelExpenditure>(sql, values);
                return result.ToList();
            }
        }

        /// <summary>
        /// 撤回/修改
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public int RecallOrDelete(int Id, int Status)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"update PersonnelExpenditure set Status = @Status where Id = @Id ";
                var values = new { Status, Id };
                var result = conn.Execute(sql, values);
                return result;
            }
        }

        /// <summary>
        /// 获取审批流程
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<AppProcessConfiguration> GetApprovalProcesses(string name)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"SELECT c.* FROM appprocessconfiguration c JOIN approvalnode n WHERE c.NodeID = n.Id AND n.NAME = @name AND n.Disabled <> 1";
                var values = new { name };
                var result = conn.Query<AppProcessConfiguration>(sql, values);
                return result.ToList();
            }
        }

        /// <summary>
        /// 添加审批活动表
        /// </summary>
        /// <param name="approvalActivity">审批活动表</param>
        /// <returns></returns>
        public int AddApprovalActivity(List<ApprovalActivity> approvalActivity)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = @"insert into ApprovalActivity(StaffId,Proposer,ProcessID,NodeID,ProcessCode,RoleSector,ApprovalRoleID,NextApprovalRoleID,ApprovalUserID,NextApprovalUserID,ProcessRoleID,JudgmentID,Condtion,IsAllowModity,IsAllowVersion,ApprovalUser,ApprovalOpinion,TureCondtion,ApprovalTime,Creator,CreateTime,PId,Disabled,PerExpId) values(@StaffId,@Proposer,@ProcessID,@NodeID,@ProcessCode,@RoleSector,@ApprovalRoleID,@NextApprovalRoleID,@ApprovalUserID,@NextApprovalUserID,@ProcessRoleID,@JudgmentID,@Condtion,@IsAllowModity,@IsAllowVersion,@ApprovalUser,@ApprovalOpinion,@TureCondtion,@ApprovalTime,@Creator,@CreateTime,@PId,@Disabled,@PerExpId);SELECT LAST_INSERT_ID();";
                var result = conn.Execute(sql, approvalActivity);
                return result;
                #region 执行一个存储过程
                //DynamicParameters parameters = new DynamicParameters();
                //parameters.Add("StaffId", approvalActivity.StaffId,null,null,null);
                //parameters.Add("Proposer", approvalActivity.Proposer, null, null, null);
                //parameters.Add("ProcessID", approvalActivity.ProcessID, null, null, null);
                //parameters.Add("NodeID", approvalActivity.NodeID, null, null, null);
                //parameters.Add("ProcessCode", approvalActivity.ProcessCode, null, null, null);
                //parameters.Add("RoleSector", approvalActivity.RoleSector, null, null, null);
                //parameters.Add("ApprovalRoleID", approvalActivity.ApprovalRoleID, null, null, null);
                //parameters.Add("NextApprovalRoleID", approvalActivity.NextApprovalRoleID, null, null, null);
                //parameters.Add("ApprovalUserID", approvalActivity.ApprovalUserID, null, null, null);
                //parameters.Add("NextApprovalUserID", approvalActivity.NextApprovalUserID, null, null, null);
                //parameters.Add("ProcessRoleID", approvalActivity.ProcessRoleID, null, null, null);
                //parameters.Add("JudgmentID", approvalActivity.JudgmentID, null, null, null);
                //parameters.Add("Condtion", approvalActivity.Condtion, null, null, null);
                //parameters.Add("IsAllowModity", approvalActivity.IsAllowModity, null, null, null);
                //parameters.Add("IsAllowVersion", approvalActivity.IsAllowVersion, null, null, null);
                //parameters.Add("ApprovalUser", approvalActivity.ApprovalUser, null, null, null);
                //parameters.Add("ApprovalOpinion", approvalActivity.ApprovalOpinion, null, null, null);
                //parameters.Add("TureCondtion", approvalActivity.TureCondtion, null, null, null);
                //parameters.Add("ApprovalTime", approvalActivity.ApprovalTime, null, null, null);
                //parameters.Add("Creator", approvalActivity.Creator, null, null, null);
                //parameters.Add("CreateTime", approvalActivity.CreateTime, null, null, null);
                //parameters.Add("PId", approvalActivity.PId, null, null, null);
                //parameters.Add("Disabled", approvalActivity.Disabled, null, null, null);
                //parameters.Add("OutId", approvalActivity.OutId, null, null, null);
                //var result =  conn.Execute("p_InsertAppActivity", parameters, commandType: CommandType.StoredProcedure);
                //return result;
                #endregion
            }
        }

        /// <summary>
        /// 获取审批活动表
        /// </summary>
        /// <returns></returns>
        public List<ApprovalActivity> GetApprovalActivity()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                //string sql = @"select * from ApprovalActivity where StaffId = @StaffId and Status <> 0 ";
                //var values = new { StaffId };
                //var result = conn.Query<PersonnelExpenditure>(sql, values);
                //return result.ToList();
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 获取审批历史表信息
        /// </summary>
        /// <returns></returns>
        public List<ApprovalHistory> GetApprovalHistories()
        {
            //using (MySqlConnection conn = DapperHelper.GetConnString())
            //{
            //    string sql = @"select * from ApprovalHistory where StaffId = @StaffId and Status <> 0 ";
            //    var values = new { StaffId };
            //    var result = conn.Query<ApprovalHistory>(sql, values);
            //    return result.ToList();
            //}
            throw new NotImplementedException();
        }
        
    }
}
