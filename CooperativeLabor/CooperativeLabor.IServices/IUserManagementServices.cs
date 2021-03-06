﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///用户管理维护表
    ///</summary>
    public interface IUserManagementServices
    {
        /// <summary>
        /// 添加人员管理信息
        /// </summary>
        /// <param name="userManagement"></param>
        /// <returns></returns>
        int Add(UserManagement userManagement);

        /// <summary>
        /// 修改人员管理信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        int Update(UserManagement userManagement);

        /// <summary>
        /// 删除人员管理信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int Delete(int Id);

        /// <summary>
        /// 获取人员管理信息
        /// </summary>
        /// <returns></returns>
        List<UserManagement> GetUserManagements();

        /// <summary>
        /// 根据ID获取人员管理信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        UserManagement GetAloneUserManagementById(int Id);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPassword"></param>
        /// <returns></returns>
        UserManagement Login(string UserName, string UserPassword);


        object getusers(string UserName, string UserPassword);

        /// <summary>
        /// 根据登录时的用户ID获取该管理员权限(url)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       // List<UserManagement> GetUsersPermissionUrl(int id);
    }
}
