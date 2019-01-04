using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///差旅休假
    ///</summary>
    public class TravelOnVacation
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>           
        public string Name { get; set; }

        /// <summary>
        /// 申请类型
        /// </summary>           
        public string ApplicationType { get; set; }

        /// <summary>
        /// 申请事由
        /// </summary>           
        public string ApplicationReason { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>           
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>           
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 计算时长
        /// </summary>           
        public double ComputingTime { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>           
        public DateTime ApplicationDate { get; set; }

    }
}
