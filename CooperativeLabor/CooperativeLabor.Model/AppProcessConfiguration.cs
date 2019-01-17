using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///审批流程配置表
    ///</summary>
    public class AppProcessConfiguration
    {
        /// <summary>
        /// 主键
        /// </summary>           
        public int Id { get; set; }

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
        public int NextAppRoleId { get; set; }

        /// <summary>
        /// 审批人ID
        /// </summary>           
        public int AppUserId { get; set; }

        /// <summary>
        /// 下一步审批人ID
        /// </summary>           
        public int NextAppUserId { get; set; }

        /// <summary>
        /// 使用流程角色ID
        /// </summary>           
        public string ProcessRoleID { get; set; }

        /// <summary>
        /// 判断条件ID
        /// </summary>           
        public int ConditionId { get; set; }

        /// <summary>
        /// 审批状态
        /// </summary>           
        public int AppStatusId { get; set; }

        /// <summary>
        /// 排序ID
        /// </summary>           
        public int Sort { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>           
        public string Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 父级Id
        /// </summary>
        public int PId { get; set; }

        /// <summary>
        /// 使用启用
        /// </summary>
        public int Disabled { get; set; }
    }
}
