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
    ///角色表
    ///</summary>
    public class RolesServices : IRolesServices
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public int AddRole(Roles roles)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@RoleName", roles.RoleName, null, null, null);
                parameters.Add("@CreateTime", roles.CreateTime, null, null, null);
                parameters.Add("@Role_PeremissionIds", roles.Role_PeremissionIds, null, null, null);
                parameters.Add("@IsStart", roles.IsStart, null, null, null);
                string sql = "SELECT * FROM roles where RoleName=@RoleName"; // 根据角色名称查询角色
                var role = conn.Query<Roles>(sql, roles);
                int i = -1;
                //判断是否存在角色
                if (role.Count() == 0)
                {
                    //添加角色
                    string sql2 = "insert INTO roles(RoleName,CreateTime,Role_PeremissionIds,IsStart) VALUES(@RoleName,@CreateTime,@Role_PeremissionIds,@IsStart)";
                    var result = conn.Execute(sql2, parameters);

                    //如果上条语句执行成功则执行下面语句
                    if (result > 0)
                    {


                        //根据角色名称查询Id
                        string sql3 = "select Id from roles where RoleName=@RoleName";
                        //返回一个对象(第一个元素)
                        var id = conn.Query<int>(sql3, roles).FirstOrDefault();
                        //分割权限id
                        var permids = roles.Role_PeremissionIds.Split(',');
                        //循环添加到角色权限关联表
                        for (int j = 0; j < permids.Length; j++)
                        {
                            //实例化角色权限关联表
                            PermissionsAndRoles permissionsAndRoles = new PermissionsAndRoles();
                            permissionsAndRoles.RoleId = id;//为角色ID赋值
                            permissionsAndRoles.PermissionId = Convert.ToInt32(permids[j]);//为权限ID赋值
                            permissionsAndRoles.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            //角色权限关联表添加语句
                            string sql4 = "insert into PermissionsAndRoles(PermissionId,RoleId,CreateTime)VALUES(@PermissionId,@RoleId,@CreateTime)";
                            i = conn.Execute(sql4, permissionsAndRoles);
                        }
                    }

                }

                return i;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteRole(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id, null, null, null);
                string sql = "delete from roles where Id=@Id";
                int i = conn.Execute(sql, parameters);
                if (i > 0)
                {
                    string sql2 = "delete from permissionsandroles where RoleId=@Id";
                    var result2 = conn.Execute(sql2, parameters);
                }
                return i;
            }
        }
        /// <summary>
        /// 获取单个角色信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Roles GetRolesById(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id, null, null, null);
                string sql = "SELECT * FROM roles WHERE Id=@Id";
                Roles roles = conn.Query<Roles>(sql, parameters).FirstOrDefault();
                return roles;

            }
        }
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Roles> GetRoles()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = "SELECT * FROM roles";
                IEnumerable<Roles> roles = conn.Query<Roles>(sql, null);
                return roles.ToList();
            }
        }

        /// <summary>
        /// 修改角色信息
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public int UpdateRoles(Roles roles)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", roles.Id, null, null, null);
                parameters.Add("@RoleName", roles.RoleName, null, null, null);
                parameters.Add("@CreateTime", roles.CreateTime, null, null, null);
                parameters.Add("@Role_PeremissionIds", roles.Role_PeremissionIds, null, null, null);
                parameters.Add("@IsStart", roles.IsStart, null, null, null);

                string sql = string.Format("UPDATE roles set  RoleName=@RoleName,CreateTime=@CreateTime,Role_PeremissionIds=@Role_PeremissionIds,IsStart=@IsStart where Id=@Id");
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }


    }
}
