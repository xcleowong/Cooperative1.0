using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    using System.Collections.Generic;
    ///<summary>
    ///用户管理维护表
    ///</summary>
    public class UserManagement
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>           
        public string UserName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>           
        public string UserPassword { get; set; }

        /// <summary>
        /// 用户组织机构
        /// </summary>           
        public string InstitutionalFramework { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>           
        public string RoleId { get; set; }

        public string[] RoleIds { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>           
        public string RoleName { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>           
        public int IsStart { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>           
        public DateTime ModificationTime { get; set; }

        /// <summary>
        /// 权限集合
        /// </summary>
        public List<Permission> ListPermission { get; set; }

    }
}
