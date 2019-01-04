using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///其他费用
    ///</summary>
    public class OtherExpenses
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 填报人
        /// </summary>           
        public string Informant { get; set; }

        /// <summary>
        /// 用工单位
        /// </summary>           
        public string EmployingUnit { get; set; }

        /// <summary>
        /// 合作方名称
        /// </summary>           
        public string PartnerName { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>           
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>           
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 项目类型
        /// </summary>           
        public string ProjectTypes { get; set; }

        /// <summary>
        /// 入账卡号
        /// </summary>           
        public string BankCard { get; set; }

        /// <summary>
        /// 实际花费
        /// </summary>           
        public double ActualCost { get; set; }

        /// <summary>
        /// 填报时间
        /// </summary>           
        public DateTime ReportedDate { get; set; }

        /// <summary>
        /// 事项及内容
        /// </summary>           
        public string Content { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>           
        public string Name { get; set; }

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
