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
    ///权限角色关联表
    ///</summary>
    public class PermissionsAndRolesServices : IPermissionsAndRolesServices
    {
        /// <summary>
        /// 添加关联表信息
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        public int Add(PermissionsAndRoles add)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PermissionId", add.PermissionId, null, null, null);
                parameters.Add("@RoleId", add.RoleId, null, null, null);
                parameters.Add("@CreateTime", add.CreateTime, null, null, null);
                string sql = "INSERT INTO permissionsandroles (PermissionId,RoleId,CreateTime) VALUES(PermissionId,RoleId,CreateTime)";
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }
        /// <summary>
        /// 删除关联信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据Id删除关联信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PermissionsAndRoles DeletePermissionsAndRolesById(int Id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 显示关联表数据
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PermissionsAndRoles> GetPermissionsAndRoles()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据Id获取关联信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PermissionsAndRoles GetPermissionsAndRolesById(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id, null, null, null);
                string sql = "SELECT *  FROM permissionsandroles WHERE Id=@Id";
                PermissionsAndRoles result = conn.Query<PermissionsAndRoles>(sql, parameters).FirstOrDefault();
                return result;
            }
        }
        /// <summary>
        /// 修改关联信息
        /// </summary>
        /// <param name="upt"></param>
        /// <returns></returns>
        public int Update(PermissionsAndRoles upt)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", upt.Id, null, null, null);
                parameters.Add("@PermissionId", upt.PermissionId, null, null, null);
                parameters.Add("@RoleId", upt.RoleId, null, null, null);
                parameters.Add("@CreateTime", upt.CreateTime, null, null, null);
                string sql = "UPDATE permissionsandroles SET PermissionId=@PermissionId,RoleId=@RoleId,CreateTime=@CreateTime WHERE Id=@Id)";
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }
    }
}
