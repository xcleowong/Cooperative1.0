using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///审批活动表
    ///</summary>
    public class ApprovalActivity
    {
        /// <summary>
        /// 主键
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 员工ID
        /// </summary>
        public int StaffId { get; set; }

        /// <summary>
        /// 申请人
        /// </summary>
        public string Proposer { get; set; }

        /// <summary>
        /// 审批流程ID
        /// </summary>           
        public int ProcessID { get; set; }

        /// <summary>
        /// 审批节点ID
        /// </summary>           
        public int NodeID { get; set; }

        /// <summary>
        /// 配置流程编码
        /// </summary>           
        public string ProcessCode { get; set; }

        /// <summary>
        /// 审批角色部门
        /// </summary>           
        public string RoleSector { get; set; }

        /// <summary>
        /// 审批角色ID
        /// </summary>           
        public int ApprovalRoleID { get; set; }

        /// <summary>
        /// 下一步审批角色ID
        /// </summary>           
        public int NextApprovalRoleID { get; set; }

        /// <summary>
        /// 审批人ID
        /// </summary>           
        public int ApprovalUserID { get; set; }

        /// <summary>
        /// 下一步审批人ID
        /// </summary>           
        public int NextApprovalUserID { get; set; }

        /// <summary>
        /// 使用流程角色ID
        /// </summary>           
        public string ProcessRoleID { get; set; }

        /// <summary>
        /// 判断条件ID
        /// </summary>           
        public int JudgmentID { get; set; }

        /// <summary>
        /// 审批状态
        /// </summary>           
        public int Condtion { get; set; }

        /// <summary>
        /// 是否修改
        /// </summary>           
        public int IsAllowModity { get; set; }

        /// <summary>
        /// 是否撤销
        /// </summary>           
        public int IsAllowVersion { get; set; }

        /// <summary>
        /// 实际审批人
        /// </summary>           
        public string ApprovalUser { get; set; }

        /// <summary>
        /// 审批意见
        /// </summary>           
        public string ApprovalOpinion { get; set; }

        /// <summary>
        /// 实际审批状态
        /// </summary>           
        public int TureCondtion { get; set; }

        /// <summary>
        /// 审批时间
        /// </summary>           
        public DateTime ApprovalTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>           
        public string Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public int Disabled { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public int PId { get; set; }

        /// <summary>
        /// 人员费ID
        /// </summary>
        public int PerExpId { get; set; }
    }
}
