using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///角色表
    ///</summary>
    public interface IRolesServices
    {
        ///// <summary>
        ///// 获取角色信息
        ///// </summary>
        ///// <returns></returns>
        //IEnumerable<Roles> GetRoles();
        ///// <summary>
        ///// 新增角色
        ///// </summary>
        ///// <param name="addRoles"></param>
        ///// <returns></returns>
        //int Add(Roles addRoles);

        ///// <summary>
        ///// 更新角色
        ///// </summary>
        ///// <param name="uptRoles"></param>
        ///// <returns></returns>
        //int Update(Roles uptRoles);

        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>

        //int Delete(int id);
        ///// <summary>
        ///// 根据ID查询单个角色
        ///// </summary>
        ///// <param name="Id"></param>
        ///// <returns></returns>
        //IEnumerable<Roles> GetRolesById(int Id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        int AddRole(Roles roles);
        /// <summary>
        ///  新增角色
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int DeleteRole(int Id);
        /// <summary>
        /// 根据ID查询单个角色
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Roles GetRolesById(int Id);
        /// <summary>
        /// 获取角色信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<Roles> GetRoles();
        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        int UpdateRoles(Roles roles);

    }
}
