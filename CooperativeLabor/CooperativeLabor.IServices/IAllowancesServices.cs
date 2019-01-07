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
        /// 新增补助标准
        /// </summary>
        /// <param name="addAllowances"></param>
        /// <returns></returns>
        int AddAllowances(Allowances addAllowances);

        /// <summary>
        /// 删除补助标准
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteAllowances(int id);

        /// <summary>
        /// 修改补助标准
        /// </summary>
        /// <param name="uptAllowances"></param>
        /// <returns></returns>
        int UpdateAllowances(Allowances uptAllowances);

        /// <summary>
        /// 显示补助标准
        /// </summary>
        /// <returns></returns>
        IEnumerable<Allowances> GetAllowances();

        /// <summary>
        /// 根据ID获取补助标准
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Allowances GetAloneAllowances(int Id);
    }
}
