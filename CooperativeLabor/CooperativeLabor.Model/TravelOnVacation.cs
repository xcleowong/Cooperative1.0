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
        /// 员工ID
        /// </summary>
        public int StaffId { get; set; }

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
        public string StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>           
        public string EndTime { get; set; }

        /// <summary>
        /// 计算时长
        /// </summary>           
        public string ComputingTime { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>           
        public string ApplicationDate { get; set; }

        /// <summary>
        /// 状态
        /// 0删除、1提交、2草稿
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 状态文字
        /// </summary>
        public string StrState { get; set; }

        /// <summary>
        /// 状态文字(反)
        /// </summary>
        public string ReverseStrState { get; set; }

    }
}
