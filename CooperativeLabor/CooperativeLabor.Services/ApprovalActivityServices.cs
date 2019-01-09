using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.Services
{
    using CooperativeLabor.Common;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Model;
    using Dapper;
    using MySql.Data.MySqlClient;
    ///<summary>
    ///审批活动表
    ///</summary>
    public class ApprovalActivityServices : IApprovalActivityServices
    {
        /// <summary>
        /// 添加审批活动
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        public int AddApprovalActivity(ApprovalActivity approvalActivity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除审批活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteApprovalActivity(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取审批活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ApprovalActivity GetAloneApprovalActivity(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据ID获取审批活动
        /// </summary>
        /// <returns></returns>
        public List<ApprovalActivity> GetApprovalActivity()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改审批活动
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        public int UpdateApprovalActivity(ApprovalActivity approvalActivity)
        {
            throw new NotImplementedException();
        }
    }
}
