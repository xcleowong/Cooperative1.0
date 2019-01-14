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
    ///用户管理维护表
    ///</summary>
    public class UserManagementServices : IUserManagementServices
    {

        /// <summary>
        /// 添加人员管理信息
        /// </summary>
        /// <param name="userManagement"></param>
        /// <returns></returns>
        public int Add(UserManagement userManagement)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", userManagement.UserName, null, null, null);
                parameters.Add("@UserPassword", userManagement.UserPassword, null, null, null);
                parameters.Add("@InstitutionalFramework", userManagement.InstitutionalFramework, null, null, null);
                parameters.Add("@RoleId", userManagement.RoleId, null, null, null);
                parameters.Add("@IsStart", userManagement.IsStart, null, null, null);
                parameters.Add("@CreationTime", userManagement.CreationTime, null, null, null);
                parameters.Add("@ModificationTime", userManagement.ModificationTime, null, null, null);
                string sql = "SELECT * FROM usermanagement where UserName=@UserName"; // 根据角色名称查询角色
                var user = conn.Query<UserManagement>(sql, userManagement);
                int i = -1;
                //判断是否存在角色
                if (user.Count() == 0)
                {
                    //添加角色
                    string sql2 = "INSERT INTO usermanagement(UserName,UserPassword,InstitutionalFramework,RoleId,IsStart,CreationTime,ModificationTime)VALUES(@UserName,@UserPassword,@InstitutionalFramework,@RoleId,IsStart,@CreationTime,@ModificationTime)";
                    var result = conn.Execute(sql2, parameters);


                    //如果上条语句执行成功则执行下面语句
                    if (result > 0)
                    {


                        //根据角色名称查询Id
                        //string sql3 = "select Id from roles where RoleName=@RoleName";
                        string sql3 = "select Id FROM usermanagement where UserName=@UserName";
                        //返回一个对象(第一个元素)
                        var id = conn.Query<int>(sql3, userManagement).FirstOrDefault();
                        //分割权限id
                        var permids = userManagement.RoleId.Split(',');
                        //循环添加到角色权限关联表
                        for (int j = 0; j < permids.Length; j++)
                        {
                            //实例化角色、用户关联表
                            RolesAndUsers rolesAndUsers = new RolesAndUsers();
                            rolesAndUsers.UserId = id;//为用户ID赋值
                            rolesAndUsers.RoleId = Convert.ToInt32(permids[j]);//为角色ID赋值
                            rolesAndUsers.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            //角色、用户关联表添加语句
                            string sql4 = "INSERT into rolesandusers(RoleId,UserId,CreateTime) VALUES(@RoleId,@UserId,@CreateTime);";
                            i = conn.Execute(sql4, rolesAndUsers);
                        }
                    }

                }

                return i;
            }
        }
        /// <summary>
        /// 删除人员管理信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id, null, null, null);
                string sql = "DELETE from usermanagement where Id =@Id";
                int i = conn.Execute(sql, parameters);
                if (i > 0)
                {
                    string sql2 = "delete from rolesandusers where UserId=@Id";
                    var result2 = conn.Execute(sql2, parameters);
                }
                return i;
            }
        }

        /// <summary>
        /// 根据ID获取人员管理信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserManagement GetAloneUserManagementById(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id, null, null, null);
                string sql = "select * FROM usermanagement  WHERE Id=@Id";
                UserManagement userManagement = conn.Query<UserManagement>(sql, parameters).FirstOrDefault();
                return userManagement;

            }
        }

        public UserManagement GetAloneUserManagementById(UserManagement userManagement)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取人员管理信息
        /// </summary>
        /// <returns></returns>
        public List<UserManagement> GetUserManagements()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();

                string sql = "SELECT r.*,rr.RoleId,GROUP_CONCAT(a.RoleName separator ',') as RoleName from rolesandusers as rr JOIN usermanagement as r ON rr.UserId = r.Id JOIN roles AS a ON rr.RoleId = a.Id GROUP BY r.Id,r.UserName";

                IEnumerable<UserManagement> userManagement = conn.Query<UserManagement>(sql, null);
                return userManagement.ToList();
            }
        }

        /// <summary>
        /// 修改人员管理信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Update(UserManagement userManagement)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", userManagement.Id, null, null, null);
                parameters.Add("@UserName", userManagement.UserName, null, null, null);
                parameters.Add("@UserPassword", userManagement.UserPassword, null, null, null);
                parameters.Add("@InstitutionalFramework", userManagement.InstitutionalFramework, null, null, null);
                parameters.Add("@RoleId", userManagement.RoleId, null, null, null);
                parameters.Add("@IsStart", userManagement.IsStart, null, null, null);
                parameters.Add("@CreationTime", userManagement.CreationTime, null, null, null);
                parameters.Add("@ModificationTime", userManagement.ModificationTime, null, null, null);

                string sql = string.Format("UPDATE usermanagement set  UserName=@UserName,UserPassword=@UserPassword,InstitutionalFramework=@InstitutionalFramework,RoleId=@RoleId,IsStart=@IsStart,CreationTime=@CreationTime,ModificationTime=@ModificationTime where Id=@Id");
                int i = conn.Execute(sql, parameters);
                if (i > 0)
                {
                    string sql2 = "delete from rolesandusers where UserId=@Id";
                    var result2 = conn.Execute(sql2, parameters);
                    //如果上条语句执行成功则执行下面语句
                    if (result2 > 0)
                    {
                        //根据角色名称查询Id
                        //string sql3 = "select Id from roles where RoleName=@RoleName";
                        string sql3 = "select Id FROM usermanagement where UserName=@UserName";
                        //返回一个对象(第一个元素)
                        var id = conn.Query<int>(sql3, userManagement).FirstOrDefault();
                        //分割权限id
                        var permids = userManagement.RoleId.Split(',');
                        //循环添加到角色权限关联表
                        for (int j = 0; j < permids.Length; j++)
                        {
                            //实例化角色、用户关联表
                            RolesAndUsers rolesAndUsers = new RolesAndUsers();
                            rolesAndUsers.UserId = id;//为用户ID赋值
                            rolesAndUsers.RoleId = Convert.ToInt32(permids[j]);//为角色ID赋值
                            rolesAndUsers.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            //角色、用户关联表添加语句
                            string sql4 = "INSERT into rolesandusers(RoleId,UserId,CreateTime) VALUES(@RoleId,@UserId,@CreateTime);";
                            i = conn.Execute(sql4, rolesAndUsers);
                        }
                    }
                }
                return i;
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public UserManagement Login(string UserName, string UserPassword)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = "select * from usermanagement where UserName=@UserName and UserPassword=@UserPassword";
                var result = conn.Query<UserManagement>(sql, new { UserName = UserName, UserPassword = UserPassword }).FirstOrDefault();
                if (result != null)
                {
                    string sql1 = "select * from permission where Id in(select  PermissionId  from permissionsandroles where RoleId in(select RoleId from rolesandusers where UserId=(select id from usermanagement where UserName=@UserName and UserPassword=@UserPassword)))";
                    var result2 = conn.Query<Permission>(sql1, new { UserName = UserName, UserPassword = UserPassword });
                    result.ListPermission = result2.ToList();
                    return result;

                }
                else
                {
                    return null;
                }
            }
        }




    }
}
