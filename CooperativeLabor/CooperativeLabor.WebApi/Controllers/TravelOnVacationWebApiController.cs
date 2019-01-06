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
        [Route("getTravelOnVacations")]
        public IHttpActionResult GetTravelOnVacations(int StaffId, string StaffName)
        {
            //获取差旅休假信息
            var result = ItravelOnVacationServices.GetTravelOnVacations(StaffId, StaffName);
            return Json<List<TravelOnVacation>>(result);
        }

        /// <summary>
        /// 撤回/删除差旅休假信息
        /// </summary>
        /// <param name="State">状态</param>
        /// <param name="StaffId">员工ID</param>
        /// <param name="Name">员工姓名</param>
        /// <returns></returns>
        [HttpPost]
        [Route("updateTravelOnVacation")]
        public int UpdateTravelOnVacation(int State, int StaffId, string Name)
        {
            var result = ItravelOnVacationServices.UpdateTravelOnVacation( State, StaffId, Name);
            return result;
        }
    }
}
