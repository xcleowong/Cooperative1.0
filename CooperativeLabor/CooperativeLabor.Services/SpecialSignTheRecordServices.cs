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
    ///特别签录
    ///</summary>
    public class SpecialSignTheRecordServices:ISpecialSignTheRecordServices
    {
        /// <summary>
        /// 添加特别签录
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public int AddSpecialSignTheRecord(SpecialSignTheRecord special)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StaffId", special.StaffId, null, null, null);
                parameters.Add("@Name", special.Name, null, null, null);
                parameters.Add("@Department", special.Department, null, null, null);
                parameters.Add("@AttendanceDate", special.AttendanceDate, null, null, null);
                parameters.Add("@AttendanceTypes", special.AttendanceTypes, null, null, null);
                parameters.Add("@SignInDate", special.SignInDate, null, null, null);
                parameters.Add("@SignOutDate", special.SignOutDate, null, null, null);
                parameters.Add("@AlterSignInDate", special.AlterSignInDate, null, null, null);
                string sql = "insert into specialsigntherecord(StaffId,Name,Department,AttendanceDate,AttendanceTypes,SignInDate,SignOutDate,AlterSignInDate) values (@StaffId,@Name,@Department,@AttendanceDate,@AttendanceTypes,@SignInDate,@SignOutDate,@AlterSignInDate)";
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }
        /// <summary>
        /// 删除特别签录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteSpecialSignTheRecord(int id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = string.Format("delete from specialsigntherecord where Id=@Id");
                int result = conn.Execute(sql, new { Id = id });
                return result;
            }
        }
        
        /// <summary>
        /// 获取特别签录
        /// </summary>
        /// <returns></returns>
        public List<SpecialSignTheRecord> GetSpecialSignTheRecord()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = "select Id,StaffId,Name,Department,AttendanceDate,AttendanceTypes,SignInDate,SignOutDate,AlterSignInDate,AlterSignOutDate,ThoseSign,SignedTime,SpecialSign FROM specialsigntherecord";
                IEnumerable<SpecialSignTheRecord> list = conn.Query<SpecialSignTheRecord>(sql, null);
                return list.ToList();
            }
        }
        /// <summary>
        /// 修改特别签录
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public int UpdateSpecialSignTheRecord(SpecialSignTheRecord special)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StaffId", special.StaffId, null, null, null);
                parameters.Add("@Name", special.Name, null, null, null);
                parameters.Add("@Department", special.Department, null, null, null);
                parameters.Add("@AttendanceDate", special.AttendanceDate, null, null, null);
                parameters.Add("@AttendanceTypes", special.AttendanceTypes, null, null, null);
                parameters.Add("@SignInDate", special.SignInDate, null, null, null);
                parameters.Add("@SignOutDate", special.SignOutDate, null, null, null);
                parameters.Add("@AlterSignInDate", special.AlterSignInDate, null, null, null);
                parameters.Add("@Id", special.Id, null, null, null);

                string sql = "UPDATE specialsigntherecord set StaffId=@StaffId,Name=@Name,Department=@Department,AttendanceDate=@AttendanceDate,AttendanceTypes=@AttendanceTypes,SignInDate=@SignInDate,SignOutDate=@SignOutDate,AlterSignInDate=@AlterSignInDate where Id=@Id";
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }





    }
}
