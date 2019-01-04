using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///审批流程表
    ///</summary>
    public class ApprovalProcess
    {
        /// <summary>
        /// 主键
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>           
        public string Name { get; set; }

        /// <summary>
        /// 是否允许修改
        /// </summary>           
        public int IsAllowModity { get; set; }

        /// <summary>
        /// 是否允许撤销
        /// </summary>           
        public int IsAllowVersion { get; set; }

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
