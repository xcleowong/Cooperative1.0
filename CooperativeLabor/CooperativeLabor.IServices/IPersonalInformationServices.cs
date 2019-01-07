using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    ///<summary>
    ///人员基本信息维护
    ///</summary>
    public interface IPersonalInformationServices
    {
        /// <summary>
        /// 获取所有人员基本信息
        /// </summary>
        /// <returns></returns>
        List<PersonalInformation> GetPersonalInformation();
        /// <summary>
        /// 添加人员基本信息
        /// </summary>
        /// <param name="personal"></param>
        /// <returns></returns>
        int AddPersonalInformation(PersonalInformation personal);
        /// <summary>
        /// 删除人员基本信息
        /// </summary>
        /// <param name="personal"></param>
        /// <returns></returns>
        int DeletePersonalInformation(int id);
        /// <summary>
        /// 根据ID获取人员基本信息
        /// </summary>
        /// <returns></returns>
        List<PersonalInformation> GetPersonalInformationById(int id);
        /// <summary>
        /// 修改人员基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int UpdatePersonalInformation(PersonalInformation personal);
    }
}
