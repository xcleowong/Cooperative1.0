using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///权限角色关联表
    ///</summary>
    public class PermissionsAndRoles
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 权限Id
        /// </summary>           
        public int PermissionId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>           
        public int RoleId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public DateTime CreateTime { get; set; }

    }
}
