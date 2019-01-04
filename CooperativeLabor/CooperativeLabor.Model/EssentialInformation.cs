using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///基本信息
    ///</summary>
    public class EssentialInformation
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 合作方名称
        /// </summary>           
        public string PartnerName { get; set; }

        /// <summary>
        /// 合作方类别
        /// </summary>           
        public string PartnerCategory { get; set; }

        /// <summary>
        /// 营业执照名称
        /// </summary>           
        public string BusinessLicenseName { get; set; }

        /// <summary>
        /// 营业执照URL
        /// </summary>           
        public string BusinessLicenseURL { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>           
        public int IsStart { get; set; }

        /// <summary>
        /// 备注
        /// </summary>           
        public string Remark { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>           
        public string Post { get; set; }

        /// <summary>
        /// 技术等级
        /// </summary>           
        public string TechnicalGrade { get; set; }

        /// <summary>
        /// 月薪
        /// </summary>           
        public double MonthlyPay { get; set; }

        /// <summary>
        /// 单位入账卡号
        /// </summary>           
        public string BankCard { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>           
        public DateTime ModificationTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>           
        public int IsDelete { get; set; }

    }
}
