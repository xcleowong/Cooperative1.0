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
                string sql = @"insert into CheckingIn(StaffId,StaffName,SignInTime,SignBackTime,SignInState) values(:StaffId,:StaffName,:SignInTime,:SignBackTime,:SignInState)";
                var result = conn.Execute(sql, checkingIn);
                return result;
            }
        }

        /// <summary>
        /// 查询本月签到情况
        /// </summary>
        /// <param name="StaffId">员工ID</param>
        /// <param name="StaffName">员工姓名</param>
        /// <returns></returns>
        public List<CheckingIn> GetCheckingIns(int StaffId, string StaffName)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from CheckingIn where StaffId = :StaffId and StaffName = :StaffName";
                var values = new { StaffId, StaffName };
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
        /// <param name="Name">员工姓名</param>
        /// <returns></returns>
        public List<SpecialSignTheRecord> GetSpecialSignTheRecords(int StaffId, string Name)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from SpecialSignTheRecord where StaffId = :StaffId and Name = :Name";
                var values = new { StaffId, Name };
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
        public List<TravelOnVacation> GetTravelOnVacations(int StaffId, string Name)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from TravelOnVacation where StaffId = :StaffId and Name = :Name";
                var values = new { StaffId, Name };
                var result = conn.Query<TravelOnVacation>(sql, values);
                return result.ToList();
            }
        }

    }
}
