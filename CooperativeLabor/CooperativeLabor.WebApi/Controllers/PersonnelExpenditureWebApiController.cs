using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CooperativeLabor.WebApi.Controllers
{
    using CooperativeLabor.Model;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Services;
    using Unity.Attributes;

    /// <summary>
    /// 人员费WebApi
    /// </summary>
    [RoutePrefix("PersonnelExpenditure")]
    public class PersonnelExpenditureWebApiController : ApiController
    {

        /// <summary>
        ///人员费属性注入
        /// </summary>
        [Dependency]
        public IPersonnelExpenditureServices IPersonnelExpenditureServices { get; set; }

        /// <summary>
        /// 添加人员费信息
        /// </summary>
        /// <param name="personnelExpenditure"></param>
        /// <returns></returns>
        [Route("AddPersonnelExpenditure")]
        public int AddPersonnelExpenditure(PersonnelExpenditure personnelExpenditure)
        {
            var breakValue = 0;//返回Id值
            //添加审批活动
            personnelExpenditure.CreationTime = personnelExpenditure.CreationTime + "年";
            personnelExpenditure.CreationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            personnelExpenditure.Status = 1;
            var result = IPersonnelExpenditureServices.AddPersonnelExpenditure(personnelExpenditure);

            //提交成功
            if (result > 0)
            {
                var breakId = IPersonnelExpenditureServices.GetPersonnelExpenditureId(personnelExpenditure.StaffId, personnelExpenditure.Name, personnelExpenditure.EmployingUnit, personnelExpenditure.PartnerName,personnelExpenditure.Year, personnelExpenditure.Quarter, personnelExpenditure.Completeness,  personnelExpenditure.Post, personnelExpenditure.CreationTime)[0].Id;
                //获取审批流程信息
                var name = "人员费审批节点";
                //获取审批流程配置信息
                var approvalProcess = IPersonnelExpenditureServices.GetApprovalProcesses(name);
                #region  批量添加
                //创建多条集合
                var activityList = Enumerable.Range(0, approvalProcess.Count).Select(i => new ApprovalActivity()
                {
                    ProcessID = approvalProcess[i].ProcessID,//审批流程ID
                    StaffId = personnelExpenditure.StaffId,//员工ID
                    Proposer = personnelExpenditure.Name,//申请人
                    NodeID = approvalProcess[i].NodeID,//审批节点ID
                    ProcessCode = approvalProcess[i].ProcessCode,//配置流程编码
                    RoleSector = approvalProcess[i].RoleSector,//审批角色部门
                    ApprovalRoleID = approvalProcess[i].ApprovalRoleID,//审批角色ID
                    NextApprovalRoleID = approvalProcess[i].NextAppRoleId,//下一步审批角色ID
                    ApprovalUserID = approvalProcess[i].AppUserId,//审批人ID
                    NextApprovalUserID = approvalProcess[i].NextAppUserId,//下一步审批人ID
                    ProcessRoleID = approvalProcess[i].ProcessRoleID,//使用流程角色ID
                    JudgmentID = approvalProcess[i].ConditionId, //判断条件ID
                    Condtion = approvalProcess[i].AppStatusId,//审批状态
                    IsAllowModity = 1,// 是否修改
                    IsAllowVersion = 0,//是否撤销
                    ApprovalUser = "",// 实际审批人
                    ApprovalOpinion = "",// 审批意见
                    TureCondtion = 0,//实际审批状态
                    ApprovalTime = DateTime.Now,// 审批时间
                    Creator = approvalProcess[i].Creator,//创建人
                    CreateTime = DateTime.Now,//创建时间
                    Disabled = approvalProcess[i].Disabled,//是否启用
                    PId = approvalProcess[i].PId,// 父级ID
                    PerExpId = breakId,// 人员费ID
                }).ToList<ApprovalActivity>();
                //添加多条
                breakValue = IPersonnelExpenditureServices.AddApprovalActivity(activityList);
            }
            #endregion
            #region
            //for (int i = 0; i < approvalProcess.Count; i++)
            //{
            //    //实例化审批活动表
            //    ApprovalActivity approvalActivity = new ApprovalActivity
            //    {
            //        ProcessID = approvalProcess[i].ProcessID,//审批流程ID
            //        StaffId = personnelExpenditure.StaffId,//员工ID
            //        Proposer = personnelExpenditure.Name,//申请人
            //        NodeID = approvalProcess[i].NodeID,//审批节点ID
            //        ProcessCode = approvalProcess[i].ProcessCode,//配置流程编码
            //        RoleSector = approvalProcess[i].RoleSector,//审批角色部门
            //        ApprovalRoleID = approvalProcess[i].ApprovalRoleID,//审批角色ID
            //        NextApprovalRoleID = approvalProcess[i].NextAppRoleId,//下一步审批角色ID
            //        ApprovalUserID = approvalProcess[i].AppUserId,//审批人ID
            //        NextApprovalUserID = approvalProcess[i].NextAppUserId,//下一步审批人ID
            //        ProcessRoleID = approvalProcess[i].ProcessRoleID,//使用流程角色ID
            //        JudgmentID = approvalProcess[i].ConditionId, //判断条件ID
            //        Condtion = approvalProcess[i].AppStatusId,//审批状态
            //        IsAllowModity = 1,// 是否修改
            //        IsAllowVersion = 0,//是否撤销
            //        ApprovalUser = "",// 实际审批人
            //        ApprovalOpinion = "",// 审批意见
            //        TureCondtion = 0,//实际审批状态
            //        ApprovalTime = DateTime.Now,// 审批时间
            //        Creator = approvalProcess[i].Creator,//创建人
            //        CreateTime = DateTime.Now,//创建时间
            //        PId = approvalProcess[i].PId,// 父级ID
            //        Disabled = approvalProcess[i].Disabled,//是否启用
            //    };
            //    breakId = IPersonnelExpenditureServices.AddApprovalActivity(approvalActivity);
            //}
            #endregion
            return breakValue;
        }


        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="UId">UserId</param>
        /// <returns></returns>
        [Route("GetPersonalInformation")]
        public List<PersonalInformation> GetPersonalInformation(int UId)
        {
            var result = IPersonnelExpenditureServices.GetPersonalInformation(UId);
            return result;
        }

        /// <summary>
        /// 获取人员费用信息
        /// </summary>
        /// <returns></returns>
        [Route("GetPersonnelExpenditures")]
        public List<PersonnelExpenditure> GetPersonnelExpenditures(int StaffId)
        {
            //0删除、1提交、2草稿
            //获取人员费信息
            //Breach List
            List<PersonnelExpenditure> personnelExpendituresList = new List<PersonnelExpenditure>();
            //查询本月签到情况
            var list = IPersonnelExpenditureServices.GetPersonnelExpenditures(StaffId);
            for (int i = 0; i < list.Count; i++)
            {
                var reverseStrStatus = "";//状态文字(反)
                var strStatus = "";//状态文字
                                   //0删除、1提交、2草稿
                if (list[i].Status == 1) { strStatus = "提交中 "; reverseStrStatus = "撤回 "; }
                if (list[i].Status == 2) { strStatus = "草稿 "; reverseStrStatus = "删除 "; }

                //实例化人员费Model
                PersonnelExpenditure personnelExpenditures = new PersonnelExpenditure
                {
                    Id = list[i].Id,//主键（自增）
                    StaffId = list[i].StaffId,//员工ID
                    Name = list[i].Name,//姓名
                    EmployingUnit = list[i].EmployingUnit,//用工单位
                    PartnerName = list[i].PartnerName,//合作方名称
                    Year = list[i].Year,//年度
                    Quarter = list[i].Quarter,//季度
                    CreationTime = list[i].CreationTime,//创建时间
                    Completeness = list[i].Completeness,//工作完成情况
                    Post = list[i].Post,//岗位
                    Status = list[i].Status,//提交状态
                    StrStatus = strStatus,//状态文字
                    ReverseStrStatus = reverseStrStatus,//状态文字(反)
                    AId = list[i].AId//状态文字(反)
                };
                //Add Model In List
                personnelExpendituresList.Add(personnelExpenditures);
            }
            return personnelExpendituresList;
        }

        /// <summary>
        /// 获取人员费用信息By Id
        /// </summary>
        /// <returns></returns>
        List<PersonnelExpenditure> GetPersonnelExpenditureById(int Id)
        {
            var result = IPersonnelExpenditureServices.GetPersonnelExpenditureById(Id);
            return result;
        }

        /// <summary>
        /// 撤回/修改
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [Route("RecallOrDelete")]
        public int RecallOrDelete(int Id, int Status)
        {
            //0删除、1提交、2草稿
            var result = 0;
            var status = IPersonnelExpenditureServices.GetPersonnelExpenditureById(Id)[0].Status;
            //现提交状态
            if (status == 1)//撤回
            {
                Status = 2;//状态撤回
                result = IPersonnelExpenditureServices.RecallOrDelete(Id, Status);
            }
            //现草稿状态
            if (status == 2)//删除
            {
                Status = 0;//状态删除
                result = IPersonnelExpenditureServices.RecallOrDelete(Id, Status);
            }
            return result;
        }

        /// <summary>
        /// 获取审批流程
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public List<ApprovalProcess> GetApprovalProcesses(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加审批活动表
        /// </summary>
        /// <param name="approvalActivity"></param>
        /// <returns></returns>
        public int AddApprovalActivity(ApprovalActivity approvalActivity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取审批活动表
        /// </summary>
        /// <returns></returns>
        public List<ApprovalActivity> GetApprovalActivity()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取审批历史表信息
        /// </summary>
        /// <returns></returns>
        public List<ApprovalHistory> GetApprovalHistories()
        {
            throw new NotImplementedException();
        }

    }
}
