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
    ///审批状态表
    ///</summary>
    public class ApprovalStatusServices : IApprovalStatusServices
    {
        /// <summary>
        /// 添加审批状态
        /// </summary>
        /// <param name="approvalStatus"></param>
        /// <returns></returns>
        public int AddApprovalStatus(ApprovalStatus approvalStatus)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除审批状态
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int DeleteApprovalStatus(int ID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据ID获取审批状态
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ApprovalStatus GetAloneApprovalStatus(int ID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取审批状态
        /// </summary>
        /// <returns></returns>
        public List<ApprovalStatus> GetApprovalStatus()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改审批状态
        /// </summary>
        /// <param name="approvalStatus"></param>
        /// <returns></returns>
        public int UpdateApprovalStatus(ApprovalStatus approvalStatus)
        {
            throw new NotImplementedException();
        }
    }
}
