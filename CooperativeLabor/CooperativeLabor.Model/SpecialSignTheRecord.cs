using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///特别签录
    ///</summary>
    public class SpecialSignTheRecord
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
        /// 部门
        /// </summary>           
        public string Department { get; set; }

        /// <summary>
        /// 出勤日期
        /// </summary>           
        public DateTime AttendanceDate { get; set; }

        /// <summary>
        /// 出勤类型
        /// </summary>           
        public string AttendanceTypes { get; set; }

        /// <summary>
        /// 签录时间
        /// </summary>           
        public DateTime SignInDate { get; set; }

        /// <summary>
        /// 签退时间
        /// </summary>           
        public DateTime SignOutDate { get; set; }

        /// <summary>
        /// 修改签到时间
        /// </summary>           
        public DateTime AlterSignInDate { get; set; }

        /// <summary>
        /// 修改签退时间
        /// </summary>           
        public DateTime AlterSignOutDate { get; set; }

        /// <summary>
        /// 特签人
        /// </summary>           
        public string ThoseSign { get; set; }

        /// <summary>
        /// 特签时间
        /// </summary>           
        public DateTime SignedTime { get; set; }

        /// <summary>
        /// 特签原由
        /// </summary>           
        public string SpecialSign { get; set; }

    }
}
