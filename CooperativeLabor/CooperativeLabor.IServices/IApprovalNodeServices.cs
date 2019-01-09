using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///审批节点表
    ///</summary>
    public interface IApprovalNodeServices
    {
        /// <summary>
        /// 添加审批节点
        /// </summary>
        /// <param name="approvalNode"></param>
        /// <returns></returns>
        int AddApprovalNode(ApprovalNode approvalNode);

        /// <summary>
        /// 修改审批节点
        /// </summary>
        /// <param name="approvalNode"></param>
        /// <returns></returns>
        int UpdateApprovalNode(ApprovalNode approvalNode);

        /// <summary>
        /// 删除审批节点
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int DeleteApprovalNode(int Id);

        /// <summary>
        /// 获取审批节点
        /// </summary>
        /// <returns></returns>
        List<ApprovalNode> GetApprovalNode();

        /// <summary>
        /// 根据ID获取审批节点
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ApprovalNode GetAloneApprovalNode(int Id);
    }
}
