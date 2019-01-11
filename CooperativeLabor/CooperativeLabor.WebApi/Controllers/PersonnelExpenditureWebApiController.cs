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
            personnelExpenditure.CreationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ;
            var result = IPersonnelExpenditureServices.AddPersonnelExpenditure(personnelExpenditure);
            return result;
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
