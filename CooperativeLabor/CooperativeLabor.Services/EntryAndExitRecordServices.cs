using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace CooperativeLabor.Services
{
    using CooperativeLabor.Common;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Model;
    using Dapper;
    using MySql.Data.MySqlClient;
    ///<summary>
    ///入离场记录
    ///</summary>
    public class EntryAndExitRecordServices : IEntryAndExitRecordServices
    {
        public int Add(EntryAndExitRecord entryAndExitRecord)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PartnerName", entryAndExitRecord.PartnerName, null, null, null);
                parameters.Add("@PartnerCategory", entryAndExitRecord.PartnerCategory, null, null, null);
                parameters.Add("@BusinessLicense", entryAndExitRecord.BusinessLicense, null, null, null);
                parameters.Add("@OperationType", entryAndExitRecord.OperationType, null, null, null);
                parameters.Add("@ApproachTime", entryAndExitRecord.ApproachTime, null, null, null);
                parameters.Add("@Departuretime", entryAndExitRecord.Departuretime, null, null, null);
                parameters.Add("@Remark", entryAndExitRecord.Remark, null, null, null);
                parameters.Add("@AttachmentName", entryAndExitRecord.AttachmentName, null, null, null);
                parameters.Add("@AttachmentPath", entryAndExitRecord.AttachmentPath, null, null, null);
                parameters.Add("@CreationTime", entryAndExitRecord.CreationTime, null, null, null);
                parameters.Add("@ModificationTime", entryAndExitRecord.ModificationTime, null, null, null);
                parameters.Add("@IsDelete", entryAndExitRecord.IsDelete, null, null, null);
                string sql = "INSERT INTO EntryAndExitRecord(PartnerName, PartnerCategory, BusinessLicense, OperationType, ApproachTime, Departuretime, Remark, AttachmentName, AttachmentPath, CreationTime, ModificationTime, IsDelete)VALUES(@PartnerName,@PartnerCategory,@BusinessLicense,@OperationType,@ApproachTime,@Departuretime,@Remark,@AttachmentName,@AttachmentPath,@CreationTime,@ModificationTime,@IsDelete)";
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id",Id,null,null,null);
                string sql = string.Format("DELETE FROM EntryAndExitRecord WHERE Id = @Id");
                int i = conn.Execute(sql,parameters);
                return i;
            }
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public EntryAndExitRecord GetEntryAndExitRecordById(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id, null, null, null);
                string sql = string.Format("SELECT * FROM EntryAndExitRecord WHERE Id = @Id");
                var result =conn.Query<EntryAndExitRecord>(sql, parameters).SingleOrDefault();
                return result;
            }
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EntryAndExitRecord> GetEntryAndExitRecords()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                //conn.Open();
               
                string sql = string.Format("SELECT * FROM EntryAndExitRecord");
                var result = conn.Query<EntryAndExitRecord>(sql,null).ToList();
                return result;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entryAndExitRecord"></param>
        /// <returns></returns>
        public int Update(EntryAndExitRecord entryAndExitRecord)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();

               // entryAndExitRecord.ModificationTime =Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm")); 
                entryAndExitRecord.ModificationTime = DateTime.Now.ToString();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", entryAndExitRecord.Id, null, null, null);
                parameters.Add("@PartnerName", entryAndExitRecord.PartnerName, null, null, null);
                parameters.Add("@PartnerCategory", entryAndExitRecord.PartnerCategory, null, null, null);
                parameters.Add("@BusinessLicense", entryAndExitRecord.BusinessLicense, null, null, null);
                parameters.Add("@OperationType", entryAndExitRecord.OperationType, null, null, null);
                parameters.Add("@ApproachTime", entryAndExitRecord.ApproachTime, null, null, null);
                parameters.Add("@Departuretime", entryAndExitRecord.Departuretime, null, null, null);
                parameters.Add("@Remark", entryAndExitRecord.Remark, null, null, null);
                parameters.Add("@AttachmentName", entryAndExitRecord.AttachmentName, null, null, null);
                parameters.Add("@AttachmentPath", entryAndExitRecord.AttachmentPath, null, null, null);
                parameters.Add("@CreationTime", entryAndExitRecord.CreationTime, null, null, null);
                parameters.Add("@ModificationTime", entryAndExitRecord.ModificationTime, null, null, null);
                parameters.Add("@IsDelete", entryAndExitRecord.IsDelete, null, null, null);
                string sql =string.Format("UPDATE EntryAndExitRecord SET PartnerName=@PartnerName,PartnerCategory=@PartnerCategory,BusinessLicense=@BusinessLicense," +
                    "OperationType=@OperationType,ApproachTime=@ApproachTime,Departuretime=@Departuretime,Remark=@Remark,AttachmentName=@AttachmentName,AttachmentPath=@AttachmentPath," +
                    "CreationTime=@CreationTime,ModificationTime=@ModificationTime,IsDelete=@IsDelete WHERE Id = @Id");
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }
        /// <summary>
        /// 获取合作方Id，名称
        /// </summary>
        /// <returns></returns>
        public List<EntryAndExitRecord> GetEntryByIdName()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = string.Format("select Id,PartnerName from EntryAndExitRecord");
                var result = conn.Query<EntryAndExitRecord>(sql, null).ToList();
                return result;
            }
        }

    }
}
