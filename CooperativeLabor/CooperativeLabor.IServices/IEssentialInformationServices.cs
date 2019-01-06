using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///基本信息
    ///</summary>
    public interface IEssentialInformationServices
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="essentialInformation"></param>
        /// <returns></returns>
        int Add(EssentialInformation essentialInformation);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int Deletes(int Id);

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        EssentialInformation GetEssentialInformationById(int Id);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        IEnumerable<EssentialInformation> GetEssentialInformations();

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="essentialInformation"></param>
        /// <returns></returns>
        int Update(EssentialInformation essentialInformation);
    }
}
