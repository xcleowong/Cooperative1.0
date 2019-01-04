using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///培训费
    ///</summary>
    public class TrainingExpenses
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 申请人姓名
        /// </summary>           
        public string ApplicantName { get; set; }

        /// <summary>
        /// 用工单位
        /// </summary>           
        public string EmployingUnit { get; set; }

        /// <summary>
        /// 合作方名称
        /// </summary>           
        public string PartnerName { get; set; }

        /// <summary>
        /// 岗位
        /// </summary>           
        public string Post { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>           
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>           
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 是否列入培训计划
        /// </summary>           
        public int IsTrainingPlan { get; set; }

        /// <summary>
        /// 职务
        /// </summary>           
        public string Duty { get; set; }

        /// <summary>
        /// 主办单位
        /// </summary>           
        public string Sponsor { get; set; }

        /// <summary>
        /// 培训班名称
        /// </summary>           
        public string TrainingClass { get; set; }

        /// <summary>
        /// 培训地点
        /// </summary>           
        public string CoursePlace { get; set; }

        /// <summary>
        /// 培训方式
        /// </summary>           
        public string TrainingMethods { get; set; }

        /// <summary>
        /// 培训内容
        /// </summary>           
        public string TrainingContent { get; set; }

        /// <summary>
        /// 培训费
        /// </summary>           
        public double Trainingfees { get; set; }

        /// <summary>
        /// 交通费
        /// </summary>           
        public double Transportation { get; set; }

        /// <summary>
        /// 住宿费
        /// </summary>           
        public double Accommodation { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>           
        public double Otherexpenses { get; set; }

    }
}
