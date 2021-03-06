﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CooperativeLabor.WebApi.Controllers
{
    using IServices;
    using Model;

    [RoutePrefix("PersonalInformation")]
    public class PersonalInformationController : ApiController
    {
        private const int PAGESIZE = 5;
        IPersonalInformationServices personals = null;
        public PersonalInformationController(IPersonalInformationServices ipersonal)
        {
            personals = ipersonal;
        }
        /// <summary>
        /// 添加人员基本信息
        /// </summary>
        /// <param name="personal"></param>
        /// <returns></returns>
        [Route("AddPersonalInformation")]
        [HttpPost]
        public int AddPersonalInformation(PersonalInformation personal)
        {
            int i = personals.AddPersonalInformation(personal);
            return i;
        }
        /// <summary>
        /// 删除人员基本信息
        /// </summary>
        /// <param name="personal"></param>
        /// <returns></returns>
        [Route("DeletePersonalInformation")]
        [HttpPost]
        public int DeletePersonalInformation(int id)
        {
            int i = personals.DeletePersonalInformation(id);
            return i;
        }
        /// <summary>
        /// 获取人员基本信息
        /// </summary>
        /// <returns></returns>
        [Route("GetPersonalInformation")]
        [HttpGet]
        public PageNumber GetPersonalInformation(int? pageIndex,string name="",string employingnit="",string partnerName="")
        {

            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            List<PersonalInformation> listGA = personals.GetPersonalInformation().ToList();
            PageNumber pageNumber = new PageNumber();
            if (!string.IsNullOrWhiteSpace(name))
            {
                listGA = listGA.Where(m => m.Name.Contains(name)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(employingnit))
            {
                listGA = listGA.Where(m => m.Employingnit.Contains(employingnit)).ToList();
            }
            if (!string.IsNullOrWhiteSpace(partnerName))
            {
                listGA = listGA.Where(m => m.PartnerName.Contains(partnerName)).ToList();
            }
            pageNumber.DataCount = listGA.Count;
            pageNumber.CurrentPage = Convert.ToInt32(pageIndex);
            pageNumber.TotlePage = (listGA.Count / PAGESIZE) + (listGA.Count % PAGESIZE == 0 ? 0 : 1);
            pageNumber.Data = listGA.Skip((Convert.ToInt32(pageIndex) - 1) * PAGESIZE).Take(PAGESIZE);
            return pageNumber;
            
        }
        /// <summary>
        /// 根据ID获取人员基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetPersonalInformationById")]
        [HttpGet]
        public List<PersonalInformation> GetPersonalInformationById(int id)
        {
            return personals.GetPersonalInformationById(id);
        }
        /// <summary>
        /// 修改人员基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("UpdatePersonalInformation")]
        [HttpPost]
        public int UpdatePersonalInformation(PersonalInformation personal)
        {
            return personals.UpdatePersonalInformation(personal);
        }
    }
}
