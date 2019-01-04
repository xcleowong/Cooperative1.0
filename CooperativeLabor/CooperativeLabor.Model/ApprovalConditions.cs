using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///审批条件表
    ///</summary>
    public class ApprovalConditions
    {
        /// <summary>
        /// 主键
        /// </summary>           
        public int ID { get; set; }

        /// <summary>
        /// 审批条件
        /// </summary>           
        public string Conditions { get; set; }

        /// <summary>
        /// 排序号
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
        /// 编辑人
        /// </summary>           
        public string Editor { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>           
        public DateTime Edittime { get; set; }

    }
}
