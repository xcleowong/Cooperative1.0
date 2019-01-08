using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///权限表
    ///</summary>
    public interface IPermissionServices
    {
        /// <summary>
        /// 添加
        /// </summary>
        int AddPermission(Permission permission);

        /// <summary>
        /// 显示
        /// </summary>
        IEnumerable<Permission> GetPermissions();

        /// <summary>
        ///删除
        /// </summary>
        int DeletePermission(int Id);

        /// <summary>
        /// 修改
        /// </summary>
        int UpdatePermission(Permission permission);

        /// <summary>
        /// 根据id获取的单个权限
        /// </summary>
        Permission GetPermissionById(int Id);

        /// <summary>
        ///根据PID显示权限信息
        /// </summary>
        IEnumerable<Permission> GetPermissionsByPid(int Pid);

        /// <summary>
        /// 获取权限名称
        /// </summary>
        /// <returns></returns>
        IEnumerable<Permission> GetPermissionName();

        /// <summary>
        /// 获取一级导航栏
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IEnumerable<Permission> GetNavigationOne(int Id);

        /// <summary>
        /// 获取二级导航栏
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IEnumerable<Permission> GetNavigationTwo(int Id);

        /// <summary>
        /// 获取三级导航栏
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
       // IEnumerable<Permission> GetNavigationThree(int Id);
    }
}
