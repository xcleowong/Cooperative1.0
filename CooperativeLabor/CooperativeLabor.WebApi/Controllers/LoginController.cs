using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CooperativeLabor.Comm;
namespace CooperativeLabor.WebApi.Controllers
{
    using CooperativeLabor.Model;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Services;
    using Unity.Attributes;
    [RoutePrefix("Login")]
    public class LoginController : ApiController
    {

        //[Dependency]

        //public IUserManagementServices userManagement { get; set; }
        [Dependency]
        public IUserManagementServices iUserManagement { get; set; }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="UserPassword"></param>
        /// <returns></returns>
        [Route("Login")]
        [HttpGet]
        public UserManagement Login(string UserName, string UserPassword)
        {
            var result = this.iUserManagement.Login(UserName, UserPassword);

            CookieHelper.SetCookie("cookie_rememberme", UserName, 1);

            return result;
        }

        [Route("getusers")]
        [HttpGet]
        public object getusers(string UserName, string UserPassword)
        {
            var result = this.iUserManagement.getusers(UserName,UserPassword);
             
            return result;
        }
    }
}
