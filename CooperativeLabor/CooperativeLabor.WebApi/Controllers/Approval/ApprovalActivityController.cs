using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CooperativeLabor.WebApi.Controllers.Approval
{
    using CooperativeLabor.Model;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Services;
    using Unity.Attributes;

    [RoutePrefix("ApprovalActivity")]
    public class ApprovalActivityController : ApiController
    {
        /// <summary>
        /// 属性注入
        /// </summary>
        [Dependency]
        public IApprovalActivityServices IapprovalActivity { get; set; }
        
        /// <summary>
        /// 获取审批活动表信息
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="UserName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetApprovalActivities")]
        public List<ApprovalActivity> GetApprovalActivities(int Id, string UserName)
        {
            //定义LIST
            List<ApprovalActivity> approvalActivitiesList = new List<ApprovalActivity>();
            //获取用户角色Id
            var role = IapprovalActivity.GetUserManagements(Id,UserName);
            //循环RolesID
            for (int i = 0; i < role.Count; i++)
            {
                //分割
                var roles = role[i].RoleId.Split(',');
                //遍历数组
                foreach (var r in roles)
                {
                    //取值
                    var perExpId = IapprovalActivity.GetApprovalActivity(Convert.ToInt32(r));
                    for (int j = 0; j < perExpId.Count; j++)
                    {
                        //approvalActivitiesList = IapprovalActivity.GetPersonnelExpenditures(perExpId[j].PerExpId);
                        var list = IapprovalActivity.GetPersonnelExpenditures(perExpId[j].PerExpId);
                        for (int l = 0; l < list.Count; l++)
                        {
                            ApprovalActivity approvalActivity = new ApprovalActivity
                            {
                                Id = list[l].Id,
                                StaffId = list[l].StaffId,
                                Name = list[l].Name,
                                EmployingUnit = list[l].EmployingUnit,
                                PartnerName = list[l].PartnerName,
                                Year = list[l].Year,
                                Quarter = list[l].Quarter,
                                Completeness = list[l].Completeness,
                                Post = list[l].Post,
                                QuarterlyFees = list[l].QuarterlyFees,
                                CreationTime = list[l].CreationTime,
                                Status = list[l].Status,
                                ApprovalUser = list[l].ApprovalUser,
                                ApprovalOpinion = list[l].ApprovalOpinion,
                                TureCondtion = list[l].TureCondtion,
                            };
                            approvalActivitiesList.Add(approvalActivity);
                        }
                    }
                }
            }
            return approvalActivitiesList.ToList();
        }

    }
}
