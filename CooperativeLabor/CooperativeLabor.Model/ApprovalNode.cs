using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///审批节点表
    ///</summary>
    public class ApprovalNode
    {
        /// <summary>
        /// 主键
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>           
        public string Name { get; set; }

        /// <summary>
        /// 负责角色
        /// </summary>           
        public string ResponsibleRole { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>           
        public string Creator { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public DateTime CreateTime { get; set; }

    }
}
