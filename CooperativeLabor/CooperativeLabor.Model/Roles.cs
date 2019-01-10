using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;
    ///<summary>
    ///角色表
    ///</summary>
    public class Roles
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>           
        public string RoleName { get; set; }
        public string PermissionName { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>           
        public DateTime CreateTime { get; set; }
        /// <summary>
        ///   权限ID
        /// </summary>
        public string Role_PeremissionIds { get; set; }

        //通过复选框循环遍历获取选中的值
        public string[] PermissionNames { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>           
        public int IsStart { get; set; }

    }
}
