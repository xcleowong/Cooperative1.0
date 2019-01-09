using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;

    /// <summary>
    /// 考勤签到
    /// </summary>
    public interface ICheckingInServices
    {
        /// <summary>
        /// 获取假期设置表数据
        /// </summary>
        /// <returns></returns>
        List<HolidaySettings> GetHolidaySettings();

        /// <summary>
        /// 查询本月签到情况
        /// </summary>
        /// <param name="StaffID">员工ID</param>
        /// <returns></returns>
        List<CheckingIn> GetCheckingIns(int StaffId);

        /// <summary>
        /// 查询特别签录
        /// </summary>
        /// <param name="StaffId">员工ID</param>
        /// <returns></returns>
        List<SpecialSignTheRecord> GetSpecialSignTheRecords(int StaffId );

        /// <summary>
        /// 获取差旅休假信息
        /// </summary>
        /// <param name="StaffId">员工ID</param>
        /// <returns></returns>
        List<TravelOnVacation> GetTravelOnVacations(int StaffId );

        /// <summary>
        /// 添加签到记录
        /// </summary>
        /// <param name="checkingIn">考勤签到</param>
        /// <returns></returns>
        int AddCheckingIn(CheckingIn checkingIn);

        /// <summary>
        /// 获取最新时间的第一条记录
        /// </summary>
        /// <returns></returns>
        List<CheckingIn> GetLatestTime(int staffId);

        /// <summary>
        /// 添加签退记录
        /// </summary>
        /// <param name="checkingIn">考勤签到</param>
        /// <returns></returns>
        int UpdateCheckingIn(int Id, string SignBackTime, string SignInState);


    }
}
