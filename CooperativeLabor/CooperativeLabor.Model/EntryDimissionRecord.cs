using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///入离职记录
    ///</summary>
    public class EntryDimissionRecord
    {
        /// <summary>
        /// 主键
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>           
        public string Name { get; set; }

        /// <summary>
        /// 人员Id
        /// </summary>           
        public int PersonnelId { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>           
        public string OperationType { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>           
        public DateTime DatesEmployed { get; set; }

        /// <summary>
        /// 离职时间
        /// </summary>           
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>           
        public DateTime ModificationTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>           
        public int IsDelete { get; set; }

    }
}
