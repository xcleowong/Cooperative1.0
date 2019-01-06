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
    ///差旅休假
    ///</summary>
    public class TravelOnVacationServices : ITravelOnVacationServices
    {
        /// <summary>
        /// 添加差旅休假信息
        /// </summary>
        /// <param name="travelOnVacation"></param>
        /// <returns></returns>
        public int AddTravelOnVacation(TravelOnVacation travelOnVacation)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"insert into TravelOnVacation(StaffId,Name,ApplicationType,ApplicationReason,StartTime,StartTime,ComputingTime,ApplicationDate,State) values(:StaffId,:Name,:ApplicationType,:ApplicationReason,:StartTime,:StartTime,:ComputingTime,:ApplicationDate,:State)";
                var result = conn.Execute(sql, travelOnVacation);
                return result;
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

        /// <summary>
        /// 撤回/删除差旅休假信息
        /// </summary>
        /// <param name="State">状态</param>
        /// <param name="StaffId">员工ID</param>
        /// <param name="Name">员工姓名</param>
        /// <returns></returns>
        public int UpdateTravelOnVacation(int State, int StaffId, string Name)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"update TravelOnVacation set State = :State where StaffId = :StaffId and Name = :Name ";
                var values = new { State , StaffId, Name };
                var result = conn.Execute(sql, values);
                return result;
            }
        }
    }
}
