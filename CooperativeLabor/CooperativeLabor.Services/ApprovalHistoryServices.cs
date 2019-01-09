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
    ///审批历史表
    ///</summary>
    public class ApprovalHistoryServices : IApprovalHistoryServices
    {
        /// <summary>
        /// 添加审批历史
        /// </summary>
        /// <param name="approvalHistory"></param>
        /// <returns></returns>
        public int AddApprovalHistory(ApprovalHistory approvalHistory)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除审批历史
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteApprovalHistory(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ApprovalHistory GetAloneApprovalHistory(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ApprovalHistory> GetApprovalHistory()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改审批历史
        /// </summary>
        /// <param name="approvalHistory"></param>
        /// <returns></returns>
        public int UpdateApprovalHistory(ApprovalHistory approvalHistory)
        {
            throw new NotImplementedException();
        }
    }
}
