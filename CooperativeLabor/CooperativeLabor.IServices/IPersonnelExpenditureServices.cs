using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///人员费
    ///</summary>
    public interface IPersonnelExpenditureServices
    {

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="UId">UserId</param>
        /// <returns></returns>
        List<PersonalInformation> GetPersonalInformation(int UId);

        /// <summary>
        /// 添加人员费信息
        /// </summary>
        /// <param name="personnelExpenditure"></param>
        /// <returns></returns>
        int AddPersonnelExpenditure(PersonnelExpenditure personnelExpenditure);
        
        /// <summary>
        /// 获取审批流程信息
        /// </summary>
        /// <returns></returns>
        List<ApprovalProcess> GetApprovalProcesses(int Id);

        /// <summary>
        /// 添加审批活动表信息
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        int AddApprovalActivity(ApprovalActivity approvalActivity);

        /// <summary>
        /// 获取审批活动表信息
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        List<ApprovalActivity> GetApprovalActivity();

        /// <summary>
        /// 获取审批历史表信息
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        List<ApprovalHistory> GetApprovalHistories();

        /// <summary>
        /// 获取人员费用信息
        /// </summary>
        /// <returns></returns>
        List<PersonnelExpenditure> GetPersonnelExpenditures(int StaffId);

        /// <summary>
        /// 获取人员费用信息By Id
        /// </summary>
        /// <returns></returns>
        List<PersonnelExpenditure> GetPersonnelExpenditureById(int Id);

        /// <summary>
        /// 撤回/修改
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        int RecallOrDelete(int Id, int Status);

    }
}
