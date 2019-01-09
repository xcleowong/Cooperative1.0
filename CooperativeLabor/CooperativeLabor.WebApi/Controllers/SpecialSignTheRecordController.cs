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
    public class SpecialSignTheRecordController : ApiController
    {
        ISpecialSignTheRecordServices specialSign = null;
        public SpecialSignTheRecordController(ISpecialSignTheRecordServices ispecialSign)
        {
            specialSign = ispecialSign;
        }
        /// <summary>
        /// 获取特别签录
        /// </summary>
        /// <returns></returns>
        public List<SpecialSignTheRecord> GetSpecialSignTheRecord()
        {
            var result = specialSign.GetSpecialSignTheRecord();
            return result;
        }

        /// <summary>
        /// 删除特别签录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        public int UpdateSpecialSignTheRecord(SpecialSignTheRecord special)
        {
            int i = specialSign.UpdateSpecialSignTheRecord(special);
            return i;
        }

    }
}
