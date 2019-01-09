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
    ///审批流程表
    ///</summary>
    public class ApprovalProcessServices : IApprovalProcessServices
    {
        /// <summary>
        /// 添加审批流程
        /// </summary>
        /// <param name="approvalProcess"></param>
        /// <returns></returns>
        public int AddApprovalProcess(ApprovalProcess approvalProcess)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除审批流程
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteApprovalProcess(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据ID获取审批流程
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ApprovalProcess GetAloneApprovalProcess(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取审批流程
        /// </summary>
        /// <returns></returns>
        public List<ApprovalProcess> GetApprovalProcess()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改审批流程
        /// </summary>
        /// <param name="approvalProcess"></param>
        /// <returns></returns>
        public int UpdateApprovalProcess(ApprovalProcess approvalProcess)
        {
            throw new NotImplementedException();
        }
    }
}
