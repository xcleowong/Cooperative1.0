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
        public int AddUserManagement(UserManagement userManagement)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除人员管理信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int DeleteUserManagement(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据ID获取人员管理信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public UserManagement GetAloneUserManagement(int Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取人员管理信息
        /// </summary>
        /// <returns></returns>
        public List<UserManagement> GetUserManagements()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 修改人员管理信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int UpdateUserManagement(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
