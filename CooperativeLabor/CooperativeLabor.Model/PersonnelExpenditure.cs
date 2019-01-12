using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///人员费
    ///</summary>
    public class PersonnelExpenditure
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
        /// 用工单位
        /// </summary>
        public string EmployingUnit { get; set; }

        /// <summary>
        /// 合作方名称
        /// </summary>           
        public string PartnerName { get; set; }

        /// <summary>
        /// 年度
        /// </summary>           
        public string Year { get; set; }

        /// <summary>
        /// 季度
        /// </summary>           
        public string Quarter { get; set; }

        /// <summary>
        /// 工作完成情况
        /// </summary>           
        public string Completeness { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>           
        public string Post { get; set; }

        /// <summary>
        /// 季度费用
        /// </summary>           
        public double QuarterlyFees { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public string CreationTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>           
        public string ModificationTime { get; set; }
        
        /// <summary>
        /// 提交状态
        /// 0删除、1提交、2草稿
        /// </summary>           
        public int Status { get; set; }

        /// <summary>
        /// 提交状态(文字)
        /// </summary>           
        public string StrStatus { get; set; }
        
        /// 提交状态(文字 反)
        /// </summary>           
        public string ReverseStrStatus { get; set; }

        /// <summary>
        /// 审批Id
        /// </summary>
        public int AId { get; set; }
        public string StrAId { get; set; }
    }
}
