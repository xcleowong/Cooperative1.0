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
    [RoutePrefix("Login")]
    public class LoginController : ApiController
    {

        [Dependency]
        public IUserManagementServices userManagement { get; set; }
        [Route("Login")]
        [HttpGet]
        public UserManagement Login(string UserName, string UserPassword)
        {
         var result = this.userManagement.Login(UserName, UserPassword);
            
            return result;
        }
    }
}
