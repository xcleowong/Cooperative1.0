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
    /// 考勤签到WebApi
    /// </summary>
    [RoutePrefix("checkingIn")]
    public class CheckingInWebApiController : ApiController
    {
        /// <summary>
        /// 考勤签到属性注入
        /// </summary>
        public ICheckingInServices IcheckingInServices { get; set; }

        /// <summary>
        /// 签到/签退
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("checkingIn")]
        public int CheckingIn(CheckingIn checkingIn, int ? aoru)
        {
            //获取假期设置表数据
            var holidaySettings = IcheckingInServices.GetHolidaySettings();
            string officeHoursam = holidaySettings[0].OfficeHoursam;//上班时间
            string closingTimepm = holidaySettings[0].ClosingTimepm;//下班时间

            //实例化
            CheckingIn checkingInEntity = new CheckingIn();

            checkingInEntity.StaffId = 1;//员工ID
            checkingInEntity.StaffName = "张三";
            if (aoru == 1)
            {
                checkingInEntity.SignInTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));//签到时间
            }
            if (aoru == 2)
            {
                checkingInEntity.SignBackTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));//签退时间
            }
            checkingIn.SignInState = "1";//签到状态

            var result = IcheckingInServices.AddCheckingIn(checkingIn);
            return result;
        }

        /// <summary>
        /// 查询本月签到情况
        /// </summary>
        /// <param name="StaffId"></param>
        /// <param name="StaffName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getCheckingIn")]
        public IHttpActionResult GetCheckingIn(int StaffId, string StaffName)
        {
            //查询本月签到情况
            var result = IcheckingInServices.GetCheckingIns(StaffId, StaffName);
            return Json<List<CheckingIn>>(result);
        }

    }
}
