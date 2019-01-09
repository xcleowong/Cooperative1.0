using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///审批历史表
    ///</summary>
    public interface IApprovalHistoryServices
    {
        /// <summary>
        /// 添加审批历史
        /// </summary>
        /// <param name="approvalNode"></param>
        /// <returns></returns>
        int AddApprovalHistory(ApprovalHistory approvalHistory);

        /// <summary>
        /// 修改审批历史
        /// </summary>
        /// <param name="approvalNode"></param>
        /// <returns></returns>
        int UpdateApprovalHistory(ApprovalHistory approvalHistory);

        /// <summary>
        /// 删除审批历史
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int DeleteApprovalHistory(int Id);

        /// <summary>
        /// 获取审批历史
        /// </summary>
        /// <returns></returns>
        List<ApprovalHistory> GetApprovalHistory();

        /// <summary>
        /// 根据ID获取审批历史
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ApprovalHistory GetAloneApprovalHistory(int Id);



    }
}
