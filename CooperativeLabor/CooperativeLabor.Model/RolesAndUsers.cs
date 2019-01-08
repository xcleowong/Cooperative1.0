using System;
using System.Linq;
using System.Text;

namespace CooperativeLabor.Model
{
    ///<summary>
    ///角色用户关联表
    ///</summary>
    public class RolesAndUsers
    {
        /// <summary>
        /// 主键（自增）
        /// </summary>           
        public int Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>           
        public int UserId { get; set; }

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
