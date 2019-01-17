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
        private const int PAGESIZE = 5;
        /// <summary>
        /// 考勤签到属性注入
        /// </summary>
        [Dependency]
        public ICheckingInServices IcheckingInServices { get; set; }

        /// <summary>
        /// 签到/签退
        /// </summary>
        /// <param name="checkingIn"></param>
        /// <param name="aoru">1签到/0签退</param>
        /// <returns></returns>
        [HttpPost]
        [Route("checkingIn")]
        public int CheckingIn(int staffId, string staffName, int aoru)
        {
            var result = 0;
            //获取假期设置表数据
            var holidaySettings = IcheckingInServices.GetHolidaySettings();
            string officeHoursam = holidaySettings[0].OfficeHoursam;//上班时间
            string closingTimepm = holidaySettings[0].ClosingTimepm;//下班时间

            var currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//签到/签退时间
            //去掉字符串的前12个字符
            var time = currentTime.Remove(0, 12);
            var time1 = currentTime.Substring(12);
            var time2 = "07:00:00";

            //var backTime = DateDiff(Convert.ToDateTime(officeHoursam), Convert.ToDateTime(time2));
            //0迟到、1签到、2签退、3早退、4旷工、5请假、6加班
            var strSignInState = "";
            var breakMsg = CompanyDate(officeHoursam, time2);
            if (breakMsg == 0)//未
            {
                if (aoru == 1)//签到
                {
                    strSignInState += "1";
                }
                if (aoru == 2)//签退
                {
                    strSignInState += "3";
                }
            }
            if (breakMsg == 1)//过
            {
                if (aoru == 1)//签到
                {
                    strSignInState += "0";
                }
                if (aoru == 2)//签退
                {
                    strSignInState += "2";
                }
            }
            //实例化
            CheckingIn checkingInEntity = new CheckingIn();

            checkingInEntity.StaffId = staffId;//员工ID
            checkingInEntity.StaffName = staffName;//员工姓名
            if (aoru == 1)//签到
            {
                checkingInEntity.SignInTime = currentTime;//签到时间
                checkingInEntity.SignInState = strSignInState;//签到状态
                result = IcheckingInServices.AddCheckingIn(checkingInEntity);
            }
            if (aoru == 2)//签退
            {
                var checkingInList = IcheckingInServices.GetLatestTime(staffId);
                var checkingInId = checkingInList[0].Id;//签到ID
                var signBackTime = currentTime;//签退时间
                var signInState = checkingInList[0].SignInState + "," + strSignInState;//签到状态
                result = IcheckingInServices.UpdateCheckingIn(checkingInId, signBackTime, signInState);
            }
            return result;
        }

        #region 返回时间差
        /// <summary>
        /// 比较两个时间大小
        /// </summary>
        /// <param name="dateStr1"></param>
        /// <param name="dateStr2"></param>
        /// <param name="msg"></param>
        public int CompanyDate(string dateStr1, string dateStr2)
        {
            int msg = 0;
            //将日期字符串转换为日期对象
            DateTime dateTime1 = Convert.ToDateTime(dateStr1);
            DateTime dateTime2 = Convert.ToDateTime(dateStr2);
            //通过DateTime.Compare()进行比较
            int compNum = DateTime.Compare(dateTime1, dateTime2);

            if (compNum > 0)
            {
                msg = 0;
            }
            if (compNum < 0)
            {
                msg = 1;
            }
            return msg;
        }
        #endregion

        /// <summary>
        /// 查询本月签到情况
        /// </summary>
        /// <param name="StaffId"></param>
        /// <param name="StaffName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getCheckingIn")]
        public PageNumber GetCheckingIn(int StaffId, int? pageIndex)
        {
            if (pageIndex==null)
            {
                pageIndex = 1;
            }
            List<CheckingIn> checkingInsList = new List<CheckingIn>();
            //查询本月签到情况
            var list = IcheckingInServices.GetCheckingIns(StaffId);
            PageNumber pageNumber = new PageNumber();
            for (int i = 0; i < list.Count; i++)
            {
                var strState = "";
                var signInStateArry = list[i].SignInState.Split(',');
                foreach (var item in signInStateArry)
                {
                    //0迟到、1签到、2签退、3早退、4旷工、5请假、6加班
                    if (item.ToString() == "0") { strState += "迟到 "; }
                    if (item.ToString() == "1") { strState += "已签到 "; }
                    if (item.ToString() == "2") { strState += "已签退 "; }
                    if (item.ToString() == "3") { strState += "早退 "; }
                    if (item.ToString() == "4") { strState += "旷工 "; }
                    if (item.ToString() == "5") { strState += "请假 "; }
                    if (item.ToString() == "6") { strState += "加班 "; }
                }

                //实例化考勤签到Model
                CheckingIn checkingIn = new CheckingIn();
                checkingIn.Id = list[i].Id;
                checkingIn.StaffId = list[i].StaffId;
                checkingIn.StaffName = list[i].StaffName;
                checkingIn.SignInTime = list[i].SignInTime;
                checkingIn.SignBackTime = list[i].SignBackTime;
                checkingIn.SignInState = list[i].SignInState;
                checkingIn.StrState = strState;
                //Add Model In List
                checkingInsList.Add(checkingIn);
            }
            //分页 
            pageNumber.DataCount = checkingInsList.Count;
            pageNumber.CurrentPage = Convert.ToInt32(pageIndex);
            pageNumber.TotlePage = (checkingInsList.Count / PAGESIZE) + (checkingInsList.Count % PAGESIZE == 0 ? 0 : 1);
            pageNumber.Data = checkingInsList.Skip((Convert.ToInt32(pageIndex) - 1) * PAGESIZE).Take(PAGESIZE);
            return pageNumber;
        }

    }
}
