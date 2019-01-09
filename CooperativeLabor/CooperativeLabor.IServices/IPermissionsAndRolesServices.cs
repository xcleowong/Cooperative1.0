using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///权限角色关联表
    ///</summary>
    public interface IPermissionsAndRolesServices
    {
        /// <summary>
        /// 添加关联表
        /// </summary>
        /// <param name="add"></param>
        /// <returns></returns>
        int Add(PermissionsAndRoles add);

        /// <summary>
        /// 删除关联信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);

        /// <summary>
        /// 修改关联信息
        /// </summary>
        /// <param name="upt"></param>
        /// <returns></returns>
        int Update(PermissionsAndRoles upt);

        /// <summary>
        /// 根据Id获取关联信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PermissionsAndRoles GetPermissionsAndRolesById(int Id);

        /// <summary>
        /// 根据Id显示单个关联信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PermissionsAndRoles DeletePermissionsAndRolesById(int Id);

        /// <summary>
        /// 显示关联表数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<PermissionsAndRoles> GetPermissionsAndRoles();
    }
}
