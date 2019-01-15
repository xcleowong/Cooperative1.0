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
    ///其他费用
    ///</summary>
    public class OtherExpensesServices : IOtherExpensesServices
    {
        /// <summary>
        /// 添加其他费用
        /// </summary>
        /// <param name="otherExpenses"></param>
        /// <returns></returns>
        public int AddOtherExpense(OtherExpenses otherExpenses)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"insert into OtherExpenses(StaffId,Informant,EmployingUnit,PartnerName,StartTime,EndTime,ProjectTypes,BankCard,ActualCost,ReportedDate,Content,StaffIds,CreationTime,ModificationTime,AId) values(@StaffId,@Informant,@EmployingUnit,@PartnerName,@StartTime,@EndTime,@ProjectTypes,@BankCard,@ActualCost,@ReportedDate,@Content,@StaffIds,@CreationTime,@ModificationTime,@AId)";
                var result = conn.Execute(sql, otherExpenses);
                return result;
            }
        }

        /// <summary>
        /// 绑定下拉
        /// 内容来自合作方入离厂记录中处于‘入厂’状态的合作方数据
        /// </summary>
        /// <returns></returns>
        public List<EntryAndExitRecord> GetEntryAndExitRecords()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"SELECT e.Id, e.PartnerName  FROM entryandexitrecord e WHERE IsDelete = 0";
                var result = conn.Query<EntryAndExitRecord>(sql, null);
                return result.ToList();
            }
        }

        /// <summary>
        /// 获取其他费用
        /// </summary>
        /// <param name="otherExpenses"></param>
        /// <returns></returns>
        public List<OtherExpenses> GetOtherExpenses(int StaffId)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from OtherExpenses where StaffId = @StaffId and Status <> 0 ";
                var values = new { StaffId };
                var result = conn.Query<OtherExpenses>(sql, values);
                return result.ToList();
            }
        }

        /// <summary>
        /// 获取其他费用By Id
        /// </summary>
        /// <param name="otherExpenses"></param>
        /// <returns></returns>
        public List<OtherExpenses> GetOtherExpensesById(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from OtherExpenses where Id = @Id and Status <> 0 ";
                var values = new { Id };
                var result = conn.Query<OtherExpenses>(sql, values);
                return result.ToList();
            }
        }

        /// <summary>
        /// 自动显示登录人所在用工单位
        /// </summary>
        /// <param name="UId"></param>
        /// <returns></returns>
        public List<PersonalInformation> GetPersonalInformation(int UId)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select p.Id, p.Name, p.UserName, p.Employingnit from PersonalInformation p where UId = @UId and IsDelete = 0 ";
                var values = new { UId };
                var result = conn.Query<PersonalInformation>(sql, values);
                return result.ToList();
            }
        }

        /// <summary>
        /// 显示用工单位所有员工
        /// </summary>
        /// <param name="Employingnit">用工单位</param>
        /// <returns></returns>
        public List<PersonalInformation> GetPersonalInformations(string Employingnit)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select p.Id, p.UId, p.NAME, p.UserName, p.Gender, p.Nation, p.ProfessionalSkill, p.Post, p.IDNumber, p.Email, p.Phone from PersonalInformation p where Employingnit = @Employingnit and IsDelete = 0 ";
                var values = new { Employingnit };
                var result = conn.Query<PersonalInformation>(sql, values);
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
                string sql = @"update OtherExpenses set Status = @Status where Id = @Id ";
                var values = new { Status, Id };
                var result = conn.Execute(sql, values);
                return result;
            }
        }
    }
}
