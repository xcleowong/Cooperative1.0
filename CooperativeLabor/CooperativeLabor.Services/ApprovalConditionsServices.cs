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
    ///审批条件表
    ///</summary>
    public class ApprovalConditionsServices : IApprovalConditionsServices
    {
        /// <summary>
        /// 添加审批条件
        /// </summary>
        /// <param name="approvalConditions"></param>
        /// <returns></returns>
        public int AddApprovalConditions(ApprovalConditions approvalConditions)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除审批条件
        /// </summary>
        /// <param name="approvalConditions"></param>
        /// <returns></returns>
        public int DeleteApprovalConditions(int ID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据ID获取审批条件
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ApprovalConditions GetAloneApprovalCondition(int ID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取审批条件
        /// </summary>
        /// <returns></returns>
        public List<ApprovalConditions> GetApprovalConditions()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改审批条件
        /// </summary>
        /// <param name="approvalConditions"></param>
        /// <returns></returns>
        public int UpdateApprovalConditions(ApprovalConditions approvalConditions)
        {
            throw new NotImplementedException();
        }
    }
}
