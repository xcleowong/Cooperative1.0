using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///审批流程表
    ///</summary>
    public interface IApprovalProcessServices
    {
        /// <summary>
        /// 添加审批流程
        /// </summary>
        /// <param name="approvalProcess"></param>
        /// <returns></returns>
        int AddApprovalProcess(ApprovalProcess approvalProcess);

        /// <summary>
        /// 修改审批流程
        /// </summary>
        /// <param name="approvalProcess"></param>
        /// <returns></returns>
        int UpdateApprovalProcess(ApprovalProcess approvalProcess);

        /// <summary>
        /// 删除审批流程
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int DeleteApprovalProcess(int Id);

        /// <summary>
        /// 获取审批流程
        /// </summary>
        /// <returns></returns>
        List<ApprovalProcess> GetApprovalProcess();

        /// <summary>
        /// 根据ID获取审批流程
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ApprovalProcess GetAloneApprovalProcess(int Id);


    }
}
