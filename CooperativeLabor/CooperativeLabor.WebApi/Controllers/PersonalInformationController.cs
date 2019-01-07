using System;
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
        public List<PersonalInformation> GetPersonalInformation()
        {
            return personals.GetPersonalInformation();
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
