using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///人员基本信息维护
    ///</summary>
    public class PersonalInformation
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>           
        public string Name { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>           
        public string UserName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>           
        public string Gender { get; set; }

        /// <summary>
        /// 出生年月
        /// </summary>           
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 民族
        /// </summary>           
        public string Nation { get; set; }

        /// <summary>
        /// 用工单位
        /// </summary>           
        public string Employingnit { get; set; }

        /// <summary>
        /// 合作方名称
        /// </summary>           
        public string PartnerName { get; set; }

        /// <summary>
        /// 专业技术资格
        /// </summary>           
        public string ProfessionalSkill { get; set; }

        /// <summary>
        /// 婚否
        /// </summary>           
        public int MaritalStatus { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>           
        public string IDNumber { get; set; }

        /// <summary>
        /// 党派
        /// </summary>           
        public string PartyGroupings { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>           
        public string Email { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>           
        public string Post { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>           
        public string Phone { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>           
        public string CardNo { get; set; }

        /// <summary>
        /// 开户行信息
        /// </summary>           
        public string OpeningBank { get; set; }

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
