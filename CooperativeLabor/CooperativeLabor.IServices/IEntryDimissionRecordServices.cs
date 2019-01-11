using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///入离职记录
    ///</summary>
    public interface IEntryDimissionRecordServices
    {
        /// <summary>
        /// 获取所有入离职记录
        /// </summary>
        /// <returns></returns>
        List<EntryDimissionRecord> GetEntryDimissionRecords();
        /// <summary>
        /// 添加入离职记录
        /// </summary>
        /// <param name="personal"></param>
        /// <returns></returns>
        int AddEntryDimissionRecord(EntryDimissionRecord entry);
        /// <summary>
        /// 删除入离职记录
        /// </summary>
        /// <param name="personal"></param>
        /// <returns></returns>
        int DeleteEntryDimissionRecord(int id);
        /// <summary>
        /// 根据ID获取入离职记录
        /// </summary>
        /// <returns></returns>
        List<EntryDimissionRecord> GetEntryDimissionRecordById(int id);
        /// <summary>
        /// 修改入离职记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdateEntryDimissionRecord(EntryDimissionRecord entry);

        /// <summary>
        /// 获取人员基本信息
        /// </summary>
        /// <returns></returns>
        List<PersonalInformation> GetPersonals();
    }
}
