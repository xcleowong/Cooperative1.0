using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///入离场记录
    ///</summary>
    public interface IEntryAndExitRecordServices
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entryAndExitRecord"></param>
        /// <returns></returns>
        int Add(EntryAndExitRecord entryAndExitRecord);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        int Delete(int Id);

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        IEnumerable<EntryAndExitRecord> GetEntryAndExitRecords();



        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entryAndExitRecord"></param>
        /// <returns></returns>
        int Update(EntryAndExitRecord entryAndExitRecord);

        /// <summary>
        /// 获取单个信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        EntryAndExitRecord GetEntryAndExitRecordById(int Id);
        /// <summary>
        /// 获取合作方Id，名称
        /// </summary>
        /// <returns></returns>
        List<EntryAndExitRecord> GetEntryByIdName();

    }
}
