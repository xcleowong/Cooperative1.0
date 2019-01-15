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
    /// 其他费用WebApi
    /// </summary>
    [RoutePrefix("OtherExpense")]
    public class OtherExpensesController : ApiController
    {
        /// <summary>
        /// 其他费用属性注入
        /// </summary>
        [Dependency]
        public IOtherExpensesServices IotherExpensesServices { get; set; }

        /// <summary>
        /// 添加其他费用
        /// </summary>
        /// <param name="otherExpenses"></param>
        /// <returns></returns>
        [Route("AddOtherExpense")]
        public int AddOtherExpense(OtherExpenses otherExpenses)
        {
            otherExpenses.Status = 1;
            otherExpenses.StartTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            otherExpenses.EndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var result = IotherExpensesServices.AddOtherExpense(otherExpenses);
            return result;
        }

        /// <summary>
        /// 绑定下拉
        /// 内容来自合作方入离厂记录中处于‘入厂’状态的合作方数据
        /// </summary>
        /// <returns></returns>
        [Route("GetEntryAndExitRecords")]
        public List<EntryAndExitRecord> GetEntryAndExitRecords()
        {
            var result = IotherExpensesServices.GetEntryAndExitRecords();
            return result;
        }

        /// <summary>
        /// 获取其他费用
        /// </summary>
        /// <param name="otherExpenses"></param>
        /// <returns></returns>
        [Route("GetOtherExpenses")]
        public List<OtherExpenses> GetOtherExpenses(int StaffId)
        {
            //0删除、1提交、2草稿
            //获取其他费用信息
            //Breach List
            List<OtherExpenses> otherExpensesList = new List<OtherExpenses>();
            //查询其他费用
            var list = IotherExpensesServices.GetOtherExpenses(StaffId);
            for (int i = 0; i < list.Count; i++)
            {
                var strStatus = "";//状态文字
                var reverseStrStatus = "";//状态文字（反）
                //0删除、1提交、2草稿
                if (list[i].Status == 1) { strStatus = "已提交 "; reverseStrStatus = "撤回"; }
                if (list[i].Status == 2) { strStatus = "已撤回 "; reverseStrStatus = "删除"; }

                //实例化人员费Model
                OtherExpenses otherExpenses = new OtherExpenses
                {
                    Id = list[i].Id,//主键（自增）
                    StaffId = list[i].StaffId,//填报人ID
                    Informant = list[i].Informant,//填报人
                    EmployingUnit = list[i].EmployingUnit,//用工单位
                    PartnerName = list[i].PartnerName,//合作方名称
                    StartTime = list[i].StartTime,//开始时间
                    EndTime = list[i].EndTime,//结束时间
                    ProjectTypes = list[i].ProjectTypes,//项目类型
                    BankCard = list[i].BankCard,//入账卡号
                    ActualCost = list[i].ActualCost,//实际花费
                    Content = list[i].Content,//事项及内容
                    StaffIds = list[i].StaffIds,//人员Ids
                    Names = list[i].Names,//人员Names
                    ReportedDate = list[i].ReportedDate,//填报时间
                    Status = list[i].Status,//提交状态
                    StrStatus = strStatus,//状态文字
                    ReverseStrStatus = reverseStrStatus,//状态文字（反）
                    AId = list[i].AId//审批活动表Id
                };
                //Add Model In List
                otherExpensesList.Add(otherExpenses);
            }
            return otherExpensesList;
        }

        /// <summary>
        /// 自动显示登录人所在用工单位
        /// </summary>
        /// <param name="UId"></param>
        /// <returns></returns>
        [Route("GetPersonalInformation")]
        public List<PersonalInformation> GetPersonalInformation(int UId)
        {
            var result = IotherExpensesServices.GetPersonalInformation(UId);
            return result;
        }

        /// <summary>
        /// 显示用工单位所有员工
        /// </summary>
        /// <param name="Employingnit">用工单位</param>
        /// <returns></returns>
        [Route("GetPersonalInformations")]
        public List<PersonalInformation> GetPersonalInformations(string Employingnit)
        {
            var result = IotherExpensesServices.GetPersonalInformations(Employingnit);
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
            var status = IotherExpensesServices.GetOtherExpensesById(Id)[0].Status;
            //现提交状态
            if (status == 1)//撤回
            {
                Status = 2;//状态撤回
                result = IotherExpensesServices.RecallOrDelete(Id, Status);
            }
            //现草稿状态
            if (status == 2)//删除
            {
                Status = 0;//状态删除
                result = IotherExpensesServices.RecallOrDelete(Id, Status);
            }
            return result;
        }
        
    }
}
