using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///审批状态表
    ///</summary>
    public class ApprovalStatus
    {
        /// <summary>
        /// 主键
        /// </summary>           
        public int ID { get; set; }

        /// <summary>
        /// 审批状态
        /// </summary>           
        public int Condtion { get; set; }

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
