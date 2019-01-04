using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///假期设置
    ///</summary>
    public class HolidaySettings
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 上班时间（早）
        /// </summary>           
        public DateTime OfficeHoursam { get; set; }

        /// <summary>
        /// 下班时间（早）
        /// </summary>           
        public DateTime ClosingTimeam { get; set; }

        /// <summary>
        /// 上班时间（下）
        /// </summary>           
        public DateTime OfficeHourspm { get; set; }

        /// <summary>
        /// 下班时间（下）
        /// </summary>           
        public DateTime ClosingTimepm { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>           
        public DateTime ModificationTime { get; set; }

    }
}
