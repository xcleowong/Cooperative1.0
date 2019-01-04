using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///季度补助支出
    ///</summary>
    public class QuarterlySubsidyExpenditure
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 费用结算人
        /// </summary>           
        public string FeeSettler { get; set; }

        /// <summary>
        /// 员工数量
        /// </summary>           
        public int StaffNum { get; set; }

        /// <summary>
        /// 平日工作补助
        /// </summary>           
        public double WeekDaysSubsidy { get; set; }

        /// <summary>
        /// 出差补助
        /// </summary>           
        public double EvectionSubsidy { get; set; }

        /// <summary>
        /// 公休节假日加班
        /// </summary>           
        public double HolidaysOverTime { get; set; }

        /// <summary>
        /// 公休节假日休息
        /// </summary>           
        public double HolidaysRest { get; set; }

        /// <summary>
        /// 倒休补助
        /// </summary>           
        public double ExchangeSubsidy { get; set; }

        /// <summary>
        /// 每日餐补
        /// </summary>           
        public double MealSubsidy { get; set; }

        /// <summary>
        /// 补助标准
        /// </summary>           
        public string Allowances { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>           
        public DateTime ModificationTime { get; set; }

        /// <summary>
        /// 是否提交
        /// </summary>           
        public int IsCommit { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>           
        public int IsDelete { get; set; }

    }
}
