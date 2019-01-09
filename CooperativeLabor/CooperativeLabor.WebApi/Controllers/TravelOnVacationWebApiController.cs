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
    /// 差旅休假WebApi
    /// </summary>
    [RoutePrefix("travelOnVacation")]
    public class TravelOnVacationWebApiController : ApiController
    {
        /// <summary>
        /// 差旅休假属性注入
        /// </summary>
        [Dependency]
        public ITravelOnVacationServices ItravelOnVacationServices { get; set; }

        /// <summary>
        /// 添加差旅休假信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("addTravelOnVacation")]
        public int AddTravelOnVacation(TravelOnVacation travelOnVacation)
        {
            var result = ItravelOnVacationServices.AddTravelOnVacation(travelOnVacation);
            return result;
        }

        /// <summary>
        /// 获取差旅休假信息
        /// </summary>
        /// <param name="StaffId"></param>
        /// <param name="StaffName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getTravelOnVacation")]
        public List<TravelOnVacation> GetTravelOnVacations(int StaffId)
        {
            //0删除、1提交、2草稿
            //获取差旅休假信息
            var result = ItravelOnVacationServices.GetTravelOnVacations(StaffId);

            //Breach List
            List<TravelOnVacation> travelOnVacationsList = new List<TravelOnVacation>();
            //查询本月签到情况
            var list = ItravelOnVacationServices.GetTravelOnVacations(StaffId);
            for (int i = 0; i < list.Count; i++)
            {
                var reverseStrState = "";//状态文字(反)
                var strState = "";//状态文字
                //0删除、1提交、2草稿
                if (list[i].State == 1) { strState = "提交中 "; reverseStrState = "撤回 "; }
                if (list[i].State == 2) { strState = "草稿 "; reverseStrState = "删除 "; }

                //实例化差旅休假Model
                TravelOnVacation travelOnVacations = new TravelOnVacation();
                travelOnVacations.Id = list[i].Id;//主键（自增）
                travelOnVacations.StaffId = list[i].StaffId;//员工ID
                travelOnVacations.Name = list[i].Name;//姓名
                travelOnVacations.ApplicationType = list[i].ApplicationType;//申请类型
                travelOnVacations.ApplicationReason = list[i].ApplicationReason;//申请事由
                travelOnVacations.StartTime = list[i].StartTime;//开始时间
                travelOnVacations.EndTime = list[i].EndTime;//结束时间
                travelOnVacations.ComputingTime = list[i].ComputingTime;//计算时长
                travelOnVacations.ApplicationDate = list[i].ApplicationDate;//申请日期
                travelOnVacations.State = list[i].State;//状态
                travelOnVacations.StrState = strState;//状态文字
                travelOnVacations.ReverseStrState = reverseStrState;//状态文字(反)
                //Add Model In List
                travelOnVacationsList.Add(travelOnVacations);
            }
            return travelOnVacationsList;
        }

        /// <summary>
        /// 撤回/删除差旅休假信息
        /// </summary>
        /// <param name="Id">ID</param>
        /// <param name="State">状态</param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateTravelOnVacation")]
        public int UpdateTravelOnVacation( int Id,int State)
        {
            var result = 0;
            var state = ItravelOnVacationServices.GetTravelOnVacationById(Id)[0].State;
            //现提交状态
            if (state == 1)//撤回
            {
                State = 2;//状态撤回
                result = ItravelOnVacationServices.UpdateTravelOnVacation(State, Id);
            }
            //现草稿状态
            if (state == 2)//删除
            {
                State = 0;//状态删除
                result = ItravelOnVacationServices.UpdateTravelOnVacation(State, Id);
            }
            return result;
        }
    }
}
