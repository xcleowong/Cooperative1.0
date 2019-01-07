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
    ///补助标准配置
    ///</summary>
    public class AllowancesServices : IAllowancesServices
    {
        /// <summary>
        /// 添加补助标准
        /// </summary>
        /// <param name="addAllowances"></param>
        /// <returns></returns>
        public int AddAllowances(Allowances addAllowances)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                addAllowances.ModificationTime = DateTime.Now;
                //addAllowances.IsReadOnly = 0;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@WeekDaysSubsidy", addAllowances.WeekDaysSubsidy, null, null, null);
                parameters.Add("@EvectionSubsidy", addAllowances.EvectionSubsidy, null, null, null);
                parameters.Add("@HolidaysOverTime", addAllowances.HolidaysOverTime, null, null, null);
                parameters.Add("@HolidaysRest", addAllowances.HolidaysRest, null, null, null);
                parameters.Add("@ExchangeSubsidy", addAllowances.ExchangeSubsidy, null, null, null);
                parameters.Add("@MealSubsidy", addAllowances.MealSubsidy, null, null, null);
                parameters.Add("@ReleaseTime", addAllowances.ReleaseTime, null, null, null);
                parameters.Add("@ModificationTime", addAllowances.ModificationTime, null, null, null);
                parameters.Add("@HistoricalInformation", addAllowances.HistoricalInformation, null, null, null);
                parameters.Add("@HistoricalInformationNum", addAllowances.HistoricalInformationNum, null, null, null);
                parameters.Add("@IsReadOnly ", addAllowances.IsReadOnly, null, null, null);
                string sql = "INSERT INTO allowances(WeekDaysSubsidy,EvectionSubsidy,HolidaysOverTime,HolidaysRest,ExchangeSubsidy,MealSubsidy,ReleaseTime,ModificationTime,HistoricalInformation,HistoricalInformationNum,IsReadOnly) VALUES(@WeekDaysSubsidy,@EvectionSubsidy,@HolidaysOverTime,@HolidaysRest,@ExchangeSubsidy,@MealSubsidy,@ReleaseTime,@ModificationTime,@HistoricalInformation,@HistoricalInformationNum,@IsReadOnly)";
                int i = conn.Execute(sql, parameters);
                return i;

            }

        }

        /// <summary>
        /// 删除补助标准
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteAllowances(int id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id, null, null, null);
                string sql = "DELETE FROM allowances WHERE Id=@Id";
                int i = conn.Execute(sql, parameters);
                return i;
            }


        }

        /// <summary>
        /// 获取补助标准
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Allowances> GetAllowances()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = "SELECT Id, WeekDaysSubsidy,EvectionSubsidy,HolidaysOverTime,HolidaysRest,ExchangeSubsidy,MealSubsidy,ReleaseTime,ModificationTime,HistoricalInformation,HistoricalInformationNum,IsReadOnly FROM allowances";
                IEnumerable<Allowances> list = conn.Query<Allowances>(sql, null);
                return list.ToList();
            }

        }

        /// <summary>
        /// 根据ID获取补助标准
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Allowances GetAloneAllowances(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id, null, null, null);
                string sql = "SELECT Id, WeekDaysSubsidy,EvectionSubsidy,HolidaysOverTime,HolidaysRest,ExchangeSubsidy,MealSubsidy,ReleaseTime,ModificationTime,HistoricalInformation,HistoricalInformationNum,IsReadOnly FROM allowances WHERE Id=@Id";
                Allowances allowances = conn.Query<Allowances>(sql, parameters).FirstOrDefault();
                return allowances;
            }

        }

        /// <summary>
        /// 修改补助标准
        /// </summary>
        /// <param name="uptAllowances"></param>
        /// <returns></returns>
        public int UpdateAllowances(Allowances uptAllowances)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                uptAllowances.ModificationTime = DateTime.Now;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@WeekDaysSubsidy", uptAllowances.WeekDaysSubsidy, null, null, null);
                parameters.Add("@EvectionSubsidy", uptAllowances.EvectionSubsidy, null, null, null);
                parameters.Add("@HolidaysOverTime", uptAllowances.HolidaysOverTime, null, null, null);
                parameters.Add("@HolidaysRest", uptAllowances.HolidaysRest, null, null, null);
                parameters.Add("@ExchangeSubsidy", uptAllowances.ExchangeSubsidy, null, null, null);
                parameters.Add("@MealSubsidy", uptAllowances.MealSubsidy, null, null, null);
                parameters.Add("@ReleaseTime", uptAllowances.ReleaseTime, null, null, null);
                parameters.Add("@ModificationTime", uptAllowances.ModificationTime, null, null, null);
                parameters.Add("@HistoricalInformation", uptAllowances.HistoricalInformation, null, null, null);
                parameters.Add("@HistoricalInformationNum", uptAllowances.HistoricalInformationNum, null, null, null);
                parameters.Add("@IsReadOnly", uptAllowances.IsReadOnly, null, null, null);
                parameters.Add("@Id", uptAllowances.Id, null, null, null);
                string sql = "UPDATE allowances SET WeekDaysSubsidy=@WeekDaysSubsidy,EvectionSubsidy=@EvectionSubsidy,HolidaysOverTime=@HolidaysOverTime,HolidaysRest=@HolidaysRest,ExchangeSubsidy=@ExchangeSubsidy,MealSubsidy=@MealSubsidy,ReleaseTime=@ReleaseTime,ModificationTime=@ModificationTime,HistoricalInformation=@HistoricalInformation,HistoricalInformationNum=@HistoricalInformationNum,IsReadOnly=@IsReadOnly WHERE Id=@Id";
                int i = conn.Execute(sql, parameters);
                return i;

            }


        }
    }
}
