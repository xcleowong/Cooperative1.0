using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CooperativeLabor.WebApi.Controllers
{
    using CooperativeLabor.Model;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Services;
    using Unity.Attributes;
    [RoutePrefix("Partner")]
    public class PartnerController : ApiController
    {
        private const int PAGESIZE = 5;

        /// <summary>
        /// 入离场记录
        /// </summary>
        [Dependency]
        public IEntryAndExitRecordServices entryAndExitRecord { get; set; }

    

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entryAndExitRecord"></param>
        /// <returns></returns>
        [Route("AddEnt")]
        [HttpPost]
        public int Add(EntryAndExitRecord entryAndExitRecord)
        {
            int i = this.entryAndExitRecord.Add(entryAndExitRecord);
            return i;

        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("DeleteEnt")]
        [HttpPost]
        public int Delete(int Id)
        {
            int i = this.entryAndExitRecord.Delete(Id);
            return i;
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetEntryAndExitRecordByIdEnt")]
        [HttpGet]
        public EntryAndExitRecord GetEntryAndExitRecordById(int Id)
        {
            var result = this.entryAndExitRecord.GetEntryAndExitRecordById(Id);
            return result;
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        [Route("GetEntryAndExitRecordsEnt")]
        [HttpGet]
        public PageNumber GetEntryAndExitRecords(int? pageIndex)
        {
            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            var result = this.entryAndExitRecord.GetEntryAndExitRecords().ToList();
            PageNumber pageNumber = new PageNumber();
            pageNumber.CurrentPage = Convert.ToInt32(pageIndex);
            pageNumber.TotlePage = (result.Count / PAGESIZE) + (result.Count % PAGESIZE == 0 ? 0 : 1);
            pageNumber.Data = result.Skip((Convert.ToInt32(pageIndex) - 1) * PAGESIZE).Take(PAGESIZE);
            return pageNumber;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entryAndExitRecord"></param>
        /// <returns></returns>
        [Route("UpdateEnt")]
        [HttpPost]
        public int Update(EntryAndExitRecord entryAndExitRecord)
        {
            int i = this.entryAndExitRecord.Update(entryAndExitRecord);
            return i;
        }


        /// <summary>
        /// 基本信息
        /// </summary>
        [Dependency]
        public IEssentialInformationServices essentialInformation { get; set; }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="essentialInformation"></param>
        /// <returns></returns>
        [Route("AddEss")]
        [HttpPost]
        public int Add(EssentialInformation essentialInformation)
        {
            int i = this.essentialInformation.Add(essentialInformation);
            return i;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("DeleteEss")]
        [HttpGet]
        public int Deletes(int Id)
        {
            int i = this.essentialInformation.Deletes(Id);
            return i;
        }

        /// <summary>
        /// 根据Id显示
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetEssentialInformationByIdEss")]
        [HttpGet]
        public EssentialInformation GetEssentialInformationById(int Id)
        {
            var result = this.essentialInformation.GetEssentialInformationById(Id);
            return result;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [Route("GetEssentialInformationsEss")]
        [HttpGet]
        public PageNumber GetEssentialInformations(int? pageIndex)
        {
            //      var result = this.essentialInformation.GetEssentialInformations();
            //      return result;
            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            var result = this.essentialInformation.GetEssentialInformations().ToList();
            PageNumber pageNumber = new PageNumber();
            pageNumber.CurrentPage = Convert.ToInt32(pageIndex);
            pageNumber.TotlePage = (result.Count / PAGESIZE) + (result.Count % PAGESIZE == 0 ? 0 : 1);
            pageNumber.Data = result.Skip((Convert.ToInt32(pageIndex) - 1) * PAGESIZE).Take(PAGESIZE);
            return pageNumber;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="essentialInformation"></param>
        /// <returns></returns>
        [Route("UpdateEss")]
        [HttpPost]
        public int Update(EssentialInformation essentialInformation)
        {
            int i = this.essentialInformation.Update(essentialInformation);
            return i;
        }

        /// <summary>
        /// 获取合作方Id，名称
        /// </summary>
        /// <returns></returns>
        [Route("GetEntryByIdName")]
        [HttpGet]
        public IEnumerable<EntryAndExitRecord> GetEntryByIdName()
        {
            var result = this.entryAndExitRecord.GetEntryByIdName();
            return result;
        }
    }
}
