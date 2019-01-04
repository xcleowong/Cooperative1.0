using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///差旅费
    ///</summary>
    public class TravelExpense
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 登录人Id
        /// </summary>           
        public int UserId { get; set; }

        /// <summary>
        /// 登录人姓名
        /// </summary>           
        public string UserName { get; set; }

        /// <summary>
        /// 申请日期
        /// </summary>           
        public DateTime ApplicationDate { get; set; }

        /// <summary>
        /// 总额
        /// </summary>           
        public double Rental { get; set; }

        /// <summary>
        /// 事由
        /// </summary>           
        public string Reasons { get; set; }

        /// <summary>
        /// 备注
        /// </summary>           
        public string Remark { get; set; }

        /// <summary>
        /// 出差日期
        /// </summary>           
        public DateTime TravelDate { get; set; }

        /// <summary>
        /// 返程日期
        /// </summary>           
        public DateTime ReturnDate { get; set; }

        /// <summary>
        /// 起始地点
        /// </summary>           
        public string StartSite { get; set; }

        /// <summary>
        /// 到达地点
        /// </summary>           
        public string ArriveSite { get; set; }

        /// <summary>
        /// 乘车类型
        /// </summary>           
        public string BusType { get; set; }

        /// <summary>
        /// 费用
        /// </summary>           
        public double Cost { get; set; }

        /// <summary>
        /// 附件名称
        /// </summary>           
        public string AttachmentName { get; set; }

        /// <summary>
        /// 附件Path
        /// </summary>           
        public string AttachmentPath { get; set; }

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
