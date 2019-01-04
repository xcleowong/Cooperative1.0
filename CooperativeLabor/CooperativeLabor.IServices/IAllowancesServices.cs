using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///补助标准配置
    ///</summary>
    public interface IAllowancesServices
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="addAllowances"></param>
        /// <returns></returns>
        int Add(Allowances addAllowances);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="uptAllowances"></param>
        /// <returns></returns>
        int Update(Allowances uptAllowances);

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        IEnumerable<Allowances> GetAllowances();
    }
}
