using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///特别签录
    ///</summary>
    public interface ISpecialSignTheRecordServices
    {
        /// <summary>
        /// 添加特别签录
        /// </summary>
        /// <param name="special"></param>
        /// <returns></returns>
        int AddSpecialSignTheRecord(SpecialSignTheRecord special);
        /// <summary>
        /// 删除特别签录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteSpecialSignTheRecord(int id);
        /// <summary>
        /// 获取特别签录
        /// </summary>
        /// <returns></returns>
        List<SpecialSignTheRecord> GetSpecialSignTheRecord();
        /// <summary>
        /// 修改特别签录
        /// </summary>
        /// <param name="special"></param>
        /// <returns></returns>
        int UpdateSpecialSignTheRecord(SpecialSignTheRecord special);


    }
}
