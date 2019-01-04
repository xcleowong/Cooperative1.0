using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///补助标准配置
    ///</summary>
    public class Allowances
    {
        /// <summary>
        /// 主键
        /// </summary>           
        public int Id { get; set; }

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
        /// 发布时间
        /// </summary>           
        public DateTime ReleaseTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>           
        public DateTime ModificationTime { get; set; }

        /// <summary>
        /// 历史信息
        /// </summary>           
        public string HistoricalInformation { get; set; }

        /// <summary>
        /// 历史信息次数
        /// </summary>           
        public int HistoricalInformationNum { get; set; }

        /// <summary>
        /// 是否只读
        /// </summary>           
        public int IsReadOnly { get; set; }

    }
}
