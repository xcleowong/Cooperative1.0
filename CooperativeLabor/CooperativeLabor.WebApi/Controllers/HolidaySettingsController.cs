using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CooperativeLabor.WebApi.Controllers
{
    using CooperativeLabor.Model;
    using CooperativeLabor.Services;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Cache;
    using Unity.Attributes;
    /// <summary>
    /// 假期设置
    /// </summary>
    [RoutePrefix("HolidaySettings")]
    public class HolidaySettingsController : ApiController
    {
        //方法一
        //需要引用 using Unity.Attributes;
        /// <summary>
        /// 属性实例化
        /// </summary>
        [Dependency]
        public IHolidaySettingsServices holidaySettings  { get; set; }

        /// <summary>
        /// 添加假期信息
        /// </summary>
        /// <param name="holiday"></param>
        /// <returns></returns>
        [Route("AddHolidaySettings")]
        [HttpPost]
        public int AddHolidaySettings(HolidaySettings holiday)
        {
            int i = holidaySettings.AddHolidaySettings(holiday);
            return i;

        }

        /// <summary>
        /// 删除假期信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DeleteHolidaySettings")]
        [HttpGet]
        public int DeleteHolidaySettings(int id)
        {
            int i = holidaySettings.DeleteHolidaySettings(id);
            return i;
        }

        /// <summary>
        /// 根据ID获取假期信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetAloneHolidaySettings")]
        [HttpGet]
        public HolidaySettings GetAloneHolidaySettings(int id)
        {
            var aloneHoliday = holidaySettings.GetAloneHolidaySettings(id);
            return aloneHoliday;
        }

        /// <summary>
        /// 获取假期信息
        /// </summary>
        /// <returns></returns>
        [Route("GetHolidaySettings")]
        [HttpGet]
        public List<HolidaySettings> GetHolidaySettings()
        {
            var list = holidaySettings.GetHolidaySettings();
            return list;
        }

        /// <summary>
        /// 修改假期信息
        /// </summary>
        /// <param name="holiday"></param>
        /// <returns></returns>
        [Route("UpdateHolidaySettings")]
        [HttpPost]
        public int UpdateHolidaySettings(HolidaySettings holiday)
        {
            int i = holidaySettings.UpdateHolidaySettings(holiday);
            return i;

        }





    }
}
