using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;
    
    ///<summary>
    ///假期设置
    ///</summary>
    public interface IHolidaySettingsServices
    {
        /// <summary>
        /// 添加假期信息
        /// </summary>
        /// <param name="holiday"></param>
        /// <returns></returns>
        int AddHolidaySettings(HolidaySettings holiday);

        /// <summary>
        /// 删除假期信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteHolidaySettings(int id);

        /// <summary>
        /// 修改假期信息
        /// </summary>
        /// <param name="holiday"></param>
        /// <returns></returns>
        int UpdateHolidaySettings(HolidaySettings holiday);

        /// <summary>
        /// 获取假期信息
        /// </summary>
        /// <returns></returns>
        List<HolidaySettings> GetHolidaySettings();

        /// <summary>
        /// 根据ID获取假期信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        HolidaySettings GetAloneHolidaySettings(int id);

    }
}
