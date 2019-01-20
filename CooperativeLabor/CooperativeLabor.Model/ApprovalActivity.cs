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
        /// 0未审、1通过、2驳回
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

        #region 人员费表字段 非映射
        
        /// <summary>
        /// 姓名
        /// </summary>           
        public string Name { get; set; }

        /// <summary>
        /// 用工单位
        /// </summary>
        public string EmployingUnit { get; set; }

        /// <summary>
        /// 合作方名称
        /// </summary>           
        public string PartnerName { get; set; }

        /// <summary>
        /// 年度
        /// </summary>           
        public string Year { get; set; }

        /// <summary>
        /// 季度
        /// </summary>           
        public string Quarter { get; set; }

        /// <summary>
        /// 工作完成情况
        /// </summary>           
        public string Completeness { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>           
        public string Post { get; set; }

        /// <summary>
        /// 季度费用
        /// </summary>           
        public double QuarterlyFees { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public string CreationTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>           
        public string ModificationTime { get; set; }

        /// <summary>
        /// 提交状态
        /// 0删除、1提交、2草稿
        /// </summary>           
        public int Status { get; set; }

        /// <summary>
        /// 提交状态(文字)
        /// </summary>           
        public string StrStatus { get; set; }

        /// 提交状态(文字 反)
        /// </summary>           
        public string ReverseStrStatus { get; set; }

        /// <summary>
        /// 审批Id
        /// </summary>
        public int AId { get; set; }
        public string StrAId { get; set; }
        #endregion
        
    }
}
