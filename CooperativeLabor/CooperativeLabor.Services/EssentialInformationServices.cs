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
    ///基本信息
    ///</summary>
    public class EssentialInformationServices : IEssentialInformationServices
    {
        public int Add(EssentialInformation essentialInformation)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PartnerName", essentialInformation.PartnerName, null, null, null);
                parameters.Add("@PartnerCategory", essentialInformation.PartnerCategory, null, null, null);
                parameters.Add("@BusinessLicenseName", essentialInformation.BusinessLicenseName, null, null, null);
                parameters.Add("@BusinessLicenseURL", essentialInformation.BusinessLicenseURL, null, null, null);
                parameters.Add("@IsStart", essentialInformation.IsStart, null, null, null);
                parameters.Add("@Remark", essentialInformation.Remark, null, null, null);
                parameters.Add("@Post", essentialInformation.Post, null, null, null);
                parameters.Add("@TechnicalGrade", essentialInformation.TechnicalGrade, null, null, null);
                parameters.Add("@MonthlyPay", essentialInformation.MonthlyPay, null, null, null);
                parameters.Add("@BankCard", essentialInformation.BankCard, null, null, null);
                parameters.Add("@CreationTime", essentialInformation.CreationTime, null, null, null);
                parameters.Add("@ModificationTime", essentialInformation.ModificationTime, null, null, null);
                parameters.Add("@IsDelete", essentialInformation.IsDelete, null, null, null);
                string sql = string.Format("INSERT INTO EssentialInformation(PartnerName, PartnerCategory, BusinessLicenseName, BusinessLicenseURL, IsStart, Remark, Post, TechnicalGrade, MonthlyPay, BankCard, CreationTime, ModificationTime, IsDelete)" +
                    "VALUES(@PartnerName, @PartnerCategory, @BusinessLicenseName, @BusinessLicenseURL, @IsStart, @Remark, @Post, @TechnicalGrade, @MonthlyPay, @BankCard, @CreationTime, @ModificationTime, @IsDelete)");
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }

        public int Deletes(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id, null, null, null);
                string sql = string.Format("DELETE FROM EssentialInformation WHERE Id = @Id");
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }

        public EssentialInformation GetEssentialInformationById(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id, null, null, null);
                string sql = string.Format("SELECT * FROM EssentialInformation WHERE Id = @Id");
                var result = conn.Query<EssentialInformation>(sql, parameters).SingleOrDefault();
                return result;
            };
        }

        public IEnumerable<EssentialInformation> GetEssentialInformations()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();

                string sql = string.Format("SELECT * FROM EssentialInformation");
                var result = conn.Query<EssentialInformation>(sql, null).ToList();
                return result;
            }
        }

        public int Update(EssentialInformation essentialInformation)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", essentialInformation.Id, null, null, null);
                parameters.Add("@PartnerName", essentialInformation.PartnerName, null, null, null);
                parameters.Add("@PartnerCategory", essentialInformation.PartnerCategory, null, null, null);
                parameters.Add("@BusinessLicenseName", essentialInformation.BusinessLicenseName, null, null, null);
                parameters.Add("@BusinessLicenseURL", essentialInformation.BusinessLicenseURL, null, null, null);
                parameters.Add("@IsStart", essentialInformation.IsStart, null, null, null);
                parameters.Add("@Remark", essentialInformation.Remark, null, null, null);
                parameters.Add("@Post", essentialInformation.Post, null, null, null);
                parameters.Add("@TechnicalGrade", essentialInformation.TechnicalGrade, null, null, null);
                parameters.Add("@MonthlyPay", essentialInformation.MonthlyPay, null, null, null);
                parameters.Add("@BankCard", essentialInformation.BankCard, null, null, null);
                parameters.Add("@CreationTime", essentialInformation.CreationTime, null, null, null);
                parameters.Add("@ModificationTime", essentialInformation.ModificationTime, null, null, null);
                parameters.Add("@IsDelete", essentialInformation.IsDelete, null, null, null);             
               string sql = string.Format("UPDATE EssentialInformation SET PartnerName = @PartnerName, PartnerCategory = @PartnerCategory, BusinessLicenseName = @BusinessLicenseName," +
               " BusinessLicenseURL = @BusinessLicenseURL, IsStart = @IsStart, Remark =@Remark, Post = @Post, TechnicalGrade = @TechnicalGrade, MonthlyPay = @MonthlyPay, BankCard =@BankCard, " +
               "CreationTime =@CreationTime, ModificationTime = @ModificationTime, IsDelete = @IsDelete WHERE Id = @Id");
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }
    }
}
