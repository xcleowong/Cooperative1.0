using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CooperativeLabor.IServices
{
    using CooperativeLabor.Model;

    /// <summary>
    /// 差旅休假接口
    /// </summary>
    public interface ITravelOnVacationServices
    {

        /// <summary>
        /// 获取差旅休假信息
        /// </summary>
        /// <param name="StaffId">员工ID</param>
        /// <returns></returns>
        List<TravelOnVacation> GetTravelOnVacations(int StaffId);

        /// <summary>
        /// 根据ID获取单个差旅休假信息
        /// </summary>
        /// <param name="ID">ID</param>
        /// <returns></returns>
        List<TravelOnVacation> GetTravelOnVacationById(int Id);

        /// <summary>
        /// 添加差旅休假信息
        /// </summary>
        /// <param name="travelOnVacation"></param>
        /// <returns></returns>
        int AddTravelOnVacation(TravelOnVacation travelOnVacation);

        /// <summary>
        /// 撤回/删除差旅休假信息
        /// </summary>
        /// <param name="State">状态</param>
        /// <param name="StaffId">员工ID</param>
        /// <param name="Name">员工姓名</param>
        /// <returns></returns>
        int UpdateTravelOnVacation(int State, int Id);


    }
}
