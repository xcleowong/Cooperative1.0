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
        /// 填报人ID
        /// </summary>
        public int StaffId { get; set; }

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
        public string StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>           
        public string EndTime { get; set; }

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
        public decimal ActualCost { get; set; }

        /// <summary>
        /// 填报时间
        /// </summary>           
        public string ReportedDate { get; set; }

        /// <summary>
        /// 事项及内容
        /// </summary>           
        public string Content { get; set; }

        /// <summary>
        /// 人员Ids
        /// </summary>           
        public string StaffIds { get; set; }

        /// <summary>
        /// 人员姓名s
        /// </summary>
        public string Names { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public string CreationTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>           
        public string ModificationTime { get; set; }

        /// <summary>
        /// 撤回/删除/审批中
        /// </summary>           
        public int Status { get; set; }
        /// <summary>
        /// 撤回/删除/审批中(文字)
        /// </summary>
        public string StrStatus { get; set; }
        /// <summary>
        /// 撤回/删除/审批中(反 文字)
        /// </summary>
        public string ReverseStrStatus { get; set; }

        /// <summary>
        /// 审批记录Id
        /// </summary>
        public int AId { get; set; }
    }
}
