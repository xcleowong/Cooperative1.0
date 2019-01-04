using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///食堂就餐管理费
    ///</summary>
    public class CanteenanagementFee
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 合作方结算人Id
        /// </summary>           
        public int PartnerId { get; set; }

        /// <summary>
        /// 合作方结算人
        /// </summary>           
        public string PartnerName { get; set; }

        /// <summary>
        /// 员工Id
        /// </summary>           
        public int StaffId { get; set; }

        /// <summary>
        /// 员工姓名
        /// </summary>           
        public string StaffName { get; set; }

        /// <summary>
        /// 餐补标准
        /// </summary>           
        public string MealAllowance { get; set; }

        /// <summary>
        /// 餐补金额
        /// </summary>           
        public double MealMoney { get; set; }

        /// <summary>
        /// 季度
        /// </summary>           
        public string Quarter { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>           
        public DateTime ModificationTime { get; set; }

        /// <summary>
        /// 是否上传
        /// </summary>           
        public int IsUpload { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>           
        public int IsDelete { get; set; }

    }
}
