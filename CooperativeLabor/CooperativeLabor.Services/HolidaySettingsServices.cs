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
    ///假期设置
    ///</summary>
    public class HolidaySettingsServices : IHolidaySettingsServices
    {
        /// <summary>
        /// 添加假期信息
        /// </summary>
        /// <param name="holiday"></param>
        /// <returns></returns>
        public int AddHolidaySettings(HolidaySettings holiday)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                holiday.ModificationTime = System.DateTime.Now;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@OfficeHoursam", holiday.OfficeHoursam, null, null, null);
                parameters.Add("@ClosingTimeam", holiday.ClosingTimeam, null, null, null);
                parameters.Add("@OfficeHourspm", holiday.OfficeHourspm, null, null, null);
                parameters.Add("@ClosingTimepm", holiday.ClosingTimepm, null, null, null);
                parameters.Add("@CreationTime", holiday.CreationTime, null, null, null);
                parameters.Add("@ModificationTime", holiday.ModificationTime, null, null, null);
                parameters.Add("@IsStart", holiday.IsStart, null, null, null);
                string sql = "INSERT INTO holidaysettings(OfficeHoursam,ClosingTimeam,OfficeHourspm,ClosingTimepm,CreationTime,ModificationTime,IsStart) VALUES(@OfficeHoursam,@ClosingTimeam,@OfficeHourspm,@ClosingTimepm,@CreationTime,@ModificationTime,@IsStart)";
                int i = conn.Execute(sql, parameters);
                return i;

            }




        }

        /// <summary>
        /// 删除假期信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteHolidaySettings(int id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id, null, null, null);
                string sql = "DELETE FROM holidaysettings WHERE Id=@Id";
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }

        /// <summary>
        /// 根据ID获取假期信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HolidaySettings GetAloneHolidaySettings(int id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id, null, null, null);
                string sql = "SELECT Id,OfficeHoursam,ClosingTimeam,OfficeHourspm,ClosingTimepm,CreationTime,ModificationTime,IsStart  FROM holidaysettings WHERE Id=@Id";
                HolidaySettings holiday = conn.Query<HolidaySettings>(sql, parameters).FirstOrDefault();
                return holiday;
            }
        }

        /// <summary>
        /// 获取假期信息
        /// </summary>
        /// <returns></returns>
        public List<HolidaySettings> GetHolidaySettings()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = "SELECT Id,OfficeHoursam,ClosingTimeam,OfficeHourspm,ClosingTimepm,CreationTime,ModificationTime,IsStart FROM holidaysettings";
                IEnumerable<HolidaySettings> list = conn.Query<HolidaySettings>(sql, null);
                return list.ToList();
            }
        }

        /// <summary>
        /// 修改假期信息
        /// </summary>
        /// <param name="holiday"></param>
        /// <returns></returns>
        public int UpdateHolidaySettings(HolidaySettings holiday)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                holiday.ModificationTime = System.DateTime.Now;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UP_Id", holiday.Id, null, null, null);
                parameters.Add("UP_OfficeHoursam", holiday.OfficeHoursam, null, null, null);
                parameters.Add("UP_ClosingTimeam", holiday.ClosingTimeam, null, null, null);
                parameters.Add("UP_OfficeHourspm", holiday.OfficeHourspm, null, null, null);
                parameters.Add("UP_ClosingTimepm", holiday.ClosingTimepm, null, null, null);
                parameters.Add("UP_CreationTime", holiday.CreationTime, null, null, null);
                parameters.Add("UP_ModificationTime", holiday.ModificationTime, null, null, null);
                parameters.Add("UP_IsStart", holiday.IsStart, null, null, null);
                
                //string sql = string.Format("update holidaysettings set OfficeHoursam=@OfficeHoursam, ClosingTimeam=@ClosingTimeam, OfficeHourspm=@OfficeHourspm, ClosingTimepm=@ClosingTimepm, CreationTime=@CreationTime, ModificationTime=@ModificationTime, IsStart=@IsStart  where Id=@Id");
                int i = conn.Execute("UP_UpdateHolidaySettings", parameters,commandType:System.Data.CommandType.StoredProcedure);
                return i;

            }


        }
    }
}
