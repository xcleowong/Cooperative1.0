using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///人员费
    ///</summary>
    public interface IPersonnelExpenditureServices
    {

        /// <summary>
        /// 添加人员费
        /// </summary>
        /// <param name="personnelExpenditure"></param>
        /// <returns></returns>
        int AddPersonnelExpenditure(PersonnelExpenditure personnelExpenditure);


        List<PersonnelExpenditure> GetPersonnelExpenditures();

        /// <summary>
        /// 撤回/删除
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        int RecallOrDelete(int Id);

    }
}
