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
    ///权限表
    ///</summary>
    public class PermissionServices : IPermissionServices
    {
        /// <summary>
        /// 添加权限信息
        /// </summary>
        public int AddPermission(Permission permission)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PermissionName", permission.PermissionName,null,null,null);
                parameters.Add("@PermissionUrl", permission.PermissionUrl,null,null,null);
                parameters.Add("@CreateTime", permission.CreateTime,null,null,null);
                parameters.Add("@IsStart", permission.IsStart,null,null,null);
                parameters.Add("@Pid", permission.Pid,null,null,null);
                string sql = "INSERT into permission(PermissionName,PermissionUrl,CreateTime,IsStart,Pid)VALUES(@PermissionName,@PermissionUrl,@CreateTime,@IsStart,@Pid)";
                int i = conn.Execute(sql,parameters);
                return i;
            }
        }
        /// <summary>
        /// 显示权限信息
        /// </summary>
        public IEnumerable<Permission> GetPermissions()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = string.Format("SELECT * from permission ");
                IEnumerable<Permission> permissions = conn.Query<Permission>(sql,null);
                return permissions.ToList();
            }
        }
        /// <summary>
        /// 删除权限信息
        /// </summary>
        public int DeletePermission(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id",Id, null, null, null);
                string sql = string.Format("DELETE FROM permission where Id =@Id");
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }
        /// <summary>
        /// 修改权限信息
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int UpdatePermission(Permission permission)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", permission.Id, null, null, null);
                parameters.Add("@PermissionName", permission.PermissionName, null, null, null);
                parameters.Add("@PermissionUrl", permission.PermissionUrl, null, null, null);
                parameters.Add("@CreateTime", permission.CreateTime, null, null, null);
                parameters.Add("@IsStart", permission.IsStart, null, null, null);
                parameters.Add("@Pid", permission.Pid, null, null, null);
                string sql = "UPDATE permission set PermissionName=@PermissionName,PermissionUrl=@PermissionUrl,CreateTime=@CreateTime,IsStart=@IsStart,Pid=@Pid WHERE Id =@Id";
                int i = conn.Execute(sql, parameters);
                return i;
            }
        }
        /// <summary>
        ///根据ID显示权限信息
        /// </summary>
        public Permission GetPermissionById(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id, null, null, null);
                string sql = string.Format("SELECT * from permission where Id =@Id");
                Permission permission = conn.Query<Permission>(sql, parameters).FirstOrDefault();
                return permission;
            }
        }
        /// <summary>
        /// 获取权限名称
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Permission> GetPermissionName()
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                string sql = string.Format("SELECT Id,PermissionName,Pid from permission where Pid!=0");
                IEnumerable<Permission> permissions = conn.Query<Permission>(sql, null);
                return permissions.ToList() ;
            }
        }

        /// <summary>
        ///根据PID显示权限信息
        /// </summary>
        public IEnumerable<Permission> GetPermissionsByPid(int Pid)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Pid", Pid, null, null, null);
                string sql = string.Format("SELECT * from permission where Pid =@Pid");
                var result = conn.Query<Permission>(sql, parameters);
                return result.ToList();
            }
        }
        
        /// <summary>
        /// 获取一级导航栏
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IEnumerable<Permission> GetNavigationOne(int Id)
        {
            #region
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id, null, null, null);
                string sql = string.Format("SELECT* FROM permission WHERE Id IN(SELECT Pid FROM permission WHERE Id IN (SELECT PermissionId FROM permissionsandroles WHERE RoleId IN (SELECT RoleId FROM RolesAndUsers WHERE UserId = @Id)))");
                var result = conn.Query<Permission>(sql, parameters);
                return result.ToList();
            }
            #endregion

        }

        /// <summary>
        /// 获取二级导航栏
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IEnumerable<Permission> GetNavigationTwo(int Id)
        {
            using (MySqlConnection conn = DapperHelper.GetConnString())
            {
                conn.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id, null, null, null);
                string sql = "SELECT * FROM permission WHERE Id IN (SELECT PermissionId FROM permissionsandroles where RoleId IN (SELECT RoleId FROM RolesAndUsers WHERE UserId =@Id))";
                IEnumerable<Permission> list = conn.Query<Permission>(sql, parameters);
                return list.ToList();
            }
        }
        /// <summary>
        /// 获取三级导航栏
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        //public IEnumerable<Permission> GetNavigationThree(int Id)
        //{
            //using (MySqlConnection conn = DapperHelper.GetConnString())
            //{
            //    conn.Open();
            //    DynamicParameters parameters = new DynamicParameters();
            //    parameters.Add("@Id", Id, null, null, null);
            //    string sql = "SELECT * FROM permission WHERE Id IN (SELECT PermissionId FROM permissionsandroles where RoleId IN (SELECT RoleId FROM RolesAndUsers WHERE UserId =@Id))";
            //    IEnumerable<Permission> list = conn.Query<Permission>(sql, parameters);
            //    return list.ToList();
            //}
        //}
       
       
    }
}
