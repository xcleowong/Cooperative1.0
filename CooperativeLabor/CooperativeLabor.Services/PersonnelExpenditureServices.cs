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
        /// 获取人员费用信息By Id
        /// </summary>
        /// <returns></returns>
        List<PersonnelExpenditure> IPersonnelExpenditureServices.GetPersonnelExpenditureById(int Id)
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
        public List<ApprovalProcess> GetApprovalProcesses(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加审批活动表
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        public int AddApprovalActivity(ApprovalActivity approvalActivity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取审批活动表
        /// </summary>
        /// <returns></returns>
        public List<ApprovalActivity> GetApprovalActivity()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取审批历史表信息
        /// </summary>
        /// <returns></returns>
        public List<ApprovalHistory> GetApprovalHistories()
        {
            throw new NotImplementedException();
        }
        
    }
}
