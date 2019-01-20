using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CooperativeLabor.WebApi.Controllers.Approval
{
    using CooperativeLabor.Model;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Services;
    using Unity.Attributes;
    [RoutePrefix("AppProcessConfiguration")]
    public class AppProcessConfigurationController : ApiController
    {
        /// <summary>
        /// 审批配置表
        /// </summary>
        [Dependency]
        public IAppProcessConfigurationServices IAppProcessConfiguration { get; set; }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="appProcessConfiguration"></param>
        /// <returns></returns>
        [Route("Add")]
        [HttpGet]
        public int Add(AppProcessConfiguration appProcessConfiguration)
        {
           int i = this.IAppProcessConfiguration.Add(appProcessConfiguration);
            return i;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("Delete")]
        [HttpGet]
        public int Delete(int Id)
        {
            int i = this.IAppProcessConfiguration.Delete(Id);
            return i;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [Route("GetAppProcess")]
        [HttpGet]
        public IEnumerable<AppProcessConfiguration> GetAppProcess()
        {
            var result = this.IAppProcessConfiguration.GetAppProcess();
            return result;
        }

        /// <summary>
        /// 获取当个
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("GetAppProcessById")]
        [HttpGet]
        public AppProcessConfiguration GetAppProcessById(int Id)
        {
            var result = this.IAppProcessConfiguration.GetAppProcessById(Id);
            return result;
        }
        [Route("Update")]
        [HttpPost]
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>

        public int Update(AppProcessConfiguration appProcessConfiguration)
        {
            int i = this.IAppProcessConfiguration.Update(appProcessConfiguration);
            return i;
        }
    }
}
