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
    ///人员基本信息维护
    ///</summary>
    public class PersonalInformationServices : IPersonalInformationServices
    {
        /// <summary>
        /// 添加人员基本信息
        /// </summary>
        /// <param name="personal"></param>
        /// <returns></returns>
        public int AddPersonalInformation(PersonalInformation personal)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name",personal.Name, null, null, null);
                parameters.Add("@UserName",personal.UserName, null, null, null);
                parameters.Add("@Gender",personal.Gender , null, null, null);
                parameters.Add("@Birthday",personal.Birthday , null, null, null);
                parameters.Add("@Nation",personal.Nation , null, null, null);
                parameters.Add("@Employingnit",personal.Employingnit , null, null, null);
                parameters.Add("@PartnerName",personal.PartnerName , null, null, null);
                parameters.Add("@ProfessionalSkill",personal.ProfessionalSkill , null, null, null);
                parameters.Add("@MaritalStatus",personal.MaritalStatus , null, null, null);
                parameters.Add("@IDNumber",personal.IDNumber , null, null, null);
                parameters.Add("@PartyGroupings",personal.PartyGroupings , null, null, null);
                parameters.Add("@Email", personal.Email, null, null, null);
                parameters.Add("@Post", personal.Post, null, null, null);
                parameters.Add("@Phone",personal.Phone , null, null, null);
                parameters.Add("@CardNo", personal.CardNo, null, null, null);
                parameters.Add("@OpeningBank",personal.OpeningBank , null, null, null);
                parameters.Add("@CreationTime",personal.CreationTime , null, null, null);
                parameters.Add("@ModificationTime",personal.ModificationTime , null, null, null);
                parameters.Add("@IsDelete",personal.IsDelete , null, null, null);
                string sql = "insert into personalinformation(Name,UserName,Gender,Birthday,Nation,Employingnit,PartnerName,ProfessionalSkill,MaritalStatus,IDNumber,PartyGroupings,Email,Post,Phone,CardNo,OpeningBank,CreationTime,ModificationTime,IsDelete) VALUES (@Name,@UserName,@Gender,@Birthday,@Nation,@Employingnit,@PartnerName,@ProfessionalSkill,@MaritalStatus,@IDNumber,@PartyGroupings,@Email,@Post,@Phone,@CardNo,@OpeningBank,@CreationTime,@ModificationTime,@IsDelete)";
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }
        /// <summary>
        /// 删除人员基本信息
        /// </summary>
        /// <param name="personal"></param>
        /// <returns></returns>
        public int DeletePersonalInformation(int id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = string.Format("delete from personalinformation where Id=@Id");
                int result = conn.Execute(sql, new { Id = id });
                return result;
            }
        }
        /// <summary>
        /// 获取人员基本信息
        /// </summary>
        /// <returns></returns>
        public List<PersonalInformation> GetPersonalInformation()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = "select Name,UserName,Gender,Birthday,Nation,Employingnit,PartnerName,ProfessionalSkill,MaritalStatus,IDNumber,PartyGroupings,Email,Post,Phone,CardNo,OpeningBank,CreationTime,ModificationTime,IsDelete from personalinformation";
                IEnumerable<PersonalInformation> list = conn.Query<PersonalInformation>(sql,null);
                return list.ToList();
            }
        }
        /// <summary>
        /// 根据ID获取人员基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<PersonalInformation> GetPersonalInformationById(int id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                string sql = "select Name,UserName,Gender,Birthday,Nation,Employingnit,PartnerName,ProfessionalSkill,MaritalStatus,IDNumber,PartyGroupings,Email,Post,Phone,CardNo,OpeningBank,CreationTime,ModificationTime,IsDelete from personalinformation where Id=@Id";
                IEnumerable<PersonalInformation> list = conn.Query<PersonalInformation>(sql, new { Id = id });
                return list.ToList();
            }
        }
        /// <summary>
        /// 修改人员基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpdatePersonalInformation(PersonalInformation personal)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", personal.Name, null, null, null);
                parameters.Add("@UserName", personal.UserName, null, null, null);
                parameters.Add("@Gender", personal.Gender, null, null, null);
                parameters.Add("@Birthday", personal.Birthday, null, null, null);
                parameters.Add("@Nation", personal.Nation, null, null, null);
                parameters.Add("@Employingnit", personal.Employingnit, null, null, null);
                parameters.Add("@PartnerName", personal.PartnerName, null, null, null);
                parameters.Add("@ProfessionalSkill", personal.ProfessionalSkill, null, null, null);
                parameters.Add("@MaritalStatus", personal.MaritalStatus, null, null, null);
                parameters.Add("@IDNumber", personal.IDNumber, null, null, null);
                parameters.Add("@PartyGroupings", personal.PartyGroupings, null, null, null);
                parameters.Add("@Email", personal.Email, null, null, null);
                parameters.Add("@Post", personal.Post, null, null, null);
                parameters.Add("@Phone", personal.Phone, null, null, null);
                parameters.Add("@CardNo", personal.CardNo, null, null, null);
                parameters.Add("@OpeningBank", personal.OpeningBank, null, null, null);
                parameters.Add("@CreationTime", personal.CreationTime, null, null, null);
                parameters.Add("@ModificationTime", personal.ModificationTime, null, null, null);
                parameters.Add("@IsDelete", personal.IsDelete, null, null, null);
                parameters.Add("@Id", personal.Id, null, null, null);

                string sql = "update personalinformation set Name=@Name,UserName=@UserName,Gender=@Gender,Birthday=@Birthday,Nation=@Nation,Employingnit=@Employingnit,PartnerName=@PartnerName,ProfessionalSkill=@ProfessionalSkill,MaritalStatus=@MaritalStatus,IDNumber=@IDNumber,PartyGroupings=@PartyGroupings,Email=@Email,Post=@Post,Phone=@Phone,CardNo=@CardNo,OpeningBank=@OpeningBank,CreationTime=@CreationTime,ModificationTime=@ModificationTime,IsDelete=@IsDelete where Id=@Id";
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }
    }
}
