using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
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

        /// <summary>
        /// 创建时间
        /// </summary>           
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>           
        public int IsStart { get; set; }

    }
}
