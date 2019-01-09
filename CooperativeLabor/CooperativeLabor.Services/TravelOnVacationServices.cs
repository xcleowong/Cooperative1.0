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
                string sql = @"insert into TravelOnVacation(StaffId,Name,ApplicationType,ApplicationReason,StartTime,EndTime,ComputingTime,ApplicationDate,State) values(@StaffId,@Name,@ApplicationType,@ApplicationReason,@StartTime,@EndTime,@ComputingTime,@ApplicationDate,@State)";
                var result = conn.Execute(sql, travelOnVacation);
                return result;
            }
        }

        /// <summary>
        /// 获取差旅休假信息
        /// </summary>
        /// <param name="Id">员工ID</param>
        /// <param name="Name">员工姓名</param>
        /// <returns></returns>
        public List<TravelOnVacation> GetTravelOnVacations(int StaffId)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from TravelOnVacation where StaffId = @StaffId and State <> 0 ";
                var values = new { StaffId };
                var result = conn.Query<TravelOnVacation>(sql, values);
                return result.ToList();
            }
        }
        
        /// <summary>
        /// 根据ID获取单个差旅休假信息
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        public List<TravelOnVacation> GetTravelOnVacationById(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"select * from TravelOnVacation where Id = @Id and State <> 0 ";
                var values = new { Id };
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
        public int UpdateTravelOnVacation(int State, int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = @"update TravelOnVacation set State = @State where Id = @Id ";
                var values = new { State , Id };
                var result = conn.Execute(sql, values);
                return result;
            }
        }
    }
}
