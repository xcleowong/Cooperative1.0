using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///审批条件表
    ///</summary>
    public interface IApprovalConditionsServices
    {
        /// <summary>
        /// 添加审批条件
        /// </summary>
        /// <param name="approvalConditions"></param>
        /// <returns></returns>
        int AddApprovalConditions(ApprovalConditions approvalConditions);

        /// <summary>
        /// 修改审批条件
        /// </summary>
        /// <param name="approvalConditions"></param>
        /// <returns></returns>
        int UpdateApprovalConditions(ApprovalConditions approvalConditions);

        /// <summary>
        /// 删除审批条件
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        int DeleteApprovalConditions(int ID);

        /// <summary>
        /// 获取审批条件
        /// </summary>
        /// <returns></returns>
        List<ApprovalConditions> GetApprovalConditions();

        /// <summary>
        /// 根据ID获取审批条件
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        ApprovalConditions GetAloneApprovalCondition(int ID);

    }
}
