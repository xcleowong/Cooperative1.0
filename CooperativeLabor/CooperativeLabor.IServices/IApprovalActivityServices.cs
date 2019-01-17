using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///审批活动表
    ///</summary>
    public interface IApprovalActivityServices
    {
        /// <summary>
        /// 添加审批活动
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        int AddApprovalActivity(ApprovalActivity approvalActivity);

        /// <summary>
        /// 修改审批活动
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        int UpdateApprovalActivity(ApprovalActivity approvalActivity);

        /// <summary>
        /// 删除审批活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int DeleteApprovalActivity(int Id);

        /// <summary>
        /// 获取审批活动
        /// </summary>
        /// <returns></returns>
        List<ApprovalActivity> GetApprovalActivity();

        /// <summary>
        /// 根据ID获取审批活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        ApprovalActivity GetApprovalActivityById(int Id);


    }
}
