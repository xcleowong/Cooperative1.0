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
        /// 查询登录用户角色
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        List<UserManagement> GetUserManagements(int Id, string UserName);

        /// <summary>
        /// 获取人员费信息
        /// </summary>
        /// <returns></returns>
        List<ApprovalActivity> GetPersonnelExpenditures(int PerExpId);

        /// <summary>
        /// 获取审批活动
        /// </summary>
        /// <returns></returns>
        List<ApprovalActivity> GetApprovalActivity(int ApprovalRoleID);

        /// <summary>
        /// 修改审批活动
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        int UpdateApprovalActivity(int Id, string ApprovalUser, string ApprovalOpinion, int TureCondtion);

        /// <summary>
        /// 根据ID获取审批活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        List<ApprovalActivity> GetApprovalActivityById(int Id, int ApprovalUserID);
    }
}
