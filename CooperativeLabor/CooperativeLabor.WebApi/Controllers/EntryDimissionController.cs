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
    using Unity.Attributes;
    [RoutePrefix("EntryDimission")]
    public class EntryDimissionController : ApiController
    {
        [Dependency]
        public IEntryDimissionRecordServices entryDimission { get; set; }


        /// <summary>
        /// 添加入离职信息
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        [Route("AddEntry")]
        [HttpPost]
        public int AddEntryDimissionRecord(EntryDimissionRecord entry)
        {
            int i = entryDimission.AddEntryDimissionRecord(entry);
            return i;
        }

        /// <summary>
        /// 删除入离职信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DeleteEntry")]
        [HttpPost]
        public int DeleteEntryDimissionRecord(int id)
        {
            int i = entryDimission.DeleteEntryDimissionRecord(id);
            return i;
        }

        /// <summary>
        /// 根据Id获取人员信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("GetEntryDimissionRecordById")]
        [HttpGet]
        public List<EntryDimissionRecord> GetEntryDimissionRecordById(int id)
        {
            var result = entryDimission.GetEntryDimissionRecordById(id);
            return result;
        }

        /// <summary>
        /// 获取入离职信息
        /// </summary>
        /// <returns></returns>
        [Route("GetEntryDimissionRecords")]
        [HttpGet]
        public List<EntryDimissionRecord> GetEntryDimissionRecords()
        {
            var result = entryDimission.GetEntryDimissionRecords();
            return result;
        }

        /// <summary>
        /// 修改入离职信息
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        [Route("UpdateEntry")]
        [HttpPost]
        public int UpdateEntryDimissionRecord(EntryDimissionRecord entry)
        {
            int i = entryDimission.UpdateEntryDimissionRecord(entry);
            return i;
        }
    }
}
