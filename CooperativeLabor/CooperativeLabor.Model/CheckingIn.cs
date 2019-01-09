using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///考勤签到
    ///</summary>
    public class CheckingIn
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
        /// 员工名称
        /// </summary>           
        public string StaffName { get; set; }
        
        /// <summary>
        /// 签到时间
        /// </summary>           
        public string SignInTime { get; set; }

        /// <summary>
        /// 签退时间
        /// </summary>           
        public string SignBackTime { get; set; }

        /// <summary>
        /// 签到状态
        /// </summary>
        /// 0迟到、1签到、2签退、3早退、4旷工、5请假、6加班
        public string SignInState { get; set; }

        /// <summary>
        /// 签到状态文字
        /// </summary>
        public string StrState { get; set; }

    }
}
