using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///权限表
    ///</summary>
    public class Permission
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>           
        public string PermissionName { get; set; }

        /// <summary>
        /// 权限URL
        /// </summary>           
        public string PermissionUrl { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>           
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>           
        public int IsStart { get; set; }

        /// <summary>
        /// pid
        /// </summary>
        public int Pid { get; set; }

    }
}
