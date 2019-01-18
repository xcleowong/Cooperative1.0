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
    [RoutePrefix("SpecialSignTheRecord")]
    public class SpecialSignTheRecordController : ApiController
    {
        private const int PAGESIZE = 5;

        ISpecialSignTheRecordServices specialSign = null;
        public SpecialSignTheRecordController(ISpecialSignTheRecordServices ispecialSign)
        {
            specialSign = ispecialSign;
        }
        /// <summary>
        /// 获取特别签录
        /// </summary>
        /// <returns></returns>
        [Route("GetSpecialSignTheRecord")]
        [HttpGet]
        public PageNumber GetSpecialSignTheRecord(int? pageIndex,string name="")
        {
            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            List<SpecialSignTheRecord> listGA = specialSign.GetSpecialSignTheRecord().ToList();
            if (!string.IsNullOrWhiteSpace(name))
            {
                listGA = listGA.Where(m => m.Name.Contains(name)).ToList();
            }
            PageNumber pageNumber = new PageNumber();
            pageNumber.DataCount = listGA.Count;
            pageNumber.CurrentPage = Convert.ToInt32(pageIndex);
            pageNumber.TotlePage = (listGA.Count / PAGESIZE) + (listGA.Count % PAGESIZE == 0 ? 0 : 1);
            pageNumber.Data = listGA.Skip((Convert.ToInt32(pageIndex) - 1) * PAGESIZE).Take(PAGESIZE);
            return pageNumber;

            
        }

        /// <summary>
        /// 删除特别签录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("DeleteSpecialSignTheRecord")]
        [HttpPost]
        public int DeleteSpecialSignTheRecord(int id)
        {
            int i = specialSign.DeleteSpecialSignTheRecord(id);
            return i;
        }


        /// <summary>
        /// 添加特别签录
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        [Route("AddSpecialSignTheRecord")]
        [HttpPost]
        public int AddSpecialSignTheRecord(SpecialSignTheRecord special)
        {
            int i = specialSign.AddSpecialSignTheRecord(special);
            return i;
        }

        /// <summary>
        /// 修改特别签录
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        [Route("UpdateSpecialSignTheRecord")]
        [HttpPost]
        public int UpdateSpecialSignTheRecord(SpecialSignTheRecord special)
        {
            int i = specialSign.UpdateSpecialSignTheRecord(special);
            return i;
        }

    }
}
