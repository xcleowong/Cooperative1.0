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
    ///审批节点表
    ///</summary>
    public class ApprovalNodeServices : IApprovalNodeServices
    {
        /// <summary>
        /// 添加审批节点
        /// </summary>
        /// <param name="approvalNode"></param>
        /// <returns></returns>
        public int AddApprovalNode(ApprovalNode approvalNode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除审批节点
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteApprovalNode(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据ID获取审批节点
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ApprovalNode GetAloneApprovalNode(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取审批节点
        /// </summary>
        /// <returns></returns>
        public List<ApprovalNode> GetApprovalNode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改审批节点
        /// </summary>
        /// <param name="approvalNode"></param>
        /// <returns></returns>
        public int UpdateApprovalNode(ApprovalNode approvalNode)
        {
            throw new NotImplementedException();
        }
    }
}
