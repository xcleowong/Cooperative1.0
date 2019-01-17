using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CooperativeLabor.WebApi.Controllers.shenpi
{
    using CooperativeLabor.Model;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Services;
    using Unity.Attributes;
    [RoutePrefix("ApprovalActivity")]
    public class ApprovalActivityController : ApiController
    {
        [Dependency]
        public IApprovalActivityServices approvalActivity { get; set; }
        /// <summary>
        /// 添加审批活动
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        [Route("AddApprovalActivity")]
        [HttpPost]
        public int AddApprovalActivity(ApprovalActivity approvalActivity)
        {
            int i = this.approvalActivity.AddApprovalActivity(approvalActivity);
            return i;
        }

        /// <summary>
        /// 删除审批活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("DeleteApprovalActivity")]
        [HttpGet]
        public int DeleteApprovalActivity(int Id)
        {
            int i = this.approvalActivity.DeleteApprovalActivity(Id);
            return i;
        }

        /// <summary>
        /// 根据ID获取审批活动
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetApprovalActivityById")]
        [HttpGet]
        public ApprovalActivity GetApprovalActivityById(int Id)
        {
            var result = this.approvalActivity.GetApprovalActivityById(Id);
            return result;
        }

        /// <summary>
        /// 获取审批活动
        /// </summary>
        /// <returns></returns>
        [Route("GetApprovalActivity")]
        [HttpGet]
        public List<ApprovalActivity> GetApprovalActivity()
        {
            var result = this.approvalActivity.GetApprovalActivity();
            return result;
        }

        /// <summary>
        /// 修改审批活动
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        [Route("UpdateApprovalActivity")]
        [HttpPost]
        public int UpdateApprovalActivity(ApprovalActivity approvalActivity)
        {
            int i = this.approvalActivity.UpdateApprovalActivity(approvalActivity);
            return i;
        }
    }
}
