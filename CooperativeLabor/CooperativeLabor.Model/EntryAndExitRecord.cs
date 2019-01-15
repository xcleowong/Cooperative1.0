using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///入离场记录
    ///</summary>
    public class EntryAndExitRecord
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 合作方名称（必填）
        /// </summary>           
        public string PartnerName { get; set; }


        /// <summary>
        /// 合作方类别
        /// </summary>           
        public string PartnerCategory { get; set; }


        /// <summary>
        /// 营业执照
        /// </summary>           
        public string BusinessLicense { get; set; }


        /// <summary>
        /// 操作类型
        /// </summary>           
        public string OperationType { get; set; }


        /// <summary>
        /// 入场时间
        /// </summary>           
        public string ApproachTime { get; set; }


        /// <summary>
        /// 离场时间
        /// </summary>           
        public string Departuretime { get; set; }


        /// <summary>
        /// 备注
        /// </summary>           
        public string Remark { get; set; }


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
        public string CreationTime { get; set; }


        /// <summary>
        /// 修改时间
        /// </summary>           
        public string ModificationTime { get; set; }


        /// <summary>
        /// 是否删除
        /// </summary>           
        public int IsDelete { get; set; }

    }
}