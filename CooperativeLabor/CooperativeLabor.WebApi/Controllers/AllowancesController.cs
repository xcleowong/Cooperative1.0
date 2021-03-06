﻿using System;
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
    using Dapper;
    

    /// <summary>
    /// 补助标准配置
    /// </summary>
    [RoutePrefix("Allowances")]
    public class AllowancesController : ApiController
    {
        private const int PAGESIZE = 5;
        //方法一
        //需要引用 using Unity.Attributes;
        /// <summary>
        /// 属性实例化
        /// </summary>
        [Dependency]
        public IAllowancesServices IallowancesServices { get; set; }
        /// <summary>
        /// 添加补助标准
        /// </summary>
        /// <param name="addAllowances"></param>
        /// <returns></returns>
        [Route("AddAllowances")]
        [HttpPost]
        public int AddAllowances(Allowances addAllowances)
        {
            int i = IallowancesServices.AddAllowances(addAllowances);
            return i;
        }

        /// <summary>
        /// 删除补助标准
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DeleteAllowances")]
        [HttpGet]
        public int DeleteAllowances(int id)
        {
            int i = IallowancesServices.DeleteAllowances(id);
            return i;

        }

        /// <summary>
        /// 获取补助标准
        /// </summary>
        /// <returns></returns>
        [Route("GetAllowances")]
        [HttpGet]
        public PageNumber GetAllowances(int? pageIndex)
        {
            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            List<Allowances> listGA = IallowancesServices.GetAllowances().ToList();
            PageNumber pageNumber = new PageNumber();
            pageNumber.DataCount = listGA.Count;
            pageNumber.CurrentPage = Convert.ToInt32(pageIndex);
            pageNumber.TotlePage = (listGA.Count / PAGESIZE) + (listGA.Count % PAGESIZE == 0 ? 0 : 1);
            pageNumber.Data = listGA.Skip((Convert.ToInt32(pageIndex) - 1) * PAGESIZE).Take(PAGESIZE);
            return pageNumber;
        }

      

        /// <summary>
        /// 根据ID获取补助标准
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetAloneAllowances")]
        [HttpGet]
        public Allowances GetAloneAllowances(int Id)
        {
            var aloneAllowances = IallowancesServices.GetAloneAllowances(Id);
            return aloneAllowances;
        }

        /// <summary>
        /// 修改补助标准
        /// </summary>
        /// <param name="uptAllowances"></param>
        /// <returns></returns>
        [Route("UpdateAllowances")]
        [HttpPost]
        public int UpdateAllowances(Allowances uptAllowances)
        {
            int i = IallowancesServices.UpdateAllowances(uptAllowances);
            return i;

        }





    }
}
