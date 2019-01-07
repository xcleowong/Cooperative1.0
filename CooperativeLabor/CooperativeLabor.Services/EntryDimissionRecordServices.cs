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
    ///入离职记录
    ///</summary>
    public class EntryDimissionRecordServices : IEntryDimissionRecordServices
    {
        /// <summary>
        /// 添加入离职信息
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public int AddEntryDimissionRecord(EntryDimissionRecord entry)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name",entry.Name , null, null, null);
                parameters.Add("@PersonnelId", entry.PersonnelId, null, null, null);
                parameters.Add("@OperationType",entry.OperationType, null, null, null);
                parameters.Add("@DatesEmployed",entry.DatesEmployed , null, null, null);
                parameters.Add("@DepartureTime",entry.DepartureTime , null, null, null);
                parameters.Add("@CreationTime", entry.CreationTime, null, null, null);
                parameters.Add("@ModificationTime", entry.ModificationTime, null, null, null);
                parameters.Add("@IsDelete",entry.IsDelete , null, null, null);
                string sql = "insert into entrydimissionrecord(Name,PersonnelId,OperationType,DatesEmployed,DepartureTime,CreationTime,ModificationTime,IsDelete) VALUES(@Name,@PersonnelId,@OperationType,@DatesEmployed,@DepartureTime,@CreationTime,@ModificationTime,@IsDelete)";
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }
        /// <summary>
        /// 删除入离职信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteEntryDimissionRecord(int id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = string.Format("DELETE from entrydimissionrecord WHERE Id=@Id");
                int result = conn.Execute(sql, new { Id = id });
                return result;
            }
        }
       /// <summary>
       /// 根据Id获取人员信息
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public List<EntryDimissionRecord> GetEntryDimissionRecordById(int id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = "select b.* from entrydimissionrecord a inner join personalinformation b on a.PersonnelId=b.Id where a.PersonnelId=@Id";
                IEnumerable<EntryDimissionRecord> list = conn.Query<EntryDimissionRecord>(sql, new { Id = id });
                return list.ToList();
            }
        }
        /// <summary>
        /// 获取入离职信息
        /// </summary>
        /// <returns></returns>
        public List<EntryDimissionRecord> GetEntryDimissionRecords()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = "select a.Name,a.PersonnelId,a.OperationType,a.DatesEmployed,a.DepartureTime,a.CreationTime,a.ModificationTime,a.IsDelete,b.* from entrydimissionrecord a inner join personalinformation b on a.PersonnelId=b.Id";
                IEnumerable<EntryDimissionRecord> list = conn.Query<EntryDimissionRecord>(sql, null);
                return list.ToList();
            }
        }
        /// <summary>
        /// 修改入离职信息
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        public int UpdateEntryDimissionRecord(EntryDimissionRecord entry)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@OperationType",entry.OperationType , null, null, null);
                parameters.Add("@DatesEmployed",entry.DatesEmployed , null, null, null);
                parameters.Add("@DepartureTime", entry.DepartureTime, null, null, null);
                parameters.Add("@ModificationTime", entry.ModificationTime, null, null, null);
                parameters.Add("@IsDelete", entry.IsDelete, null, null, null);
                parameters.Add("@Id", entry.Id, null, null, null);

                string sql = "update entrydimissionrecord set OperationType=@OperationType,DatesEmployed=@DatesEmployed,DepartureTime=@DepartureTime,ModificationTime=@ModificationTime,IsDelete=@IsDelete where PersonnelId=@Id";
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }
    }
}
