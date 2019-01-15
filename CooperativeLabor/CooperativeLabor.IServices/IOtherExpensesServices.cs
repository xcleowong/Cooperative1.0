using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///其他费用
    ///</summary>
    public interface IOtherExpensesServices
    {

        /// <summary>
        /// 自动显示登录人所在用工单位
        /// </summary>
        /// <param name="UId"></param>
        /// <returns></returns>
        List<PersonalInformation> GetPersonalInformation(int UId);

        /// <summary>
        /// 自动显示登录人所在用工单位
        /// </summary>
        /// <param name="UId"></param>
        /// <returns></returns>
        List<PersonalInformation> GetPersonalInformations(string Employingnit);

        /// <summary>
        /// 绑定下拉
        /// 内容来自合作方入离厂记录中处于‘入厂’状态的合作方数据
        /// </summary>
        /// <returns></returns>
        List<EntryAndExitRecord> GetEntryAndExitRecords();

        /// <summary>
        /// 获取其他费用
        /// </summary>
        /// <param name="StaffId"></param>
        /// <returns></returns>
        List<OtherExpenses> GetOtherExpenses(int StaffId);

        /// <summary>
        /// 获取其他费用By Id
        /// </summary>
        /// <param name="StaffId"></param>
        /// <returns></returns>
        List<OtherExpenses> GetOtherExpensesById(int Id);

        /// <summary>
        /// 添加其他费用
        /// </summary>
        /// <param name="otherExpenses"></param>
        /// <returns></returns>
        int AddOtherExpense(OtherExpenses otherExpenses);

        /// <summary>
        /// 撤回/修改
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        int RecallOrDelete(int Id, int Status);

    }
}
