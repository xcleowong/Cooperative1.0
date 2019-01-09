using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.Services
{
    using CooperativeLabor.Common;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Model;
    using Dapper;
    using MySql.Data.MySqlClient;

    ///<summary>
    ///考勤签到Services
    ///</summary>
    public class CheckingInServices : ICheckingInServices
    {
        /// <summary>
        /// 添加签到记录
        /// </summary>
        /// <param name="checkingIn">考勤签到</param>
        /// <returns></returns>
        public int AddCheckingIn(CheckingIn checkingIn)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"insert into CheckingIn(StaffId,StaffName,SignInTime,SignBackTime,SignInState) values(@StaffId,@StaffName,@SignInTime,@SignBackTime,@SignInState)";
                var result = conn.Execute(sql, checkingIn);
                return result;
            }
        }

        /// <summary>
        /// 获取最新时间的第一条记录
        /// </summary>
        /// <returns></returns>
        public List<CheckingIn> GetLatestTime(int staffId)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"SELECT * FROM checkingin WHERE StaffId = @staffId ORDER BY SignInTime DESC LIMIT 1";
                var values = new { StaffId = staffId };
                var result = conn.Query<CheckingIn>(sql, values);
                return result.ToList();
            }
        }

        /// <summary>
        /// 添加签退记录
        /// </summary>
        /// <param name="checkingIn">考勤签到</param>
        /// <returns></returns>
        public int UpdateCheckingIn(int Id, string SignBackTime, string SignInState)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"update CheckingIn set SignBackTime=@SignBackTime,SignInState=@SignInState where Id = @Id";
                var values = new { Id, SignBackTime, SignInState };
                var result = conn.Execute(sql, values);
                return result;
            }
        }

        /// <summary>
        /// 查询本月签到情况
        /// </summary>
        /// <param name="StaffId">员工ID</param>
        /// <returns></returns>
        public List<CheckingIn> GetCheckingIns(int StaffId)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = "select * from CheckingIn where StaffId = @StaffId ";
                var values = new { StaffId };
                var result = conn.Query<CheckingIn>(sql, values);
                return result.ToList();
            }
        }

        /// <summary>
        /// 获取假期设置表数据
        /// </summary>
        /// <returns></returns>
        public List<HolidaySettings> GetHolidaySettings()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from Holidaysettings where IsStart = 1 ";
                var result = conn.Query<HolidaySettings>(sql, null);
                return result.ToList();
            }
        }

        /// <summary>
        /// 查询特别签录
        /// </summary>
        /// <param name="StaffId">员工ID</param>
        /// <returns></returns>
        public List<SpecialSignTheRecord> GetSpecialSignTheRecords(int StaffId )
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from SpecialSignTheRecord where StaffId = @StaffId ";
                var values = new { StaffId };
                var result = conn.Query<SpecialSignTheRecord>(sql, values);
                return result.ToList();
            }
        }

        /// <summary>
        /// 获取差旅休假信息
        /// </summary>
        /// <param name="StaffId">员工ID</param>
        /// <param name="Name">员工姓名</param>
        /// <returns></returns>
        public List<TravelOnVacation> GetTravelOnVacations(int StaffId )
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from TravelOnVacation where StaffId = @StaffId";
                var values = new { StaffId };
                var result = conn.Query<TravelOnVacation>(sql, values);
                return result.ToList();
            }
        }

    }
}
