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
        public DateTime SignInTime { get; set; }

        /// <summary>
        /// 签退时间
        /// </summary>           
        public DateTime SignBackTime { get; set; }

        /// <summary>
        /// 签到状态
        /// </summary>
        /// 0迟到、1签到、2早退、3旷工、4请假、5加班
        public string SignInState { get; set; }

    }
}
