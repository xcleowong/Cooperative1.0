using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///审批状态表
    ///</summary>
    public interface IApprovalStatusServices
    {
        /// <summary>
        /// 添加审批状态
        /// </summary>
        /// <param name="approvalStatus"></param>
        /// <returns></returns>
        int AddApprovalStatus(ApprovalStatus approvalStatus);

        /// <summary>
        /// 修改审批状态
        /// </summary>
        /// <param name="approvalStatus"></param>
        /// <returns></returns>
        int UpdateApprovalStatus(ApprovalStatus approvalStatus);

        /// <summary>
        /// 删除审批状态
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        int DeleteApprovalStatus(int ID);

        /// <summary>
        /// 获取审批状态
        /// </summary>
        /// <returns></returns>
        List<ApprovalStatus> GetApprovalStatus();

        /// <summary>
        /// 根据ID获取审批状态
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        ApprovalStatus GetAloneApprovalStatus(int ID);

    }
}
